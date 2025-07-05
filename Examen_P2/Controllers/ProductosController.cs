using Examen_P2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        // Variables para el contexto
        private readonly ParcialDbContext _baseDatos;
        public ProductosController(ParcialDbContext baseDatos)
        {
            _baseDatos = baseDatos;
        }


        // Creamos le metodo GET devolver los datos:
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Lista()
        {
            var listaProductos = await _baseDatos.Products.ToListAsync();
            return Ok(listaProductos);
        }

    }
}
