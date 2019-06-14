TOP := $(shell dirname $(realpath $(lastword $(MAKEFILE_LIST))))

RESTORE = $(TOP)/dotnet/dotnet restore
MSBUILD = $(TOP)/dotnet/dotnet msbuild
MSBUILD_FLAGS = -v:n /p:WpfSharedDir=$(TOP)/src/Microsoft.DotNet.Wpf/src/Shared/ /p:PerlCommand=$(shell which perl)
DOTNET_URL = https://download.visualstudio.microsoft.com/download/pr/7e4b403c-34b3-4b3e-807c-d064a7857fe8/95c738f08e163f27867e38c602a433a1/dotnet-sdk-3.0.100-preview5-011568-linux-x64.tar.gz

P ?= PresentationFramework.csproj

all: msbuild

msbuild: dotnet/dotnet
	$(RESTORE) $(shell find $(TOP)/src/Microsoft.DotNet.Wpf -name $(P))
	$(MSBUILD) $(MSBUILD_FLAGS) $(shell find src/Microsoft.DotNet.Wpf -name $(P))

clean:
	$(MSBUILD) $(MSBUILD_FLAGS) /t:Clean $(shell find src/Microsoft.DotNet.Wpf -name $(P))

dotnet/dotnet:
	mkdir -p dotnet
	wget $(DOTNET_URL) -O- | tar xzvf - -C dotnet
