FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["WorkspaceService.Infrastructure/WorkspaceService.Infrastructure.csproj", "src/WorkspaceService.Infrastructure/"]
COPY ["WorkspaceService.Domain/WorkspaceService.Domain.csproj", "src/WorkspaceService.Domain/"]
COPY ["WorkspaceService.Api/WorkspaceService.Api.csproj", "src/WorkspaceService.Api/"]

RUN dotnet restore "src/WorkspaceService.Api/WorkspaceService.Api.csproj"

COPY . .

WORKDIR "/src/WorkspaceService.Api"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80

COPY --from=build /src/WorkspaceService.Api/out .

ENTRYPOINT [ "dotnet", "WorkspaceService.Api.dll" ]
