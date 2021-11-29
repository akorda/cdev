public class WorkspacesService : IWorkspacesService
{
    public Task<string> CreateWorkspaceAsync(CreateWorkspaceRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkspaceInfo> GetWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}