FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish DotNet.MinimalApi.Playground.Api \
    -c Release \
    -o /app/publish

FROM runtime AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotNet.MinimalApi.Playground.Api.dll"]