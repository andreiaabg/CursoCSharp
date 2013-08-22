using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Totvs.OrdemServico.Dominio.Entidades;
using Totvs.OrdemServico.Dominio.Fabricas;

namespace Totvs.OrdemServico.Dominio.Teste
{
    /// <summary>
    /// Testes Chamado
    /// </summary>
    [TestClass]
    public class TesteChamado
    {
        /// <summary>
        /// Quando: 
        ///     Ao Criar um Chamado
        /// Devemos:
        ///     Garantir que um identificador válido foi Gerado
        /// </summary>
        [TestMethod]
        public void CriarChamado()
        {
            Solicitante solicitante = new Solicitante("andreia.goncalves");
            Chamado chamado = Criar.Chamado(solicitante, "Classis", "11.90", "Não abre a tela de cadastro de aluno");
            Assert.AreNotEqual(0, chamado.Id);
        }

        /// <summary>
        /// Quando:
        ///     Cadastramos uma Versão do Produto
        /// Devemos:
        ///     Certificar que a versão seja válida
        /// </summary>
        [TestMethod]
        public void ValidarVersaoProduto()
        {
            Produto produto = Criar.Produto("Classis", "11.90");

            VersaoProduto versaoProduto = produto.ObterVersao("11.90");
            Assert.IsNotNull(versaoProduto);
            Assert.AreEqual("11.90", versaoProduto.Codigo());
            Assert.AreEqual(produto, versaoProduto.Produto);
        }

    }
}
