#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ReviewMe/ReviewMe.csproj", "ReviewMe/"]
RUN dotnet restore "ReviewMe/ReviewMe.csproj"
COPY . .
WORKDIR "/src/ReviewMe"
RUN dotnet build "ReviewMe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReviewMe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReviewMe.dll"]