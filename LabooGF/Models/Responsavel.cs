using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Responsavel
    {
        [Key]
        public int IdResponsavel { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Endereço { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }
        
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}