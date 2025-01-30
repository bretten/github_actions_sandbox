FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_ID
ENV BUILD_ID=${BUILD_ID}
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# csproj files are used to restore NuGet packges. Copy only the csproj file and restore the NuGet packages
# This way if the csproj file has not changed, Docker can use cached versions of the subsequent layers/commands
COPY ../Directory.Build.props ./
COPY ConsoleAppSecondsCountdown/ConsoleAppSecondsCountdown.csproj ./
RUN dotnet restore

# Copy the whole project dir and build
COPY . ./
RUN dotnet build ConsoleAppSecondsCountdown/ConsoleAppSecondsCountdown.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ConsoleAppSecondsCountdown/ConsoleAppSecondsCountdown.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Start the app
FROM base AS final
ARG BUILD_ID
ENV BUILD_ID=${BUILD_ID}
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleAppSecondsCountdown.dll"]