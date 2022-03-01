using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PruebaMigracion.Models
{
    public partial class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [MaxLength(10)]
        public string Pasaporte { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public int Equipo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public int Estado { get; set; }

        public virtual Equipo EquipoJ { get; set; }
        public virtual Estado EstadoJ { get; set; }
    }
}
