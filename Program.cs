using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json")
               .Build();

            MongoDbOperations mongoDbOperations = new MongoDbOperations(config);
            mongoDbOperations.retrieveAndUpdate("61a2698a7459111e5196ce15", "JobInterview", "TAKE-ME!");
        }

        //static void testAppSettings()
        //{
        //    IConfiguration Config = new ConfigurationBuilder()
        //        .AddJsonFile("appSettings.json")
        //        .Build();

        //    var URL = Config.GetSection("MongoDBURL").Value;
        //    var dbName = Config.GetSection("dbName").Value;
        //    var collectionName = Config.GetSection("collectionName").Value;
        //}

        //static void testMongo()
        //{
        //    MongoClient client = new MongoClient("mongodb://localhost:27017");

        //    var dbList = client.ListDatabases().ToList();

        //    Console.WriteLine("The list of databases on this server is: ");
        //    foreach (var db in dbList)
        //    {
        //        Console.WriteLine(db);
        //    }

        //    var database = client.GetDatabase("foo");
        //    var collection = database.GetCollection<BsonDocument>("bar");

        //    var document = new BsonDocument
        //    {
        //        { "name", "MongoDB" },
        //        { "type", "Database" },
        //        { "count", 1 },
        //        { "info", new BsonDocument
        //            {
        //                { "x", 203 },
        //                { "y", 102 }
        //            }}
        //    };

        //    collection.InsertOne(document);

        //    var document1 = collection.Find(new BsonDocument()).FirstOrDefault();
        //    Console.WriteLine(document1.ToString());
        //    }
    }
}
