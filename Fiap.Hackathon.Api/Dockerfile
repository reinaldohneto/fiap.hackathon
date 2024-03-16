FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Fiap.Hackathon.Api/Fiap.Hackathon.Api.csproj", "Fiap.Hackathon.Api/"]
RUN dotnet restore "Fiap.Hackathon.Api/Fiap.Hackathon.Api.csproj"
COPY . .
WORKDIR "/src/Fiap.Hackathon.Api"
RUN dotnet build "Fiap.Hackathon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Hackathon.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Hackathon.Api.dll"]
