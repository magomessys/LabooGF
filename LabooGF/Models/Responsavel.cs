using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Responsavel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        public string Endereço { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}