using System;
using System.Collections.Generic;
using System.Linq;

namespace Totvs.OrdemServico.Dominio.Entidades
{
    /// <summary>
    /// Entidade: Produto
    /// -- Identificar
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Versões
        /// </summary>
        private readonly IEnumerable<VersaoProduto> versoes;

        /// <summary>
        /// Id: Nome
        /// </summary>
        public string Nome { get; set; }
        
        /// <summary>
        /// Produto
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        internal Produto(string nome, IEnumerable<VersaoProduto> versoes)
        {
            this.versoes = versoes;
            this.Nome = nome;
        }

        /// <summary>
        /// Obtém a Versão do Produto pelo Código
        /// </summary>
        public VersaoProduto ObterVersao(string codigoVersao)
        {
            return versoes.SingleOrDefault(v => v.Versao.ToString().Equals(codigoVersao));
        }

    }
}
