using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Cliente
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required][MaxLength(80)]
        public string Email { get; set; }

        [Required]        
        public bool Deletado { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Movimentacao> movimentacoes { get; set; }
    }
}
