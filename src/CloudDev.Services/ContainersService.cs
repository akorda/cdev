public class ContainersService : IContainersService
{
    public Task<string> CreateContainerAsync(ContainerInfo container, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateVolumeAsync(VolumeInfo volume, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StartContainerAsync(string containerId, IEnumerable<VolumeMount> volumeMounts, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StopContainerAsync(string containerId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}