using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiFalabella.Context;
using ApiFalabella.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFalabella.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        // DC - Inyección de dependencia para la base de datos en el constructor
        public  VentasController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>>Get()
        {
            var ventas = await context.Ventas.ToListAsync();
            return ventas;
        }

        // GET: api/Ventas/CrearVentaGet -  Get retorna un codigo 201
        [HttpGet("CrearVentaGet")]
        public async Task<IActionResult> GetToCreate()
        {
            return StatusCode(201);
        }

        
        // GET: api/Ventas/5
        [HttpGet("{id}", Name = "obtenerVenta")]
        public async Task<ActionResult<Venta>> Get(int id)
        {
            var venta = await context.Ventas.FirstOrDefaultAsync(x => x.Id == id);

            // Si no encontró el Libro
            if (venta is null)
            {
                return NotFound();
            }
            return venta;
        }

        // POST: api/Ventas
        [HttpPost (Name = "CrearVenta")]
        public async Task<ActionResult<Venta>> Post([FromBody] Venta venta)
        {
            await context.Ventas.AddAsync(venta);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerVenta", new { id = venta.Id }, venta);
        }
    }
}
