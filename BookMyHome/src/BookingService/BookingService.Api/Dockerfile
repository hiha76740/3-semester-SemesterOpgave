# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID

RUN apt-get update \
    && apt-get install -y curl \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BookingService/BookingService.Api/BookingService.Api.csproj", "src/BookingService/BookingService.Api/"]
COPY ["src/BookingService/BookingService.FacadeLib/BookingService.FacadeLib.csproj", "src/BookingService/BookingService.FacadeLib/"]
COPY ["src/BookingService/BookingService.InfrastructureLib/BookingService.InfrastructureLib.csproj", "src/BookingService/BookingService.InfrastructureLib/"]
COPY ["src/BookingService/BookingService.DomainLib/BookingService.DomainLib.csproj", "src/BookingService/BookingService.DomainLib/"]
COPY ["src/Shared/BookMyHome.SharedKernelLib/BookMyHome.SharedKernelLib.csproj", "src/Shared/BookMyHome.SharedKernelLib/"]
COPY ["src/BookingService/BookingService.ApplicationLib/BookingService.ApplicationLib.csproj", "src/BookingService/BookingService.ApplicationLib/"]
COPY ["src/Shared/BookMyHome.ContractsLib/BookMyHome.ContractsLib.csproj", "src/Shared/BookMyHome.ContractsLib/"]
COPY ["src/Shared/BookMyHome.BuildingBlocksLib/BookMyHome.BuildingBlocksLib.csproj", "src/Shared/BookMyHome.BuildingBlocksLib/"]
RUN dotnet restore "./src/BookingService/BookingService.Api/BookingService.Api.csproj"
COPY . .
WORKDIR "/src/src/BookingService/BookingService.Api"
RUN dotnet build "./BookingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingService.Api.dll"]