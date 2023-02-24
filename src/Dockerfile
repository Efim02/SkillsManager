#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SK.Web/SK.Web.csproj", "SK.Web/"]
COPY ["SK.BL/SK.BL.csproj", "SK.BL/"]
COPY ["SK.DB/SK.DB.csproj", "SK.DB/"]
RUN dotnet restore "SK.Web/SK.Web.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SK.Web/SK.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SK.Web/SK.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SK.Web.dll"]

ENV ASPNETCORE_URLS http://*:39754
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 39754