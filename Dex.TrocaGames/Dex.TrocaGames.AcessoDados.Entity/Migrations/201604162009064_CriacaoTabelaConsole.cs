namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaConsole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CON_CONSOLES",
                c => new
                    {
                        CON_ID = c.Int(nullable: false, identity: true),
                        CON_NOME = c.String(nullable: false, maxLength: 50),
                        CON_DATA_LANCAMENTO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CON_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CON_CONSOLES");
        }
    }
}
