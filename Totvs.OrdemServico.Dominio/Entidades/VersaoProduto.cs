using System;

namespace Totvs.OrdemServico.Dominio.Entidades
{
    /// <summary>
    /// Versão do Produto
    /// 
    /// --Agregação de Produto
    /// </summary>
    public class VersaoProduto
    {
        /// <summary>
        /// Versão do Produto
        /// </summary>
        /// <param name="produto">Produto</param>
        /// <param name="versao">Versão</param>
        public VersaoProduto(Produto produto, Version versao)
        {
            Versao = versao;
            Produto = produto;
        }

        /// <summary>
        /// Id: Código da Versão
        /// </summary>
        public Version Versao { get; set; }

        /// <summary>
        /// Id: Código do Produto
        /// </summary>
        public Produto Produto { get; set; }

        /// <summary>
        /// Código da Versão do produto
        /// </summary>
        public string Codigo()
        {
            return Versao.ToString();
        }
    }
}
