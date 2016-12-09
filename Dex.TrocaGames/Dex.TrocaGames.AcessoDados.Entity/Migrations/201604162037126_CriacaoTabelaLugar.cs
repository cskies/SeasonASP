namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaLugar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LUG_LUGAR",
                c => new
                    {
                        LUG_ID = c.Int(nullable: false, identity: true),
                        LUG_ENDERECO = c.String(nullable: false, maxLength: 150),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.LUG_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LUG_LUGAR");
        }
    }
}
