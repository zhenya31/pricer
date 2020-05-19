FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
#RUN dotnet tool install --global dotnet-ef; dotnet ef database update
RUN find -type d -name bin -prune -exec rm -rf {} \; && find -type d -name obj -prune -exec rm -rf {} \;
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app
COPY --from=build-env /app/out out
COPY --from=build-env /app/app.db .
COPY --from=build-env /app/appsettings.json .
COPY --from=build-env /app/appsettings.Development.json .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "out/Pricer_v3.dll"]