#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Indimin.Challenge.BFF/Indimin.Challenge.BFF.csproj", "Indimin.Challenge.BFF/"]
COPY ["Indimin.Challenge.Logging/Indimin.Challenge.Logging.csproj", "Indimin.Challenge.Logging/"]
RUN dotnet restore "Indimin.Challenge.BFF/Indimin.Challenge.BFF.csproj"
COPY . .
WORKDIR "/src/Indimin.Challenge.BFF"
RUN dotnet build "Indimin.Challenge.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Indimin.Challenge.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indimin.Challenge.BFF.dll"]
