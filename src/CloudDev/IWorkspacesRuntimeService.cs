public interface IWorkspacesRuntimeService
{
    Task StartWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default);
    Task StopWorkspaceAsync(string workspaceId, CancellationToken cancellationToken = default);
}
