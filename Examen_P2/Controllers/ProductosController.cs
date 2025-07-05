using Examen_P2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_P2.DTOs;


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
            var lista = await _baseDatos.Products
                .Include(p => p.Categories)
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Categoria = p.Categories.Select(c => c.Name).FirstOrDefault()
                })
                .ToListAsync();

            return Ok(lista);
        }



    }
}
