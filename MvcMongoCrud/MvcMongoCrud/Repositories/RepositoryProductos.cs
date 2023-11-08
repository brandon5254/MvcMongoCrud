using MongoDB.Bson;
using MongoDB.Driver;
using MvcMongoCrud.Data;
using MvcMongoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMongoCrud.Repositories
{
    public class RepositoryProductos
    {
        private ProductosContext context;

        public RepositoryProductos(ProductosContext context)
        {
            this.context = context;
        }

        public List<Producto> getProductos()
        {
            var consulta = this.context.client.GetDatabase("Productos").GetCollection<Producto>("Productos").AsQueryable();

            return consulta.ToList();
        }


        public Producto findProducto(String id)
        {
            Producto p = this.context.client.GetDatabase("Productos").GetCollection<Producto>("Productos").Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstOrDefault();

            return p;

        }

        public void UpdateProducto(Producto p)
        {
            var filter = Builders<Producto>.Filter.Eq(x => x._id, p._id);

            this.context.client.GetDatabase("Productos").GetCollection<Producto>("Productos").ReplaceOne(filter, p);
        }

        public void DeleteProducto(String id)
        {

            var filter = Builders<Producto>.Filter.Eq(x => x._id, new ObjectId(id));
            this.context.client.GetDatabase("Productos").GetCollection<Producto>("Productos").DeleteOne(filter);
        }

        public void InsertProducto(String nombre, String imagen, String descripcion, int precio)
        {
            Producto p = new Producto();
            p.nombre = nombre;
            p.descripcion = descripcion;
            p.imagen = imagen;
            p.precio = precio;
            p._id = ObjectId.GenerateNewId();
            p.fecha = DateTime.UtcNow;

            this.context.client.GetDatabase("Productos").GetCollection<Producto>("Productos").InsertOne(p);
        }
    }
}