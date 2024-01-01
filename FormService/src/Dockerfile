FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FormService.Infrastructure/FormService.Infrastructure.csproj", "src/FormService.Infrastructure/"]
COPY ["FormService.Domain/FormService.Domain.csproj", "src/FormService.Domain/"]
COPY ["FormService.Api/FormService.Api.csproj", "src/FormService.Api/"]

RUN dotnet restore "src/FormService.Api/FormService.Api.csproj"

COPY . .

WORKDIR "/src/FormService.Api"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80

COPY --from=build /src/FormService.Api/out .

ENTRYPOINT [ "dotnet", "FormService.Api.dll" ]
