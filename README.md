# Cloud Development environments -> cdev

The people's cloud development environments!

## Build an image

```bash
cd containers/dotnet
docker build -t cdev/cdev-dotnet-6:0.1 .
```

## run the image

```bash
# create the workspace on host if necessary
# mkdir -p ~/workspaces/project1

# start the image
docker run -it --init --rm -v ~/workspaces/project1:/workspace -p 5100:22 cdev/cdev-dotnet-6:0.1
```
