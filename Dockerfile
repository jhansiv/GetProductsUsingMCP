# -----------------------------
# 1️⃣ Build Stage
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# -----------------------------
# 2️⃣ Runtime Stage
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Railway injects PORT dynamically
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

# Expose default fallback port (not strictly required)
EXPOSE 8080

ENTRYPOINT ["dotnet", "GetProductsUsingMCP.dll"]
