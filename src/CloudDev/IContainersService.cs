public interface IContainersService
{
    Task<string> CreateVolumeAsync(VolumeInfo volume, CancellationToken cancellationToken = default);
    Task<string> CreateContainerAsync(ContainerInfo container, CancellationToken cancellationToken = default);
    Task StartContainerAsync(string containerId, IEnumerable<VolumeMount> volumeMounts, CancellationToken cancellationToken = default);
    Task StopContainerAsync(string containerId, CancellationToken cancellationToken = default);
}
