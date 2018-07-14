namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Encontro", "Titulo");
            DropColumn("dbo.Encontro", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Encontro", "Descricao", c => c.String(unicode: false));
            AddColumn("dbo.Encontro", "Titulo", c => c.String(unicode: false));
        }
    }
}
