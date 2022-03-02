using System.ComponentModel.DataAnnotations;

namespace ImagensProjeto.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]  
        public string Nome { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public byte []? Foto { get; set; }


    }
}
