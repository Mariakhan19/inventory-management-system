using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapPost("/product", async (Product product) =>
{
    var client = new MongoClient("mongodb://mongodb:27017");

    var database = client.GetDatabase("inventoryDB");

    var collection = database.GetCollection<BsonDocument>("products");

    var document = new BsonDocument
    {
        { "productName", product.ProductName },
        { "category", product.Category },
        { "quantity", product.Quantity },
        { "price", product.Price }
    };

    await collection.InsertOneAsync(document);

    return Results.Json(new
    {
        message = "Product Saved Successfully"
    });
});

app.Run("http://0.0.0.0:5002");

public class Product
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}