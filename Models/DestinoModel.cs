using System.ComponentModel.DataAnnotations;

namespace AgenciaViagemUp.Models
{
    public class DestinoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
    }
}