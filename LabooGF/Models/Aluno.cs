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

        [Display(Name = "Nome")]
        [StringLength(200)]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }


        [Display(Name = "Data de Nascimento") ]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "Responsável")]
        [ForeignKey("Responsavel")]
        [Required(ErrorMessage = "O campo responsável é obrigatório.")] 
        public int IdResponsavel { get; set; }


        public virtual Responsavel Responsavel { get; set; }

    }

}