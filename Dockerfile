# syntax=docker/dockerfile:1

# ---- Build stage -----------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy only the .csproj files first so `dotnet restore` is cached as its own
# Docker layer and only re-runs when a project reference/package changes.
COPY ["SIDAPA.domain/SIDAPA.domain.csproj", "SIDAPA.domain/"]
COPY ["SIDAPA.application/SIDAPA.application.csproj", "SIDAPA.application/"]
COPY ["SIDAPA.infraestructure/SIDAPA.infraestructure.csproj", "SIDAPA.infraestructure/"]
COPY ["SIDAPA.presentation/SIDAPA.presentation.csproj", "SIDAPA.presentation/"]
RUN dotnet restore "SIDAPA.presentation/SIDAPA.presentation.csproj"

# Now copy the rest of the source. The presentation layer is the one that
# gets published and runs the web server, but its dependencies (domain,
# application, infraestructure) must also be present for the build to work.
COPY SIDAPA.domain/. SIDAPA.domain/
COPY SIDAPA.application/. SIDAPA.application/
COPY SIDAPA.infraestructure/. SIDAPA.infraestructure/
COPY SIDAPA.presentation/. SIDAPA.presentation/

WORKDIR /src/SIDAPA.presentation
RUN dotnet publish "SIDAPA.presentation.csproj" -c Release -o /app/publish --no-restore

# ---- Runtime stage ----------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Only the presentation layer's published output is shipped in the final
# image; it is the only layer that exposes the web server port.
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "SIDAPA.presentation.dll"]
