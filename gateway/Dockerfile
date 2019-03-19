FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["gateway.csproj", "./"]
RUN dotnet restore "gateway.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "gateway.dll"]