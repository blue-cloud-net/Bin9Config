#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM ubuntu:22.04 AS base
RUN apt update && apt install -y bind9 bind9utils aspnetcore-runtime-8.0
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 53

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/Bind9Config.Manager/Bind9Config.Manager.Api.Host/Bind9Config.Manager.Api.Host.csproj", "src/Bind9Config.Manager/Bind9Config.Manager.Api.Host/"]
RUN dotnet restore "./src/Bind9Config.Manager/Bind9Config.Manager.Api.Host/./Bind9Config.Manager.Api.Host.csproj"
COPY . .
WORKDIR "/src/src/Bind9Config.Manager/Bind9Config.Manager.Api.Host"
RUN dotnet build "./Bind9Config.Manager.Api.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bind9Config.Manager.Api.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bind9Config.Manager.Api.Host.dll"]