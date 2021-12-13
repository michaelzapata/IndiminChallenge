#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Indimin.Challenge.Tasking.API/Indimin.Challenge.Tasking.API.csproj", "Indimin.Challenge.Tasking.API/"]
COPY ["Indimin.Challenge.Tasking.Infraestructure/Indimin.Challenge.Tasking.Infraestructure.csproj", "Indimin.Challenge.Tasking.Infraestructure/"]
COPY ["Indimin.Challenge.Tasking.Domain/Indimin.Challenge.Tasking.Domain.csproj", "Indimin.Challenge.Tasking.Domain/"]
RUN dotnet restore "Indimin.Challenge.Tasking.API/Indimin.Challenge.Tasking.API.csproj"
COPY . .
WORKDIR "/src/Indimin.Challenge.Tasking.API"
RUN dotnet build "Indimin.Challenge.Tasking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Indimin.Challenge.Tasking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indimin.Challenge.Tasking.API.dll"]
