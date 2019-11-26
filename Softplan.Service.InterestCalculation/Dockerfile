FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Softplan.Service.InterestCalculation/Softplan.Service.InterestCalculation.csproj", "Softplan.Service.InterestCalculation/"]
RUN dotnet restore "Softplan.Service.InterestCalculation/Softplan.Service.InterestCalculation.csproj"
COPY . .
WORKDIR "/src/Softplan.Service.InterestCalculation"
RUN dotnet build "Softplan.Service.InterestCalculation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.Service.InterestCalculation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.Service.InterestCalculation.dll"]