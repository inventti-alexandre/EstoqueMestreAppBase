using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }

        [Required][MaxLength(80)]
        public string RazaoSocial { get; set; }

        [MaxLength(14)]
        public string CNPJ { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
        public virtual List<Produto> produtos { get; set; }
    }
}
