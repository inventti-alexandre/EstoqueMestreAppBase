using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }

        [Required][StringLength(80)]
        public string Nome { get; set; }
        
        [StringLength(150)]
        public string Descricao { get; set; }

        [Required]        
        public decimal ValorCompra { get; set; }        

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool EstoqueBaixo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual ICollection<Movimentacao> movimentacoes { get; set; }
    }
}
