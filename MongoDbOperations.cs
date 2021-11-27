using Microsoft.Extensions.Configuration;
using MongoConsoleApp.Models;
using MongoConsoleApp.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsoleApp
{
    public class MongoDbOperations
    {
        IConfiguration config;
        public MongoDbOperations(IConfiguration config)
        {
            this.config = config;
        }

        public async Task retrieveAndUpdate(string _id, string _t, string _v)
        {
            try
            {
                TestRepository testRepository = new TestRepository(config);
                TestModel testModel = testRepository.Get(_id);

                TestModel testmodelNew = new TestModel();
                testmodelNew._t = _t;
                testmodelNew._v = _v;
                TestModel testmodelResult = testRepository.UpdatePost(_id, testmodelNew);
                Console.WriteLine($"id={testmodelResult._id} _t={testmodelResult._t} _v={ testmodelResult._v}");
            }
            catch (Exception ex)
            { 
            }
        }

    }
}
