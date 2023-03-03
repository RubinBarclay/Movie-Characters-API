# Movie Characters API

A movie themed REST API with full CRUD functionality built with ASP.NET and Entity Framework. The API uses Swagger for it's documentation, so please refer to that for a in depth explanation of every endpoint. Otherwise you can use the list of endpoints below as a quick reference. 

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
GET /api/v1/characters
```
#### Get character by id
```
GET /api/v1/characters/<id>
```
#### Create a new character
```
POST /api/v1/characters
```
Example request body
```
{
  "name": "string",
  "alias": "string",
  "gender": "string",
  "pictureUrl": "string"
}
```
#### Update a character
```
PUT /api/v1/characters/<id>
```
Example request body
```
{
  "id": 0,
  "name": "string",
  "alias": "string",
  "gender": "string",
  "pictureUrl": "string"
}
```
#### Delete a character
```
DELETE /api/v1/characters/<id>
```

### Movies
#### Get all movies
```
GET /api/v1/movies
```
#### Get a movie by id
```
GET /api/v1/movies/<id>
```
#### Create a new movie
```
POST /api/v1/movies
```
Example request body
```
{
  "title": "string",
  "genre": "string",
  "year": 0,
  "director": "string",
  "pictureUrl": "string",
  "trailerUrl": "string",
  "franchiseId": 0
}
```
#### Update a movie
```
PUT /api/v1/movies/<id>
```
Example request body
```
{
  "id": 0,
  "title": "string",
  "genre": "string",
  "year": 0,
  "director": "string",
  "pictureUrl": "string",
  "trailerUrl": "string",
  "franchiseId": 0
}
```
#### Update characters in a movie
```
PUT /api/v1/movies/update/<movieid>
```
Example request body
```
{
  [
    0
  ]
}
```
#### Delete a movie
```
DELETE /api/v1/movies/<id>
```

### Franchises
#### Get all franchises
```
GET /api/v1/franchises
```
#### Get franchise by id
```
GET /api/v1/franchises/<id>
```
#### Create a new franchise
```
POST /api/v1/franchises
```
Example request body
```
{
  "name": "string",
  "description": "string"
}
```
#### Update a franchise
```
PUT /api/v1/franchises/<id>
```
Example request body
```
{
  "id": 0,
  "name": "string",
  "description": "string"
}
```
#### Update movies in a franchise
```
PUT /api/v1/franchises/update/<franchiseid>
```
Example request body
```
{
  [
    0
  ]
}
```
#### Delete a franchise
```
DELETE /api/v1/franchises/<id>
```

## License
This project is licensed under the MIT license. See [LICENSE.md](https://github.com/RubinBarclay/Movie-Characters-API/blob/master/LICENSE.md) for more information.
