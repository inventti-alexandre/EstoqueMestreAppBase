using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required][MaxLength(80)]
        public string Email { get; set; }

        [Required]        
        public bool Deletado { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
