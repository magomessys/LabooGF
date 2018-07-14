namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Login = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                        Permissao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
