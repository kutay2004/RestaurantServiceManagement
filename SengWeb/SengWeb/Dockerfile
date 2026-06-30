FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SengWeb/SengWeb/SengWeb.csproj", "SengWeb/SengWeb/"]
COPY ["SengWeb/SengWeb.Client/SengWeb.Client.csproj", "SengWeb/SengWeb.Client/"]

RUN dotnet restore "SengWeb/SengWeb/SengWeb.csproj"

COPY . .

WORKDIR "/src/SengWeb/SengWeb"
RUN dotnet publish "SengWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "SengWeb.dll"]