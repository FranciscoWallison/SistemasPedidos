# ENTRYPOINT ["dotnet", "run", "--urls=http://0.0.0.0:8080/"]
# [Choice] .NET version: 6.0, 5.0, 3.1, 6.0-bullseye, 5.0-bullseye, 3.1-bullseye, 6.0-focal, 5.0-focal, 3.1-focal
ARG VARIANT="6.0-focal"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}
# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi
# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
&& apt-get -y install --no-install-recommends vim
RUN dotnet tool install -g dotnet-ef

RUN curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -
RUN apt install nodejs
RUN npm install -g create-react-app
RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.35.3/install.sh | bash
RUN nvm install node | bash

ENV PATH $PATH:/root/.dotnet/tools

COPY ./front /front
COPY ./app /app
WORKDIR /app
RUN dotnet tool install dotnet-ef

# RUN dotnet add package Microsoft.AspNetCore.Mvc
# RUN dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
# RUN dotnet add package Microsoft.Extensions.Configuration --version 6.0.1
# RUN dotnet add package System.Data.Entity.Repository


RUN dotnet add package AutoMapper
RUN dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
RUN dotnet add package Microsoft.EntityFrameworkCore
RUN dotnet add package Microsoft.EntityFrameworkCore.Design
RUN dotnet add package Microsoft.EntityFrameworkCore.InMemory
RUN dotnet add package Microsoft.EntityFrameworkCore.Relational
RUN dotnet add package Microsoft.EntityFrameworkCore.Sqlite
RUN dotnet add package Microsoft.EntityFrameworkCore.Tools
RUN dotnet add package Microsoft.Data.Sqlite

EXPOSE 8080
