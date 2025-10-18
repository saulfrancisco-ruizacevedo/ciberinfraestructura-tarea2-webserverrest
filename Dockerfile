# Multi-stage build for ASP.NET Core app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore first for better caching
COPY ./ciberinfraestructura-tarea2-webserver-rest.csproj ./
RUN dotnet restore "./ciberinfraestructura-tarea2-webserver-rest.csproj"

# copy everything else and publish
COPY . ./
RUN dotnet publish "./ciberinfraestructura-tarea2-webserver-rest.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Listen on port 80 inside container
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "ciberinfraestructura-tarea2-webserver-rest.dll"]
