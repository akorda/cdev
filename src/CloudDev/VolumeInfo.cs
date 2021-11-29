public class VolumeInfo
{
    public string Name { get; set; }
    public long MaxSizeMB { get; set; } = 1_000; //1 GB

    public VolumeInfo(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }

        this.Name = name;
    }
}
