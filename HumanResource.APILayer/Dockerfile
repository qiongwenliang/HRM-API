#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HumanResource.APILayer/HumanResource.APILayer.csproj", "HumanResource.APILayer/"]
COPY ["Hrm.Infrastructure/Hrm.Infrastructure.csproj", "Hrm.Infrastructure/"]
COPY ["Hrm.ApplicationCore/Hrm.ApplicationCore.csproj", "Hrm.ApplicationCore/"]
RUN dotnet restore "HumanResource.APILayer/HumanResource.APILayer.csproj"
COPY . .
WORKDIR "/src/HumanResource.APILayer"
RUN dotnet build "HumanResource.APILayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HumanResource.APILayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString="Data Source=localhost,1433;Initial Catalog=HrmAPI;User ID=sa;Password=Admin@1234;TrustServerCertificate=True"

ENTRYPOINT ["dotnet", "HumanResource.APILayer.dll"]