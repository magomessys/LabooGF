namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class encontrosCalendario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encontro",
                c => new
                    {
                        IdEncontro = c.Int(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        Turma = c.String(nullable: false, unicode: false),
                        IdProfessor = c.Int(nullable: false),
                        IdAuxiliar = c.Int(nullable: false),
                        IdAuxiliar2 = c.Int(),
                        DtEncontro = c.DateTime(nullable: false, precision: 0),
                        DtEncontroFim = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.IdEncontro)
                .ForeignKey("dbo.Voluntario", t => t.IdAuxiliar, cascadeDelete: true)
                .ForeignKey("dbo.Voluntario", t => t.IdAuxiliar2)
                .ForeignKey("dbo.Voluntario", t => t.IdProfessor, cascadeDelete: true)
                .Index(t => t.IdProfessor)
                .Index(t => t.IdAuxiliar)
                .Index(t => t.IdAuxiliar2);
            
            CreateTable(
                "dbo.EncontroParticipante",
                c => new
                    {
                        IdParticipante = c.Int(nullable: false, identity: true),
                        IdAluno = c.Int(nullable: false),
                        IdEncontro = c.Int(nullable: false),
                        NrIdentificacao = c.Int(),
                    })
                .PrimaryKey(t => t.IdParticipante)
                .ForeignKey("dbo.Aluno", t => t.IdAluno, cascadeDelete: true)
                .ForeignKey("dbo.Encontro", t => t.IdEncontro, cascadeDelete: true)
                .Index(t => t.IdAluno)
                .Index(t => t.IdEncontro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Encontro", "IdProfessor", "dbo.Voluntario");
            DropForeignKey("dbo.EncontroParticipante", "IdEncontro", "dbo.Encontro");
            DropForeignKey("dbo.EncontroParticipante", "IdAluno", "dbo.Aluno");
            DropForeignKey("dbo.Encontro", "IdAuxiliar2", "dbo.Voluntario");
            DropForeignKey("dbo.Encontro", "IdAuxiliar", "dbo.Voluntario");
            DropIndex("dbo.EncontroParticipante", new[] { "IdEncontro" });
            DropIndex("dbo.EncontroParticipante", new[] { "IdAluno" });
            DropIndex("dbo.Encontro", new[] { "IdAuxiliar2" });
            DropIndex("dbo.Encontro", new[] { "IdAuxiliar" });
            DropIndex("dbo.Encontro", new[] { "IdProfessor" });
            DropTable("dbo.EncontroParticipante");
            DropTable("dbo.Encontro");
        }
    }
}
