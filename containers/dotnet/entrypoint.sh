#!/usr/bin/env bash

# start sshd
/usr/local/share/ssh-init.sh

# switch to vscode user
su vscode

# start vs code server
/home/vscode/.vscode-server/bin/ccbaa2d27e38e5afa3e5c21c1c7bef4657064247/server.sh --start-server --host=127.0.0.1 --enable-remote-auto-shutdown --port=0  &> "/home/vscode/.vscode-server/.ccbaa2d27e38e5afa3e5c21c1c7bef4657064247.log" < /dev/null