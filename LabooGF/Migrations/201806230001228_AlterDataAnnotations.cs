namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Responsavel", "Endereco", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Responsavel", "Endereço");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Responsavel", "Endereço", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("dbo.Responsavel", "Endereco");
        }
    }
}
