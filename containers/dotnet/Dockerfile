FROM mcr.microsoft.com/dotnet/sdk:6.0.100-bullseye-slim

# install and start sshd
RUN bash -c "$(curl -sSL https://raw.githubusercontent.com/microsoft/vscode-dev-containers/main/script-library/sshd-debian.sh)" -- 22 $(whoami) false random
EXPOSE 22

# create vscode user
RUN adduser --disabled-password --gecos "" vscode
# and set his password
RUN echo 'vscode:test123!' | chpasswd
# add user to sudoers
# RUN usermod -aG sudo vscode

# switch to vscode user
RUN su vscode

# create vscode server folder
RUN mkdir -p /home/vscode/.vscode-server/bin/ccbaa2d27e38e5afa3e5c21c1c7bef4657064247
RUN cd /home/vscode/.vscode-server/bin/ccbaa2d27e38e5afa3e5c21c1c7bef4657064247
# download vscode server binaries
# TODO: check these downloads: https://github.com/cdr/code-server/releases
RUN wget -q -O vscode-server-linux-x64.tar.gz https://update.code.visualstudio.com/commit:ccbaa2d27e38e5afa3e5c21c1c7bef4657064247/server-linux-x64/stable
# extract to destination
RUN tar -xzf vscode-server-linux-x64.tar.gz --strip-components 1
# delete the downloaded file
RUN rm ./vscode-server-linux-x64.tar.gz

# create server extensions directory
RUN mkdir -p /home/vscode/.vscode-remote/extensions
RUN mkdir -p /home/vscode/.vscode-server/extensions

# TODO: add some extensions
RUN chown -R vscode /home/vscode

RUN mkdir /workspace
RUN chown -R vscode /workspace

COPY entrypoint.sh /run/
RUN chmod +x /run/entrypoint.sh

# run as vscode
# USER vscode

# set startup script
ENTRYPOINT ["/run/entrypoint.sh"]
