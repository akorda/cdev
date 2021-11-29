public class ContainerInfo
{
    public string ImageName { get; set; }

    public ContainerInfo(string imageName)
    {
        if (string.IsNullOrEmpty(imageName))
        {
            throw new ArgumentException($"'{nameof(imageName)}' cannot be null or empty.", nameof(imageName));
        }

        this.ImageName = imageName;
    }
}