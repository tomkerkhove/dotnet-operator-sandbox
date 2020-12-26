#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Operator.Sandbox.Runtime/Operator.Sandbox.Runtime.csproj", "Operator.Sandbox.Runtime/"]
RUN dotnet restore "Operator.Sandbox.Runtime/Operator.Sandbox.Runtime.csproj"
COPY . .
WORKDIR "/src/Operator.Sandbox.Runtime"
RUN dotnet build "Operator.Sandbox.Runtime.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Operator.Sandbox.Runtime.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Operator.Sandbox.Runtime.dll"]