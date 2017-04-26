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

        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [StringLength(80)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Emila não é um endereço de email válido..")]        
        public string Email { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Deletado { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public Cliente()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
