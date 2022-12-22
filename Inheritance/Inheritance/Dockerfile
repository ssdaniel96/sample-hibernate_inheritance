#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Inheritance/Inheritance.csproj", "Inheritance/"]
RUN dotnet restore "Inheritance/Inheritance.csproj"
COPY . .
WORKDIR "/src/Inheritance"
RUN dotnet build "Inheritance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inheritance.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inheritance.dll"]