using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.OrdemServico.Dominio.Entidades;

namespace Totvs.OrdemServico.Dominio.Repositórios
{
    /// <summary>
    /// Repositório: Produtos
    /// </summary>
    public class Produtos
    {

        private readonly List<Produto> produtos = new List<Produto>();

        public Produto Obter(string nome)
        {
            return produtos.Single(p => p.Nome == nome);
        }


        public IEnumerable<Produto> ObterTodos()
        {
            return produtos;
        }

        public void Persistir(Produto produto)
        {
            if (!produtos.Contains(produto))
                produtos.Add(produto);
        }

        public void Excluir(Produto produto)
        {
            if (produtos.Contains(produto))
                produtos.Remove(produto);
        }

        internal bool Existe(string nome)
        {
            return produtos.SingleOrDefault(p => p.Nome == nome) != null;
        }
    }
}
