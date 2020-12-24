using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexAPI.Context;
using PokedexAPI.Entities;

namespace PokedexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrenadoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public EntrenadoresController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrenador>>> Get()
        {
            return await context.Entrenadores.Include(x => x.Pokemones).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetEntrenador")]
        public async Task<ActionResult<Entrenador>> Get(int id)
        {
            var entrenador = await context.Entrenadores.Include(x => x.Pokemones).FirstOrDefaultAsync(x => x.Id == id);

            if(entrenador == null)
            {
                return NotFound();
            }

            return entrenador;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Entrenador entrenador)
        {
            context.Entrenadores.Add(entrenador);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetEntrenador", new { id = entrenador.Id }, entrenador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Entrenador entrenador)
        {
            if (id != entrenador.Id)
            {
                return BadRequest(); //400
            }

            context.Entry(entrenador).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrenador>> Delete(int id)
        {
            var entrenador = await context.Entrenadores.FindAsync(id); ;

            if (entrenador == null)
            {
                return NotFound(); //404
            }

            context.Entrenadores.Remove(entrenador);
            await context.SaveChangesAsync();
            return entrenador;
        }

    }
}
