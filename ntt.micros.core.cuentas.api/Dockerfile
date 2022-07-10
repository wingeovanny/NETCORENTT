#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ntt.micros.core.cuentas.api/ntt.micros.core.cuentas.api.csproj", "ntt.micros.core.cuentas.api/"]
COPY ["ntt.micros.core.cuentas.infrastructure/ntt.micros.core.cuentas.infrastructure.csproj", "ntt.micros.core.cuentas.infrastructure/"]
COPY ["ntt.micros.core.cuentas.application/ntt.micros.core.cuentas.application.csproj", "ntt.micros.core.cuentas.application/"]
COPY ["ntt.micros.core.cuentas.domain/ntt.micros.core.cuentas.domain.csproj", "ntt.micros.core.cuentas.domain/"]
RUN dotnet restore "ntt.micros.core.cuentas.api/ntt.micros.core.cuentas.api.csproj"
COPY . .
WORKDIR "/src/ntt.micros.core.cuentas.api"
RUN dotnet build "ntt.micros.core.cuentas.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ntt.micros.core.cuentas.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ntt.micros.core.cuentas.api.dll"]