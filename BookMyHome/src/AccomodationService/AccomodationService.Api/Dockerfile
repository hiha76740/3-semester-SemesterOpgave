# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

RUN apt-get update \
    && apt-get install -y curl \
    && rm -rf /var/lib/apt/lists/*


USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AccomodationService/AccomodationService.Api/AccomodationService.Api.csproj", "src/AccomodationService/AccomodationService.Api/"]
COPY ["src/AccomodationService/AccomodationService.FacadeLib/AccomodationService.FacadeLib.csproj", "src/AccomodationService/AccomodationService.FacadeLib/"]
COPY ["src/AccomodationService/AccomodationService.InfrastructureLib/AccomodationService.InfrastructureLib.csproj", "src/AccomodationService/AccomodationService.InfrastructureLib/"]
COPY ["src/AccomodationService/AccomodationService.DomainLib/AccomodationService.DomainLib.csproj", "src/AccomodationService/AccomodationService.DomainLib/"]
COPY ["src/Shared/BookMyHome.SharedKernelLib/BookMyHome.SharedKernelLib.csproj", "src/Shared/BookMyHome.SharedKernelLib/"]
COPY ["src/AccomodationService/AccomodationService.ApplicationLib/AccomodationService.ApplicationLib.csproj", "src/AccomodationService/AccomodationService.ApplicationLib/"]
COPY ["src/Shared/BookMyHome.ContractsLib/BookMyHome.ContractsLib.csproj", "src/Shared/BookMyHome.ContractsLib/"]
COPY ["src/Shared/BookMyHome.BuildingBlocksLib/BookMyHome.BuildingBlocksLib.csproj", "src/Shared/BookMyHome.BuildingBlocksLib/"]
RUN dotnet restore "./src/AccomodationService/AccomodationService.Api/AccomodationService.Api.csproj"
COPY . .
WORKDIR "/src/src/AccomodationService/AccomodationService.Api"
RUN dotnet build "./AccomodationService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AccomodationService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccomodationService.Api.dll"]