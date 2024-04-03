// See https://aka.ms/new-console-template for more information
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using AspNetCore.Identity.MongoDbCore.Models;
using BygSpyServer.Persistence.MongoDbUser;
using BygSpyServer.RefitClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Refit;
using System.Configuration;
using MongoDB.Bson;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {


    }).Build();



MongoClient client = new MongoClient("mongodb+srv://khjensenkj:<password>@cluster0.hfvedkb.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

List<string> databases = client.ListDatabaseNames().ToList();

foreach (string database in databases)
{
    Console.WriteLine(database);
}

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
    Environment.Exit(0);
}

//Fast excample to understand connection

//var client = new MongoClient(connectionString);
//var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
//var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
//var document = collection.Find(filter).First();
//Console.WriteLine(document);