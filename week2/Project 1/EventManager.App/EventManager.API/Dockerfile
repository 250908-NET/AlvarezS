# ======== Build Stage ==========
# Use the .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file first and restore dependncies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# ======= Runtime Stage ========
# Use a lightweight runtime image (no SDK needed)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy build ouypuy yo runtime image
COPY --from=build /app/publish .

# Expost port (default for Kestrel)
EXPOSE 8080

#Start app
ENTRYPOINT [ "dotnet", "EventManager.API.dll" ]