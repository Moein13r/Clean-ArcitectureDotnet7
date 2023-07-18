#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Dot7.Architecture.Api/Dot7.Architecture.Api.csproj", "Dot7.Architecture.Api/"]
COPY ["Dot7.Architecture.Application/Dot7.Architecture.Application.csproj", "Dot7.Architecture.Application/"]
COPY ["Dot7.Architecture.Domain/Dot7.Architecture.Domain.csproj", "Dot7.Architecture.Domain/"]
COPY ["Dot7.Architecture.Infrastructure/Dot7.Architecture.Infrastructure.csproj", "Dot7.Architecture.Infrastructure/"]
RUN dotnet restore "Dot7.Architecture.Api/Dot7.Architecture.Api.csproj"
COPY . .
WORKDIR "/src/Dot7.Architecture.Api"
RUN dotnet build "Dot7.Architecture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dot7.Architecture.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dot7.Architecture.Api.dll"]