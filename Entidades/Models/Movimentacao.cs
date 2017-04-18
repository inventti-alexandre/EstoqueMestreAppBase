using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class Movimentacao
    {
        [Key]
        public int IdMovimentacao { get; set; }
        
        [MaxLength(150)]
        public string Observacao { get; set; }
        public bool Estornada { get; set; }
        
        [Required]
        public char TipoOperacao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
        public int IdCliente { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual Produto produto { get; set; }
    }
}
