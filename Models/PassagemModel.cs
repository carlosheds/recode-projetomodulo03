using System.ComponentModel.DataAnnotations;

namespace AgenciaViagemUp.Models
{
    public class PassagemModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClienteModelId {get;set;}
        public ClienteModel ClienteModel { get; set; }
        [Required]
        public int DestinoModelId { get; set; }
        public DestinoModel DestinoModel { get; set; }
        [Required]
        public double Preco { get; set; }
    }
}