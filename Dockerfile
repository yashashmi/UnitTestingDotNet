FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /sln

COPY ./*.sln ./

# Copy the main source project files
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore

# Copy everything else and build
From build AS compile
RUN dotnet build --configuration Release


FROM build AS testrunner
WORKDIR /sln/
COPY . ./
RUN dotnet test 
#ENTRYPOINT ["dotnet", "test", "Learning.Tests.dll",  "--logger:trx"]
