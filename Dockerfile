FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SentimentAnalysisDemoApi/SentimentAnalysisDemoApi.csproj", "SentimentAnalysisDemoApi/"]
RUN dotnet restore "SentimentAnalysisDemoApi/SentimentAnalysisDemoApi.csproj"
COPY . .
WORKDIR "/src/SentimentAnalysisDemoApi"
RUN dotnet build "SentimentAnalysisDemoApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SentimentAnalysisDemoApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD dotnet SentimentAnalysisDemoApi.dll --urls "http://*:$PORT"