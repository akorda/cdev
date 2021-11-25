# Cloud Development environments -> cdev

The people's cloud development environments!

## Build an image

```bash
docker build -t akorda/cdev:0.1 .
```

## run the image

```bash
docker run -it --init --rm -v ~/tmp/workspace:/workspace -p 5100:22 akorda/cdev:0.1
```
