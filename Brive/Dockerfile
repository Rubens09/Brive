#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Brive/Brive.csproj", "Brive/"]
RUN dotnet restore "Brive/Brive.csproj"
COPY . .
WORKDIR "/src/Brive"
RUN dotnet build "Brive.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brive.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brive.dll"]