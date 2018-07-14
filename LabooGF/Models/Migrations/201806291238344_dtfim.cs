namespace LabooGF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dtfim : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Encontro", "DtEncontroFim", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Encontro", "DtEncontroFim", c => c.DateTime(precision: 0));
        }
    }
}
