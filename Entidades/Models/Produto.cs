using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required][MaxLength(80)]
        public string Nome { get; set; }
        
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required]        
        public decimal ValorCompra { get; set; }        

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public bool EstoqueBaixo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
    }
}
