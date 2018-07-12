using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabooGF.Models
{
    public class Encontro
    {
        [Key]
        public int IdEncontro { get; set; }
        
        [RegularExpression("(ROSA|LILAS|VERMELHO|AZUL|VERDE-LIMAO|VERDE-FLORESTA|LARANJA|AMARELO)", ErrorMessage = "Informe uma turma válida.")]
        [Required(ErrorMessage = "Informe a turma.")]
        public string Turma { get; set; } //Enums=>CdTurma

        [Display(Name = "Professor")]
        [ForeignKey("Professor")]
        [Required(ErrorMessage = "Informe o professor.")]
        public int IdProfessor { get; set; }

        [Display(Name = "Auxiliar")]
        [ForeignKey("Auxiliar")]
        [Required(ErrorMessage = "Informe o auxiliar.")]
        public int IdAuxiliar { get; set; }

        [Display(Name = "Segundo auxiliar")]
        [ForeignKey("Auxiliar2")]
        public int? IdAuxiliar2 { get; set; }

        [Display(Name = "Data Encontro")]
        [Required(ErrorMessage = "Preencha a data/hora do encontro.")]
        public DateTime DtEncontro { get; set; } //Salvar Data e Hora do encontro.

        public DateTime DtEncontroFim { get; set; }

        public virtual Voluntario Professor { get; set; }

        public virtual Voluntario Auxiliar { get; set; }

        public virtual Voluntario Auxiliar2 { get; set; }

        public virtual ICollection<EncontroParticipante> Participantes { get; set; }

        [NotMapped]
        public string NoTurma =>
            Turma == CdTurma.Rosa           ? "Rosa" :
            Turma == CdTurma.Lilas          ? "Lilás" :
            Turma == CdTurma.Vermelho       ? "Vermelho" :
            Turma == CdTurma.Azul           ? "Azul" :
            Turma == CdTurma.VerdeLimao     ? "Verde Limão" :
            Turma == CdTurma.VerdeFloresta  ? "Verde Floresta" :
            Turma == CdTurma.Laranja        ? "Laranja" :
            Turma == CdTurma.Amarelo        ? "Amarelo" : "";

    }
}