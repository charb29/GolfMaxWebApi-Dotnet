FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
COPY . /app
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /
WORKDIR /
COPY ["GolfMaxWebApi.csproj", "GolfMaxWebApi/"]
RUN dotnet restore 

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
ENTRYPOINT ["dotnet", "GolfMaxWebApi.dll"]