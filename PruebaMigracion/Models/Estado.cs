using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaMigracion.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Jugadores = new HashSet<Jugador>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}
