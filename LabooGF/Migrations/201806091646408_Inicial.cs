namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        DtNascimento = c.DateTime(nullable: false, precision: 0),
                        Responsavel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Responsavel", t => t.Responsavel_Id)
                .Index(t => t.Responsavel_Id);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Endereço = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Responsavel_Id", "dbo.Responsavel");
            DropIndex("dbo.Aluno", new[] { "Responsavel_Id" });
            DropTable("dbo.Responsavel");
            DropTable("dbo.Aluno");
        }
    }
}
