using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexAPI.Entities
{
    public class Entrenador
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public virtual List<Pokemon> Pokemones { get; set; }
    }
}
