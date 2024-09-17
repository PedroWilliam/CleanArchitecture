# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Reservation.Api/Reservation.Api.csproj", "src/Reservation.Api/"]
COPY ["src/Reservation.Application/Reservation.Application.csproj", "src/Reservation.Application/"]
COPY ["src/Reservation.Domain/Reservation.Domain.csproj", "src/Reservation.Domain/"]
COPY ["src/Reservation.Infrastructure/Reservation.Infrastructure.csproj", "src/Reservation.Infrastructure/"]
RUN dotnet restore "./src/Reservation.Api/Reservation.Api.csproj"
COPY . .
WORKDIR "/src/src/Reservation.Api"
RUN dotnet build "./Reservation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Reservation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.Api.dll"]