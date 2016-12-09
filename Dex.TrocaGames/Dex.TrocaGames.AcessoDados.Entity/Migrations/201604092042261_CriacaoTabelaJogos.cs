namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaJogos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JOG_JOGOS",
                c => new
                    {
                        JOG_ID = c.Long(nullable: false, identity: true),
                        JOG_NOME = c.String(nullable: false, maxLength: 50),
                        JOG_DATA_LANCAMENTO = c.DateTime(nullable: false),
                        JOG_GENERO = c.Int(nullable: false),
                        JOG_FAIXA_ETARIA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JOG_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JOG_JOGOS");
        }
    }
}
