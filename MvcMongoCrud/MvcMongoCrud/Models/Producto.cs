using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMongoCrud.Models
{
    public class Producto
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("precio")]
        public int precio { get; set; }
        [BsonElement("imagen")]
        public String imagen { get; set; }
        [BsonElement("descripcion")]
        public String descripcion { get; set; }
        [BsonElement("nombre")]
        public String nombre { get; set; }
        [BsonElement("fecha")]
        public DateTime fecha { get; set; }

    }
}