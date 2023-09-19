using System.ComponentModel.DataAnnotations;

namespace Api_v1.Models
{
    public class Patient
    {
        [Key]
        public int id { get; set; }

        public string? nombre { get; set; }

        public int? edad { get; set; }

        public string? genero { get; set; }

        public DateTime? fecha_ingreso { get; set;}
    }
}
