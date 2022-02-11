#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

WORKDIR /src
COPY ["AuctionAdmin/AuctionAdmin.csproj", "AuctionAdmin/"]
RUN dotnet restore "AuctionAdmin/AuctionAdmin.csproj"
COPY . .
WORKDIR "/src/AuctionAdmin"
RUN dotnet build "AuctionAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuctionAdmin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuctionAdmin.dll"]