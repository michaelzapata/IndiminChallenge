#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Indimin.Challenge.Citizens.API/Indimin.Challenge.Citizens.API.csproj", "Indimin.Challenge.Citizens.API/"]
COPY ["Indimin.Challenge.Logging/Indimin.Challenge.Logging.csproj", "Indimin.Challenge.Logging/"]
RUN dotnet restore "Indimin.Challenge.Citizens.API/Indimin.Challenge.Citizens.API.csproj"
COPY . .
WORKDIR "/src/Indimin.Challenge.Citizens.API"
RUN dotnet build "Indimin.Challenge.Citizens.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Indimin.Challenge.Citizens.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indimin.Challenge.Citizens.API.dll"]
