FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5600

ENV ASPNETCORE_URLS=http://+:5600

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["TestVueWebApp.csproj", "./"]
RUN dotnet restore "TestVueWebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TestVueWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestVueWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ["/bin/bash", "/app/entrypoint.sh"]
