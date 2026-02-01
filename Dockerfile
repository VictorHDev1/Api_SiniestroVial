FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore API_SiniestroVial/API_SiniestroVial.csproj
RUN dotnet publish API_SiniestroVial/API_SiniestroVial.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API_SiniestroVial.dll"]