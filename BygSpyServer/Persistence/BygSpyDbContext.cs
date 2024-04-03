using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyServer.Persistence
{
    public class BygSpyDbContext
    {
        private readonly IMongoDatabase _database;

        public BygSpyDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("YourDatabaseName");
        }

        // Define MongoDB collections for users, roles, etc. if necessary
        // Example:
        // public IMongoCollection<ApplicationUser> Users => _database.GetCollection<ApplicationUser>("Users");
    }

}
