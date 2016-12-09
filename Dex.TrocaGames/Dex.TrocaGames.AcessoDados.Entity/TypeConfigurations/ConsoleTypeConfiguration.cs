using Dex.AcessoDados.Comum.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexDominio = Dex.TrocaGames.Dominio;

namespace Dex.TrocaGames.AcessoDados.Entity.TypeConfigurations
{
    class ConsoleTypeConfiguration : DexTypeConfiguration<DexDominio.Console>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("CON_CONSOLES");
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasColumnName("CON_ID")                                            //. interface fluencia
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)       // como será gerado
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("CON_NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.DataLancamento)                                                 //enum vira Int no EF
                .HasColumnName("CON_DATA_LANCAMENTO")
                .IsRequired();
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
           
        }

        protected override void ConfigurarOutrasCoisas()
        {
           
        }
    }
}
