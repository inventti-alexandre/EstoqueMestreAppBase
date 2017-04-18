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
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual List<Produto> produtos { get; set; }
    }
}
