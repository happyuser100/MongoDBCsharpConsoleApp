using Microsoft.Extensions.Configuration;
using MongoConsoleApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsoleApp.Repository
{
    public class TestRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<TestModel> _collection;

        public TestRepository(IConfiguration config)
        {
            var mongoDBURL = config.GetSection("MongoDBURL").Value;
            var dbName = config.GetSection("dbName").Value;
            var collectionName = config.GetSection("collectionName").Value;

            _client = new MongoClient(mongoDBURL);
            _database = _client.GetDatabase(dbName);
            _collection = _database.GetCollection<TestModel>(collectionName);
        }

        public TestModel Get(string id)
        {
            var result = new TestModel();
            try
            {
                 result = this._collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstOrDefaultAsync().Result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public TestModel UpdatePost(string id, TestModel testmodel)
        {
            testmodel._id = new ObjectId(id);

            var filter = Builders<TestModel>.Filter.Eq(s => s._id, testmodel._id);
            this._collection.ReplaceOneAsync(filter, testmodel);

            //this._collection.Find( { 'bad' : { $type: 1 } } ).forEach(function(x) {
            //    x.bad = new String(x.bad); // convert field to string
            //    db.foo.save(x);
            //});

            return this.Get(id);
        }
    }
}
