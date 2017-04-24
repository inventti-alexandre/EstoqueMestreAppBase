using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
        
        [Required][StringLength(80)]
        public string Email { get; set; }

        [Required]        
        public bool Deletado { get; set; }

        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Movimentacao> movimentacoes { get; set; }

        public Cliente(){
            this.DataCadastro = DateTime.Now;
        }
    }
}
