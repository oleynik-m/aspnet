FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebApplicationGame/*.csproj ./WebApplicationGame/
RUN dotnet restore

# copy everything else and build app
COPY WebApplicationGame/. ./WebApplicationGame/
WORKDIR /source/WebApplicationGame
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApplicationGame.dll"]