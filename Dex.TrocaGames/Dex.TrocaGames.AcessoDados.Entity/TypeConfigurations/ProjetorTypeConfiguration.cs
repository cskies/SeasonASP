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
    class ProjetorTypeConfiguration : DexTypeConfiguration<Projetor>
    {
        protected override void ConfigurarNomeTabela()
        {
            ToTable("PRO_PROJETOR");
        }

        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .HasColumnName("PRO_ID")                                            //. interface fluencia
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)       // como será gerado
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("PRO_NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Marca)                                                 //enum vira Int no EF
                .HasColumnName("PRO_MARCA")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.DataCompra)                                                 //enum vira Int no EF
                .HasColumnName("JOG_DATA_COMPRA")
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
