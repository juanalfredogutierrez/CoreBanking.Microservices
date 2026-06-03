FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar toda la solución
COPY . .

# Restore
RUN dotnet restore ./Gateway.API/Gateway.API.csproj

# Publish
RUN dotnet publish ./Gateway.API/Gateway.API.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# 🔥 IMPORTANTE: asegurar que ocelot.json exista
COPY Gateway.API/ocelot.json /app/ocelot.json

ENTRYPOINT ["dotnet", "Gateway.API.dll"]