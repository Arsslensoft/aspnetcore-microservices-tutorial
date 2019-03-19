FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["products.csproj", "./"]
RUN dotnet restore "products.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "products.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "products.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "products.dll"]