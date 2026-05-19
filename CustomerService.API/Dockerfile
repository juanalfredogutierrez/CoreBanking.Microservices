FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar TODO desde la raíz de la solución
COPY . .

# restaurar desde el csproj correcto
RUN dotnet restore ./CustomerService.API/CustomerService.API.csproj
RUN ls -R /src
RUN dotnet publish ./CustomerService.API/CustomerService.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.API.dll"]