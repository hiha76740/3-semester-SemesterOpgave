# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/UserService/UserService.Api/UserService.Api.csproj", "src/UserService/UserService.Api/"]
COPY ["src/UserService/UserService.FacadeLib/UserService.FacadeLib.csproj", "src/UserService/UserService.FacadeLib/"]
COPY ["src/UserService/UserService.InfrastructureLib/UserService.InfrastructureLib.csproj", "src/UserService/UserService.InfrastructureLib/"]
COPY ["src/UserService/UserService.DomainLib/UserService.DomainLib.csproj", "src/UserService/UserService.DomainLib/"]
COPY ["src/Shared/BookMyHome.SharedKernelLib/BookMyHome.SharedKernelLib.csproj", "src/Shared/BookMyHome.SharedKernelLib/"]
COPY ["src/UserService/UserService.ApplicationLib/UserService.ApplicationLib.csproj", "src/UserService/UserService.ApplicationLib/"]
COPY ["src/Shared/BookMyHome.ContractsLib/BookMyHome.ContractsLib.csproj", "src/Shared/BookMyHome.ContractsLib/"]
COPY ["src/Shared/BookMyHome.BuildingBlocksLib/BookMyHome.BuildingBlocksLib.csproj", "src/Shared/BookMyHome.BuildingBlocksLib/"]
RUN dotnet restore "./src/UserService/UserService.Api/UserService.Api.csproj"
COPY . .
WORKDIR "/src/src/UserService/UserService.Api"
RUN dotnet build "./UserService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.Api.dll"]