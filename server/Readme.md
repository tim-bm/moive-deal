## Getting Started

Requreiment:

- dotnet 9.0

Run the development environment:

```
# install the dependencies
dotnet restore

# run the dev server
dotnet run 
# or 
dotnet watch

```

Open [http://localhost:8000/swagger/index.html](http://localhost:8000/swagger/index.html) with your browser to view the Open Api Spec for the server


### Generate SDK


```
# 
dotnet tool restore

# Generate the SDK from the upstream movie api
dotnet tool run kiota generate -n MovieDeal.DataSource -c MoiveDataSource -d ./src/DataSource/movie_source.yaml --language csharp -o ./src/DataSource/SDK


# Generate the SDK for the frontend
dotnet tool run kiota generate -l typescript -d http://localhost:8000/swagger/v1/swagger.json -o ./../app/src/sdk -c MovieApiClient

```
