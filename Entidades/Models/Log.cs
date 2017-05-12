using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Application é obrigatório.")]
        [StringLength(100)]
        public string Application { get; set; }

        [Required(ErrorMessage = "O campo Logged é obrigatório.")]
        public DateTime Logged { get; set; }

        [Required(ErrorMessage = "O campo Level é obrigatório.")]
        [StringLength(50)]
        public string Level { get; set; }

        [Required(ErrorMessage = "O campo Message é obrigatório.")]
        public string Message { get; set; }

        [StringLength(250)]
        public string Logger { get; set; }

        public string Callsite { get; set; }

        public string Exception { get; set; }
    }
}
