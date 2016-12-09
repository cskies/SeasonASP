using Dex.AcessoDados.Comum.Entity;
using Dex.TrocaGames.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.TrocaGames.AcessoDados.Entity.TypeConfigurations
{
    class JogadorTypeConfiguration : DexTypeConfiguration<Jogador>
    {
        protected override void ConfigurarNomeTabela()
        {
            //fluent api
            ToTable("JGR_JOGADORES");
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasColumnName("JGR_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("JGR_NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Sobrenome)
                .HasColumnName("JGR_SOBRENOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Idade)
                .HasColumnName("JGR_IDADE")
                .IsRequired();

            Property(p => p.JogoId)
                .HasColumnName("JOG_ID")
                .IsRequired();

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            //relacionamento bidirecional por padrão (mapear smp na entidade forte)
            //relacionamento sendo feito em JogoTypeConfig no momento   
        }

        protected override void ConfigurarOutrasCoisas()
        {
            //throw new NotImplementedException();
        }
    }
}
