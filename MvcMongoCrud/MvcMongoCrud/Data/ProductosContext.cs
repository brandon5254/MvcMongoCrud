using MongoDB.Driver;
using MvcMongoCrud.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMongoCrud.Data
{
    public class ProductosContext
    {
        public MongoClient client;

        public ProductosContext(IConfiguration configuration)
        {
            this.client = new MongoClient(configuration.GetConnectionString("cadenamongodb"));
        }

    }
}