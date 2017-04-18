using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }        
        public decimal ValorCompra { get; set; }        
        public decimal ValorVenda { get; set; }
        public bool Ativo { get; set; }
        public bool EstoqueBaixo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdFornecedor { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
    }
}
