FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["categories.csproj", "./"]
RUN dotnet restore "categories.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "categories.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "categories.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "categories.dll"]