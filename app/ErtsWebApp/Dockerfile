#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

ENV NODE_ENV development
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

WORKDIR /src
COPY ["ErtsWebApp/ErtsWebApp.csproj", "ErtsWebApp/"]
COPY ["ErtsModel/ErtsModel.csproj", "ErtsModel/"]
COPY ["ErtsApplication/ErtsApplication.csproj", "ErtsApplication/"]

RUN dotnet restore "ErtsWebApp/ErtsWebApp.csproj"
COPY . .
WORKDIR "/src/ErtsWebApp"
RUN dotnet build "ErtsWebApp.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ErtsWebApp.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .


FROM base AS final
WORKDIR /app
COPY --from=build /app/build .

COPY ["ErtsWebApp/ClientApp/package.json", "ClientApp/"]
COPY ["ErtsWebApp/ClientApp/package-lock.json", "ClientApp/"]
COPY ["ErtsWebApp/ClientApp/.env.development", "ClientApp/"]
COPY ["ErtsWebApp/ClientApp/tsconfig.json", "ClientApp/"]
COPY ["ErtsWebApp/ClientApp/src", "ClientApp/src"]
COPY ["ErtsWebApp/ClientApp/public", "ClientApp/public"]

WORKDIR /app/ClientApp
RUN npm install

WORKDIR /app
ENTRYPOINT ["dotnet", "ErtsWebApp.dll"]