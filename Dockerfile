FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InvestAPI/InvestAPI.csproj", "InvestAPI/"]
RUN dotnet restore "InvestAPI/InvestAPI.csproj"
COPY . .
WORKDIR "/src/InvestAPI"
RUN dotnet build "InvestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet InvestAPI.dll