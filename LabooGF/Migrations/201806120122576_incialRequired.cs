namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incialRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Aluno", "Responsavel_Id", "Responsavel");
            DropIndex("Aluno", new[] { "Responsavel_Id" });
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Aluno", "Responsavel_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Responsavel", "Nome", c => c.String(nullable: false, unicode: false));
            CreateIndex("dbo.Aluno", "Responsavel_Id");
            AddForeignKey("dbo.Aluno", "Responsavel_Id", "dbo.Responsavel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Aluno", "Responsavel_Id", "Responsavel");
            DropIndex("Aluno", new[] { "Responsavel_Id" });
            AlterColumn("dbo.Responsavel", "Nome", c => c.String(unicode: false));
            AlterColumn("dbo.Aluno", "Responsavel_Id", c => c.Int());
            AlterColumn("dbo.Aluno", "Nome", c => c.String(unicode: false));
            CreateIndex("dbo.Aluno", "Responsavel_Id");
            AddForeignKey("dbo.Aluno", "Responsavel_Id", "dbo.Responsavel", "Id");
        }
    }
}
