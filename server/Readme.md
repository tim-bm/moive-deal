


dotnet tool restore

dotnet tool run kiota generate -n MovieDeal.DataSource -c MoiveDataSource -d ./src/DataSource/movie_source.yaml --language csharp -o ./src/DataSource/SDK


dotnet tool run kiota generate -l typescript -d http://localhost:8000/swagger/v1/swagger.json -o ./../app/src/sdk -c MovieApiClient