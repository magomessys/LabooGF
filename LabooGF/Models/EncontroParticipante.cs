using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class EncontroParticipante
    {
        [Key]
        public int IdParticipante { get; set; }

        [Display(Name = "Aluno")]
        [ForeignKey("Aluno")]
        [Required(ErrorMessage = "Informe o Aluno.")]
        public int IdAluno { get; set; }

        [Display(Name = "Encontro")]
        [ForeignKey("Encontro")]
        [Required(ErrorMessage = "Encontro não informado.")]
        public int IdEncontro { get; set; }

        [Display(Name = "Número Identificação")]
        public int? NrIdentificacao { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Encontro Encontro { get; set; } 
    }
}