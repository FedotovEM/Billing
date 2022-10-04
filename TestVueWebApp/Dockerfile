FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5600

ENV ASPNETCORE_URLS=http://+:5600

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app
COPY ["TestVueWebApp.csproj", "./"]
RUN dotnet restore "TestVueWebApp.csproj"
COPY . .
WORKDIR "/app/."
RUN dotnet publish "TestVueWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./entrypoint.sh .

CMD ["/bin/bash", "/app/entrypoint.sh"]
