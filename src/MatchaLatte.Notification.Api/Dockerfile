FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/MatchaLatte.Notification.Api/MatchaLatte.Notification.Api.csproj", "src/MatchaLatte.Notification.Api/"]
RUN dotnet restore "src/MatchaLatte.Notification.Api/MatchaLatte.Notification.Api.csproj"
COPY . .
WORKDIR "/src/src/MatchaLatte.Notification.Api"
RUN dotnet build "MatchaLatte.Notification.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MatchaLatte.Notification.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MatchaLatte.Notification.Api.dll"]