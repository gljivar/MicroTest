FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["MicroWeb/MicroWeb.csproj", "MicroWeb/"]
COPY ["MicroApi/MicroApi.csproj", "MicroApi/"]
RUN dotnet restore "MicroWeb/MicroWeb.csproj"
COPY . .
WORKDIR "/src/MicroWeb"
RUN dotnet build "MicroWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicroWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroWeb.dll"]
