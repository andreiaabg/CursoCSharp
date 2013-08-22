using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.OrdemServico.Dominio.Entidades;
using Totvs.OrdemServico.Dominio.Excecoes;
using Totvs.OrdemServico.Dominio.Repositórios;
using Totvs.OrdemServico.Dominio.Util;

namespace Totvs.OrdemServico.Dominio.Fabricas
{
    /// <summary>
    /// Factories: Produtos
    /// </summary>
    public static class Criar
    {
        /// <summary>
        /// Cria um Produto
        /// </summary>
        public static Produto Produto(string nome, 
            params string[] codigosVersoes)
        {
            Produtos produtos = new Produtos();
            Checar.Falso(produtos.Existe(nome), new ProdutoJaExiste(nome));

            List<VersaoProduto> versoes = new List<VersaoProduto>();
            Produto produto = new Produto(nome, versoes);
            foreach (string codigoVersao in codigosVersoes)
            {
                Version version = Version.Parse(codigoVersao);
                VersaoProduto versaoProduto = new VersaoProduto(produto, version);
                versoes.Add(versaoProduto);
            }
            return produto;
        }

        /// <summary>
        /// Cria um chamado
        /// </summary>
        public static Chamado Chamado(Solicitante solicitante,
            string nomeProduto,
            string codigoVersao,
            string descricaoIncidente)
        {
            Produtos produtos = new Produtos();
            Produto produto = produtos.Obter(nomeProduto);
            VersaoProduto versaoProduto = produto.ObterVersao(codigoVersao);

            Incidente incidente = new Incidente(descricaoIncidente);
            Chamado chamado = new Chamado(solicitante,
                versaoProduto,
                incidente);
            return chamado;
        }

    }
}
