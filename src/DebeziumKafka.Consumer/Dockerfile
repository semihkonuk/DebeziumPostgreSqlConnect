FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DebeziumKafka.Consumer/DebeziumKafka.Consumer.csproj", "src/DebeziumKafka.Consumer/"]
RUN dotnet restore "src/DebeziumKafka.Consumer/DebeziumKafka.Consumer.csproj"
COPY . .
WORKDIR "/src/src/DebeziumKafka.Consumer"
RUN dotnet build "DebeziumKafka.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DebeziumKafka.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DebeziumKafka.Consumer.dll"]