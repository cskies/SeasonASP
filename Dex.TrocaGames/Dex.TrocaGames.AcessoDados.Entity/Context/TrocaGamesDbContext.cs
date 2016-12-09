using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dex.TrocaGames.Dominio;
using Dex.TrocaGames.AcessoDados.Entity.TypeConfigurations;
using DexDominio = Dex.TrocaGames.Dominio;


namespace Dex.TrocaGames.AcessoDados.Entity.Context
{
    public class TrocaGamesDbContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<DexDominio.Console> Consoles { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<Projetor> Projetores { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        public TrocaGamesDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //**commented bellow to avoid Default CreatingModel
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new JogoTypeConfiguration());
            modelBuilder.Configurations.Add(new ConsoleTypeConfiguration());
            modelBuilder.Configurations.Add(new LugarTypeConfiguration());
            modelBuilder.Configurations.Add(new ProjetorTypeConfiguration());
            modelBuilder.Configurations.Add(new JogadorTypeConfiguration());
        }
    }
}
