using System;
using Totvs.ServiceOrders.Helper;


namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Chamado
    /// </summary>
    public class Ticket : Entity
    {
        private readonly Requestor requestor;
        private readonly ProductVersion productVersion;
        private readonly Incident incident;

        /// <summary>
        /// Identificador do Chamado
        /// </summary>
        public int Id { get; private set; }
        
        
        /// <summary>
        /// Chamado
        /// </summary>
        /// <param name="solicitante">Solicitante</param>
        /// <param name="productVersion">Versão do Produto</param>
        /// <param name="incidente">Incidente</param>
        public Ticket(
            Requestor solicitante,
            ProductVersion productVersion, 
            Incident incidente)
        {
            Check.IsNotNull(solicitante, new ArgumentNullException("solicitante"));
            Check.IsNotNull(productVersion, new ArgumentNullException("versaoProduto"));
            Check.IsNotNull(incidente, new ArgumentNullException("incidente"));

            this.requestor = solicitante;
            this.productVersion = productVersion;
            this.incident = incidente;
            this.Id = 1;
        }
    }
}
