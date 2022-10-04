#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["YUEX.OrderManagementProject.API/YUEX.OrderManagementProject.API.csproj", "YUEX.OrderManagementProject.API/"]
COPY ["YUEX.OrderManagementProject.Business/YUEX.OrderManagementProject.Business.csproj", "YUEX.OrderManagementProject.Business/"]
COPY ["YUEX.OrderManagementProject.Entities/YUEX.OrderManagementProject.Entities.csproj", "YUEX.OrderManagementProject.Entities/"]
COPY ["YUEX.OrderManagementProject.Repository/YUEX.OrderManagementProject.Repository.csproj", "YUEX.OrderManagementProject.Repository/"]
COPY ["YUEX.OrderManagementProject.DataAccess/YUEX.OrderManagementProject.DataAccess.csproj", "YUEX.OrderManagementProject.DataAccess/"]
RUN dotnet restore "YUEX.OrderManagementProject.API/YUEX.OrderManagementProject.API.csproj"
COPY . .
WORKDIR "/src/YUEX.OrderManagementProject.API"
RUN dotnet build "YUEX.OrderManagementProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YUEX.OrderManagementProject.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YUEX.OrderManagementProject.API.dll"]