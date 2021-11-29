IContainersService containersService = new ContainersService();
IWorkspacesService workspacesService = new WorkspacesService();
IWorkspacesRuntimeService workspacesRuntimeService = new WorkspacesRuntimeService(containersService, workspacesService);
var username = "akorda";
var workspaceName = "project1";
var imageName = "cdev/cdev-dotnet-6:0.1";

var createWorkspaceRequest = new CreateWorkspaceRequest(workspaceName, imageName, username);
var cancellationToken = CancellationToken.None;
var workspaceId = await workspacesService.CreateWorkspaceAsync(createWorkspaceRequest, cancellationToken);
await workspacesRuntimeService.StartWorkspaceAsync(workspaceId, cancellationToken);