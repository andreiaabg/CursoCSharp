using System;
using Totvs.OrdemServico.Dominio.Util;


namespace Totvs.OrdemServico.Dominio.Entidades
{
    /// <summary>
    /// Chamado
    /// </summary>
    public class Chamado
    {
        /// <summary>
        /// Identificador do Chamado
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Solicitante
        /// </summary>
        private readonly Solicitante solicitante;
        
        /// <summary>
        /// Versão do produto
        /// </summary>
        private readonly VersaoProduto versaoProduto;
        
        /// <summary>
        /// Incidente
        /// </summary>
        private readonly Incidente incidente;

        /// <summary>
        /// Chamado
        /// </summary>
        /// <param name="solicitante">Solicitante</param>
        /// <param name="versaoProduto">Versão do Produto</param>
        /// <param name="incidente">Incidente</param>
        public Chamado(Solicitante solicitante,
            VersaoProduto versaoProduto, 
            Incidente incidente)
        {
            Checar.NaoNulo(solicitante, new ArgumentNullException("solicitante"));
            Checar.NaoNulo(versaoProduto, new ArgumentNullException("versaoProduto"));
            Checar.NaoNulo(incidente, new ArgumentNullException("incidente"));

            this.solicitante = solicitante;
            this.versaoProduto = versaoProduto;
            this.incidente = incidente;
            this.Id = 1;
        }
    }
}
