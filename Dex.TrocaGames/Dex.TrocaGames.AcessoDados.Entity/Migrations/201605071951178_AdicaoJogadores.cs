namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoJogadores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JGR_JOGADORES",
                c => new
                    {
                        JGR_ID = c.Int(nullable: false, identity: true),
                        JGR_NOME = c.String(nullable: false, maxLength: 50),
                        JGR_SOBRENOME = c.String(nullable: false, maxLength: 50),
                        JGR_IDADE = c.Int(nullable: false),
                        JOG_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.JGR_ID)
                .ForeignKey("dbo.JOG_JOGOS", t => t.JOG_ID, cascadeDelete: true)
                .Index(t => t.JOG_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JGR_JOGADORES", "JOG_ID", "dbo.JOG_JOGOS");
            DropIndex("dbo.JGR_JOGADORES", new[] { "JOG_ID" });
            DropTable("dbo.JGR_JOGADORES");
        }
    }
}
