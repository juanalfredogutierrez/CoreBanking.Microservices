FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar TODO desde la raíz de la solución
COPY . .

# restaurar desde el csproj correcto
RUN dotnet restore ./AccountService.API/AccountService.API.csproj
RUN ls -R /src
RUN dotnet publish ./AccountService.API/AccountService.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AccountService.API.dll"]