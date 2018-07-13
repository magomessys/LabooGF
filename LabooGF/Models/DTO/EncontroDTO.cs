using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabooGF.Models    
{
    public class EncontroDTO
    {
        public int IdEncontro { get; set; }
        public int IdProfessor { get; set; }
        public int IdAuxiliar { get; set; }
        public int? IdAuxiliar2 { get; set; }

        public string NoProfessor { get; set; }
        public string NoAuxiliar { get; set; }
        public string NoAuxiliar2 { get; set; }

        public string Turma { get; set; } //Enums=>CdTurma

        public DateTime DtEncontro { get; set; } //Salvar Data e Hora do encontro.
        public string DtIni { get; set; }
        public DateTime DtEncontroFim { get; set; }
        public string DtFim { get; set; }

        public string NoTurma =>
            Turma == CdTurma.Rosa ? "Rosa" :
            Turma == CdTurma.Lilas ? "Lilás" :
            Turma == CdTurma.Vermelho ? "Vermelho" :
            Turma == CdTurma.Azul ? "Azul" :
            Turma == CdTurma.VerdeLimao ? "Verde Limão" :
            Turma == CdTurma.VerdeFloresta ? "Verde Floresta" :
            Turma == CdTurma.Laranja ? "Laranja" :
            Turma == CdTurma.Amarelo ? "Amarelo" : "";

        public string Cor =>
            Turma == CdTurma.Rosa ? "#E91E63" :
            Turma == CdTurma.Lilas ? "#9C27B0" :
            Turma == CdTurma.Vermelho ? "#F44336" :
            Turma == CdTurma.Azul ? "#2196F3" :
            Turma == CdTurma.VerdeLimao ? "#CDDC39" :
            Turma == CdTurma.VerdeFloresta ? "#4CAF50" :
            Turma == CdTurma.Laranja ? "#FF5722" :
            Turma == CdTurma.Amarelo ? "#FFEB3B" : "";


    }
}