How run setup

1) run postgres database via docker #docker compose up
2) open folder be/ and run migration #dotnet ef database update --project Macrix.Database --startup-project MacrixPoc
3) build project using Rider/Visual Studio or or uncomment the service macrixpoc into docker-compose.yml and build it again
4) open folder /front/macrix-front-poc and run react project using command #npm install and then #npm start