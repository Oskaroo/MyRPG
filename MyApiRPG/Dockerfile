FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyApiRPG/MyApiRPG.csproj", "MyApiRPG/"]
RUN dotnet restore "MyApiRPG/MyApiRPG.csproj"
COPY . .
WORKDIR "/src/MyApiRPG"
RUN dotnet build "MyApiRPG.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApiRPG.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApiRPG.dll"]
