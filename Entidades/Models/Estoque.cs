using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstoque { get; set; }
        [Required]        
        public decimal Quantidade { get; set; }         
        [Required]
        [DefaultValue(true)]
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
