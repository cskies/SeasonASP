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
    //*************** CONFIG VIA FLUENT API, however is necessary register typeConfigs on EF (on DBContext)
    //internal = somente camada de acesso a dados enxerga
    class JogoTypeConfiguration : DexTypeConfiguration<Jogo>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("JOG_JOGOS"); //method used to name table
        }

        protected override void ConfigurarCamposTabela()
        {
            //func = lambda
            Property(p => p.Id)
                .HasColumnName("JOG_ID")                                            //. interface fluencia
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)       // como será gerado
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("JOG_NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Genero)                                                 //enum vira Int no EF
                .HasColumnName("JOG_GENERO")
                .IsRequired();

            Property(p => p.FaixaEtaria)                                                 //enum vira Int no EF
                .HasColumnName("JOG_FAIXA_ETARIA")
                .IsRequired();

            Property(p => p.DataLancamento)                                                 //enum vira Int no EF
                .HasColumnName("JOG_DATA_LANCAMENTO")
                .IsRequired();
                
        }

        protected override void ConfigurarChavePrimaria()
        {
            //id eh PK
            HasKey(pk => pk.Id);
        }

        //there's no foreign key yet
        protected override void ConfigurarChavesEstrangeiras() 
        {
            //relacionamento bidirecional por padrão (mapear smp na entidade forte)
            HasMany(p => p.Jogadores)
                .WithRequired(p => p.Jogo)
                .HasForeignKey(fk => fk.JogoId);
        }

        //nothing to do
        protected override void ConfigurarOutrasCoisas() 
        {
            
        }
    }
}
