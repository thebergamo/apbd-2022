FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AnimalsAPI/AnimalsAPI.csproj", "AnimalsAPI/"]
RUN dotnet restore "AnimalsAPI/AnimalsAPI.csproj"
COPY . .
WORKDIR "/src/AnimalsAPI"
RUN dotnet build "AnimalsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnimalsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimalsAPI.dll"]
