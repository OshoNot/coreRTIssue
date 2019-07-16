FROM ubuntu:18.04

RUN apt-get update \
    && apt-get install -y \
        apt-transport-https \
        build-essential \
        clang \
        cmake \
        curl \
        git-core \
        gpg \
        libbz2-dev \
        libkrb5-dev \
        libncurses5-dev \
        libncursesw5-dev \
        libreadline-dev \
        libsqlite3-dev \
        libssl-dev \
        llvm \
        make \
        parallel \
        wget \
        zlib1g-dev

RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg \
    && mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ \
    && wget -q https://packages.microsoft.com/config/ubuntu/18.04/prod.list \
    && mv prod.list /etc/apt/sources.list.d/microsoft-prod.list \
    && chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg \
    && chown root:root /etc/apt/sources.list.d/microsoft-prod.list \
    && apt-get update \
    && apt-get install -y dotnet-sdk-2.2

ENV CppCompilerAndLinker=clang-6.0
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

WORKDIR /home/app

COPY ./HelloWorld.fsproj /home/app
COPY ./nuget.config /home/app
RUN dotnet restore

COPY ./ /home/app
RUN dotnet publish -r linux-x64 -c Release -v detailed -o outside

CMD ./outside/HelloWorld
