How run setup

1) run postgres database via docker #docker compose up
2) run migration #dotnet ef database update --project Macrix.Database --startup-project MacrixPoc
3) build project using Rider/Visual Studio or or uncomment the service macrixpoc into docker-compose.yml and build it again