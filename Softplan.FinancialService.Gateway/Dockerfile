FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Softplan.FinancialService.Gateway/Softplan.FinancialService.Gateway.csproj", "Softplan.FinancialService.Gateway/"]
RUN dotnet restore "Softplan.FinancialService.Gateway/Softplan.FinancialService.Gateway.csproj"
COPY . .
WORKDIR "/src/Softplan.FinancialService.Gateway"
RUN dotnet build "Softplan.FinancialService.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.FinancialService.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.FinancialService.Gateway.dll"]