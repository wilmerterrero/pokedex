using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexAPI.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Habilidades { get; set; }
        public int? EntrenadorId { get; set; }
        public virtual Entrenador Entrenador { get; set; }
    }
}
