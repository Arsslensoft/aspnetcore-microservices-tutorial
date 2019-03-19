FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["gateway/gateway.csproj", "gateway/"]
RUN dotnet restore "gateway/gateway.csproj"
COPY . .
WORKDIR "/src/gateway"
RUN dotnet build "gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "gateway.dll"]