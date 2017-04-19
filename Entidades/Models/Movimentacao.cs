using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovimentacao { get; set; }
        
        [StringLength(150)]
        public string Observacao { get; set; }
        
        [DefaultValue(false)]
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
