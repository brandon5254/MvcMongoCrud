using Microsoft.AspNetCore.Mvc;
using MvcMongoCrud.Models;
using MvcMongoCrud.Repositories;



namespace MvcMongoCrud.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryProductos repo;

        public HomeController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Producto> productos = this.repo.getProductos();

            if (productos.Count == 0)
            {
                ViewBag.mensaje = "No hay productos en la base de datos";
                return View();
            }
            else
            {
                return View(productos);
            }
        }

        public IActionResult InsertarProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertarProducto(String nombre, String descripcion, int precio, String imagen)
        {
            this.repo.InsertProducto(nombre, imagen, descripcion, precio);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(String id)
        {
            Producto p = this.repo.findProducto(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Editar(String id, String nombre, String descripcion, int precio, String imagen)
        {
            Producto p = this.repo.findProducto(id);
            p.nombre = nombre;
            p.descripcion = descripcion;
            p.precio = precio;
            p.imagen = imagen;

            this.repo.UpdateProducto(p);

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(String id)
        {
            this.repo.DeleteProducto(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}