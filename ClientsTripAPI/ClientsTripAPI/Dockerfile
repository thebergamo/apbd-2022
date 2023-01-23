FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClientsTripAPI/ClientsTripAPI.csproj", "ClientsTripAPI/"]
RUN dotnet restore "ClientsTripAPI/ClientsTripAPI.csproj"
COPY . .
WORKDIR "/src/ClientsTripAPI"
RUN dotnet build "ClientsTripAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientsTripAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientsTripAPI.dll"]
