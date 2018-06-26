using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }

        [MaxLength(200, ErrorMessage = "O nome deve ter até {1} caracteres.")]
        [Required(ErrorMessage = "Preencha o nome completo.")]
        public string Nome { get; set; }


        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Preencha a data de nascimento.")]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "Responsável")]
        [ForeignKey("Responsavel")]
        [Required(ErrorMessage = "Preencha o Responsável.")] 
        public int IdResponsavel { get; set; }
        
        public virtual Responsavel Responsavel { get; set; }
    }
}