FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Fiap.Hackathon.Worker/Fiap.Hackathon.Worker.csproj", "Fiap.Hackathon.Worker/"]
RUN dotnet restore "Fiap.Hackathon.Worker/Fiap.Hackathon.Worker.csproj"
COPY . .
WORKDIR "/src/Fiap.Hackathon.Worker"
RUN dotnet build "Fiap.Hackathon.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Hackathon.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Hackathon.Worker.dll"]
