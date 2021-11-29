public class WorkspacesRuntimeService : IWorkspacesRuntimeService
{
    IContainersService ContainersService { get; }
    IWorkspacesService WorkspacesService { get; }

    public WorkspacesRuntimeService(IContainersService containersService, IWorkspacesService workspacesService)
    {
        this.ContainersService = containersService;
        this.WorkspacesService = workspacesService;
    }

    public async Task StartWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default)
    {
        var workspace = await this.WorkspacesService.GetWorkspaceAsync(workspaceId, cancellationToken);
        if (workspace == null)
        {
            //TODO: use a custom exception
            throw new Exception($"Workspace with Id '{workspaceId}' not found");
        }

        if (workspace.Status == WorkspaceStatus.Pending)
        {
            var containerId = await this.InitializeWorkspaceAsync(workspace, cancellationToken);
            workspace = workspace with { ContainerId = containerId, Status = WorkspaceStatus.Initialized };
            //TODO: save workspace
        }

        var volumeMounts = new[]
        {
            new VolumeMount(workspace.WorkspaceVolumeName, "/workspace"),
            //TODO: Use dynamic workspace user name
            new VolumeMount(workspace.HomeVolumeName, "/home/vscode"),
        };
        await this.ContainersService.StartContainerAsync(workspace.ContainerId, volumeMounts, cancellationToken);
    }

    public Task StopWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private async Task<string> InitializeWorkspaceAsync(WorkspaceInfo workspace, CancellationToken cancellationToken)
    {
        var workspaceVolumeName = $"workspace_{workspace.Id}";
        var workspaceVolume = new VolumeInfo(workspaceVolumeName);
        var workspaceVolumeId = await this.ContainersService.CreateVolumeAsync(workspaceVolume, cancellationToken);

        var vscodeVolumeName = $"workspace_{workspace.Id}";
        var vsCodeVolume = new VolumeInfo(vscodeVolumeName);
        var vscodeVolumeId = await this.ContainersService.CreateVolumeAsync(vsCodeVolume, cancellationToken);

        var container = new ContainerInfo(workspace.ImageName);
        var containerId = await this.ContainersService.CreateContainerAsync(container, cancellationToken);

        return containerId;
    }
}