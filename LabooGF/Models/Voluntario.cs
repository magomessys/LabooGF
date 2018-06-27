using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Voluntario
    {
        [Key]
        public int IdVoluntario { get; set; }

        [Required(ErrorMessage = "Preencha o nome completo.")]
        [MaxLength(200, ErrorMessage = "O nome deve ter até {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "O endereço deve ter até {1} caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [StringLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

    }
}