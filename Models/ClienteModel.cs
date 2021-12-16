using System.ComponentModel.DataAnnotations;

namespace AgenciaViagemUp.Models
{
    public class ClienteModel
    {
        [Key]
        [Required]
        public int Id {get;set;}
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}