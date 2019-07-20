FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/MatchaLatte.HumanResources.Api/MatchaLatte.HumanResources.Api.csproj", "src/MatchaLatte.HumanResources.Api/"]
RUN dotnet restore "src/MatchaLatte.HumanResources.Api/MatchaLatte.HumanResources.Api.csproj"
COPY . .
WORKDIR "/src/src/MatchaLatte.HumanResources.Api"
RUN dotnet build "MatchaLatte.HumanResources.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MatchaLatte.HumanResources.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MatchaLatte.HumanResources.Api.dll"]