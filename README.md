# Movie Characters API

A movie themed REST API with full CRUD functionality built with ASP.NET and Entity Framework.

## Running the API
To use the API locally on your machine. First make sure you have .NET 6 installed. Then go ahead and clone the repository using the following command:
```
git clone https://github.com/RubinBarclay/Movie-Characters-API.git
```
Then open the project in your terminal and enter the follwing command:
```
dotnet run --project '.\Movie Characters API'
```

Alternatively you can host the API using a cloud provider or similar services.

## Endpoints
### Characters
#### Get all characters
```
GET /api/v1/Characters
```
#### Get character by id
```
GET /api/v1/Characters/<id>
```
#### Create a new character
```
POST /api/v1/Characters
```
#### Edit a character
```
PUT /api/v1/Characters/<id>
```
#### Delete a character
```
DELETE /api/v1/Characters/<id>
```

### Movies
#### Get all movies
```
GET /api/v1/Movies
```
#### Get a movie by id
```
GET /api/v1/Movies/<id>
```
#### Create a new movie
```
POST /api/v1/Movies
```
#### Edit a movie
```
PUT /api/v1/Movies/<id>
```
#### Delete a movie
```
DELETE /api/v1/Movies/<id>
```

### Franchises
#### Get all franchises
```
GET /api/v1/Franchises
```
#### Get franchise by id
```
GET /api/v1/Franchises/<id>
```
#### Create a new franchise
```
POST /api/v1/Franchises
```
#### Edit a franchise
```
PUT /api/v1/Franchises/<id>
```
#### Delete a franchise
```
DELETE /api/v1/Franchises/<id>
```

## License
This project is licensed under the MIT license. See [LICENSE.md](https://github.com/RubinBarclay/Movie-Characters-API/blob/master/LICENSE.md) for more information.
