public interface IWorkspacesService
{
    Task<string> CreateWorkspaceAsync(CreateWorkspaceRequest request, CancellationToken cancellationToken = default);
    Task<WorkspaceInfo> GetWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default);
}
