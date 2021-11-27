using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoConsoleApp.Models
{
    public class TestModel
    {
        public ObjectId _id { get; set; }
        public string _t { get; set; }
        public string _v { get; set; }
    }
}
