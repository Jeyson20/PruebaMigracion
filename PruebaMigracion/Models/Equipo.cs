using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PruebaMigracion.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Jugadores = new HashSet<Jugador>();
        }
        [Key]
        public int IdEquipo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}
