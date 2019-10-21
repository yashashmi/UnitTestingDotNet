FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /sln

COPY ./*.sln ./

# Copy the main source project files
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir ${file%.*}/ && mv $file ${file%.*}/; done

# Copy the test project files
#COPY Learning.Tests/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir ${file%.*}/ && mv $file ${file%.*}/; done


RUN dotnet restore
