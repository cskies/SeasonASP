namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaProjetor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRO_PROJETOR",
                c => new
                    {
                        PRO_ID = c.Int(nullable: false, identity: true),
                        PRO_NOME = c.String(nullable: false, maxLength: 50),
                        PRO_MARCA = c.String(nullable: false, maxLength: 50),
                        JOG_DATA_COMPRA = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PRO_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PRO_PROJETOR");
        }
    }
}
