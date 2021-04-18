# Docker build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# csproj files are used to restore NuGet packges. Copy only the csproj file and restore the NuGet packages
# This way if the csproj file has not changed, Docker can use cached versions of the subsequent layers/commands
COPY ConsoleApp.csproj ./
RUN dotnet restore

# Copy the whole project dir and build
COPY . ./
RUN dotnet publish ConsoleApp.csproj -c Release -o out

# Start the app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]