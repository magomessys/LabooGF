namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEntityVoluntario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voluntario",
                c => new
                    {
                        IdVoluntario = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Endereco = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        Telefone = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdVoluntario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voluntario");
        }
    }
}
