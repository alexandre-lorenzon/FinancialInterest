FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Softplan.Service.Interest/Softplan.Service.Interest.csproj", "Softplan.Service.Interest/"]
RUN dotnet restore "Softplan.Service.Interest/Softplan.Service.Interest.csproj"
COPY . .
WORKDIR "/src/Softplan.Service.Interest"
RUN dotnet build "Softplan.Service.Interest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.Service.Interest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.Service.Interest.dll"]