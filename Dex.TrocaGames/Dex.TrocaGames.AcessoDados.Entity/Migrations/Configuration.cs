namespace Dex.TrocaGames.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dex.TrocaGames.AcessoDados.Entity.Context.TrocaGamesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //method to seed baseline table = ie. UF
        protected override void Seed(Dex.TrocaGames.AcessoDados.Entity.Context.TrocaGamesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
