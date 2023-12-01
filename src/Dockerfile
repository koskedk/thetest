FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["thetest/src/TheTest/TheTest.csproj", "thetest/src/TheTest/"]
COPY ["servicea/src/TheTest.ServiceA/TheTest.ServiceA.csproj", "servicea/src/TheTest.ServiceA/"]
COPY ["serviceb/src/TheTest.ServiceB/TheTest.ServiceB.csproj", "serviceb/src/TheTest.ServiceB/"]
RUN dotnet restore "thetest/src/TheTest/TheTest.csproj"
COPY . .
WORKDIR "/src/thetest/src/TheTest"
RUN dotnet build "TheTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheTest.dll"]
