FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY COP.API.sln ./
COPY src/COP.API/COP.API.csproj src/COP.API/
RUN dotnet restore src/COP.API/COP.API.csproj 
COPY . .
WORKDIR /src/src/COP.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "COP.API.dll"]
