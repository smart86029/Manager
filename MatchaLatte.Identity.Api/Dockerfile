FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY . .
WORKDIR /src/MatchaLatte.Identity.Api
RUN dotnet restore
RUN dotnet publish MatchaLatte.Identity.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MatchaLatte.Identity.Api.dll"]
