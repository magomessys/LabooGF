using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }


        [Display(Name = "Data de Nascimento") ]
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "Responsável")]
        [Required(ErrorMessage = "O campo responsável é obrigatório.")] 
        public Responsavel Responsavel { get; set; }
    }
}