#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ErtsApiFetcher/ErtsApiFetcher.csproj", "ErtsApiFetcher/"]
COPY ["ErtsModel/ErtsModel.csproj", "ErtsModel/"]
COPY ["PandaScore.NET/PandaScore.NET/PandaScore.NET.csproj", "PandaScore.NET/PandaScore.NET/"]
RUN dotnet restore "ErtsApiFetcher/ErtsApiFetcher.csproj"
COPY . .
WORKDIR "/src/ErtsApiFetcher"
RUN dotnet build "ErtsApiFetcher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ErtsApiFetcher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ErtsApiFetcher.dll"]