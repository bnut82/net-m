FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MacrixPoc/MacrixPoc.csproj", "MacrixPoc/"]
COPY ["MacrixPoc.User.Contracts/MacrixPoc.User.Contracts.csproj", "MacrixPoc.User.Contracts/"]
COPY ["MacrixPoc.User.Model/MacrixPoc.User.Model.csproj", "MacrixPoc.User.Model/"]
COPY ["Macrix.Database/Macrix.Database.csproj", "Macrix.Database/"]
COPY ["MacrixPoc.User.Application/MacrixPoc.User.Application.csproj", "MacrixPoc.User.Application/"]
COPY ["MacrixPoc.User.Infrastructure.Repository/MacrixPoc.User.Infrastructure.Repository.csproj", "MacrixPoc.User.Infrastructure.Repository/"]
RUN dotnet restore "MacrixPoc/MacrixPoc.csproj"
COPY . .
WORKDIR "/src/MacrixPoc"
RUN dotnet build "MacrixPoc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MacrixPoc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MacrixPoc.dll"]
