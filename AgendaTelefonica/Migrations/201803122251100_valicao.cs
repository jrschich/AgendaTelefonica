namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valicao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agenda", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agenda", "Nome", c => c.String());
        }
    }
}
