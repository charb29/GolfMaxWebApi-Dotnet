FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app
EXPOSE 8800
ENV ASPNETCORE_URLS=http://*:8800

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY ["GolfMaxWebApi.csproj", "./"]
RUN dotnet restore "GolfMaxWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GolfMaxWebApi.csproj" -c Release -o /app/build

FROM build AS publish 
RUN dotnet publish "GolfMaxWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GolfMaxWebApi.dll"]
