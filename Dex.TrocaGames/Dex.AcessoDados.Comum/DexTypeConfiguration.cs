using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex.AcessoDados.Comum.Entity
{
    //padrão de criacao p/ .cs de bd para acesso dados
    //TDominio = param generico para criar dominio fixado para configurar

    //classe template... fixa ordem de como deve ser feito o modelo de tabela
    public abstract class DexTypeConfiguration<TDominio> : EntityTypeConfiguration<TDominio>
        where TDominio : class
    {
        public DexTypeConfiguration()
        {
            //all the following methods must be abstract
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();
            ConfigurarOutrasCoisas(); //indices, contraints e a poha toda
        }

        protected abstract void ConfigurarNomeTabela();

        protected abstract void ConfigurarCamposTabela();

        protected abstract void ConfigurarChavePrimaria();

        protected abstract void ConfigurarChavesEstrangeiras();

        protected abstract void ConfigurarOutrasCoisas();
    }
}
