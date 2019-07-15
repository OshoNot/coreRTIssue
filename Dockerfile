FROM ubuntu:18.04

ENV CppCompilerAndLinker=clang-6.0

RUN apt-get update && \
    apt-get install -y wget gpg

RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg && \
mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/ && \
wget -q https://packages.microsoft.com/config/ubuntu/18.04/prod.list && \
mv prod.list /etc/apt/sources.list.d/microsoft-prod.list && \
chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg && \
chown root:root /etc/apt/sources.list.d/microsoft-prod.list && \
apt-get update

#Installing .NET Core 2.2
RUN apt-get install -y  apt-transport-https \
			dotnet-sdk-2.2

#Installing Dependencies
RUN apt-get install -y \
        build-essential \
        cmake \
        curl \
        git-core \
        parallel \
        # python dependencies
        libbz2-dev \
        libncurses5-dev \
        libncursesw5-dev \
        libreadline-dev \
        libsqlite3-dev \
        clang \
        libssl-dev \
        llvm \
        make \
        #tk-dev \
        #wget \
        #xz-utils \
        zlib1g-dev \
	libkrb5-dev

WORKDIR /home/app

COPY ./DbPrototype.fsproj /home/app
COPY ./nuget.config /home/app
RUN dotnet restore


COPY ./ /home/app
RUN dotnet publish -r linux-x64 -c Release -o outside -v d
CMD ./outside/DbPrototype
