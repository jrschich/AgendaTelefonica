namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Empresa = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(nullable: false),
                        Tipo = c.Int(nullable: false),
                        ContatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.ContatoId, cascadeDelete: true)
                .Index(t => t.ContatoId);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        DDD = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        ContatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.ContatoId, cascadeDelete: true)
                .Index(t => t.ContatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "ContatoId", "dbo.Agenda");
            DropForeignKey("dbo.Email", "ContatoId", "dbo.Agenda");
            DropIndex("dbo.Telefone", new[] { "ContatoId" });
            DropIndex("dbo.Email", new[] { "ContatoId" });
            DropTable("dbo.Telefone");
            DropTable("dbo.Email");
            DropTable("dbo.Agenda");
        }
    }
}
