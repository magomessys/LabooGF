namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapeamentoOneToOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        IdAluno = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        DtNascimento = c.DateTime(nullable: false, precision: 0),
                        IdResponsavel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAluno)
                .ForeignKey("dbo.Responsavel", t => t.IdResponsavel, cascadeDelete: true)
                .Index(t => t.IdResponsavel);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        IdResponsavel = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Endereço = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        Telefone = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdResponsavel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "IdResponsavel", "dbo.Responsavel");
            DropIndex("dbo.Aluno", new[] { "IdResponsavel" });
            DropTable("dbo.Responsavel");
            DropTable("dbo.Aluno");
        }
    }
}
