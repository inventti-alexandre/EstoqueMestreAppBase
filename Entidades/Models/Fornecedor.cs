using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFornecedor { get; set; }

        [Required]
        [StringLength(80)]
        public string RazaoSocial { get; set; }

        [StringLength(14)]
        public string Cnpj { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}
