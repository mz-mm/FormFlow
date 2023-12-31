FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore "./src/src.csproj" --disable-parallel
RUN dotnet publish "./src/src.csproj" -c release -o /app/out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "src.dll"]
