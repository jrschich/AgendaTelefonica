namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reformulacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Email", "ContatoId", "dbo.Agenda");
            DropForeignKey("dbo.Telefone", "ContatoId", "dbo.Agenda");
            DropIndex("dbo.Email", new[] { "ContatoId" });
            DropIndex("dbo.Telefone", new[] { "ContatoId" });
            AddColumn("dbo.Agenda", "TelefoneCasa", c => c.String());
            AddColumn("dbo.Agenda", "TelefoneTrabalho", c => c.String());
            AddColumn("dbo.Agenda", "TelefoneCelular", c => c.String());
            AddColumn("dbo.Agenda", "TelefoneOutro", c => c.String());
            AddColumn("dbo.Agenda", "EmailParticular", c => c.String());
            AddColumn("dbo.Agenda", "EmailTrabalho", c => c.String());
            AddColumn("dbo.Agenda", "EmailOutro", c => c.String());
            AlterColumn("dbo.Agenda", "Nome", c => c.String());
            DropTable("dbo.Email");
            DropTable("dbo.Telefone");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Agenda", "Nome", c => c.String(nullable: false));
            DropColumn("dbo.Agenda", "EmailOutro");
            DropColumn("dbo.Agenda", "EmailTrabalho");
            DropColumn("dbo.Agenda", "EmailParticular");
            DropColumn("dbo.Agenda", "TelefoneOutro");
            DropColumn("dbo.Agenda", "TelefoneCelular");
            DropColumn("dbo.Agenda", "TelefoneTrabalho");
            DropColumn("dbo.Agenda", "TelefoneCasa");
            CreateIndex("dbo.Telefone", "ContatoId");
            CreateIndex("dbo.Email", "ContatoId");
            AddForeignKey("dbo.Telefone", "ContatoId", "dbo.Agenda", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Email", "ContatoId", "dbo.Agenda", "Id", cascadeDelete: true);
        }
    }
}
