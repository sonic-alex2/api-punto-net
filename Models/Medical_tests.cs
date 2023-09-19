using System.ComponentModel.DataAnnotations;

namespace Api_v1.Models
{
    public class Medical_tests
    {
        [Key]
        public int id { get; set; }

        public string? nombre { get; set; }

        public string? tipo { get; set; }

        public decimal? costo { get; set; }

        public string? tiempo_resultado { get; set;}
    }
}
