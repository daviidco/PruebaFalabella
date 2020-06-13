using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ApiFalabella.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        [Required]
        public DateTime FechaReparto { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
        [Required]
        public string CiudadEntrega { get; set; }
        [Required]
        public int IdCliente { get; set; }
    }
}
