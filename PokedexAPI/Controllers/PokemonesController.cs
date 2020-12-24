using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PokedexAPI.Context;
using PokedexAPI.Entities;
using PokedexAPI.Models;

namespace PokedexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PokemonesController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> Get()
        {
            return await context.Pokemones.Include(x => x.Entrenador).ToListAsync();
        }
        
        [HttpGet("{id}", Name = "GetPokemon")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            var pokemon = await context.Pokemones.Include(x => x.Entrenador).FirstOrDefaultAsync(x => x.Id == id);

            if (pokemon == null)
            {
                return NotFound(); //404
            }
            return pokemon;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PokemonDTO pokemonFromBody)
        {
            var pokemon = mapper.Map<Pokemon>(pokemonFromBody);
            pokemon.EntrenadorId = null;
            context.Pokemones.Add(pokemon);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetPokemon", new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest(); //400
            }

            context.Entry(pokemon).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pokemon>> Delete(int id)
        {
            var pokemon = await context.Pokemones.FindAsync(id);

            if(pokemon == null)
            {
                return NotFound(); //404
            }

            context.Pokemones.Remove(pokemon);
            await context.SaveChangesAsync();
            return pokemon;
        }
    }
}
