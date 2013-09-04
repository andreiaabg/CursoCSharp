using System;
using Totvs.ServiceOrders.Helper;


namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Chamado
    /// </summary>
    public class Ticket : Entity
    {
        /// <summary>
        /// Identificador do Chamado
        /// </summary>
        public int Id { get; private set; }
        
        
        /// <summary>
        /// Chamado
        /// </summary>
        /// <param name="requestor">Solicitante</param>
        /// <param name="productVersion">Versão do Produto</param>
        /// <param name="incidente">Incidente</param>
        public Ticket(
            Requestor requestor,
            ProductVersion productVersion, 
            Incident incidente)
        {
            Check.IsNull(requestor, new ArgumentNullException("solicitante"));
            Check.IsNull(productVersion, new ArgumentNullException("versaoProduto"));
            Check.IsNull(incidente, new ArgumentNullException("incidente"));

            Requestor = requestor;
            ProductVersion = productVersion;
            Incident = incidente;
            this.Id = 1;
        }

        public Requestor Requestor { get; set; }
        public ProductVersion ProductVersion { get; set; }
        public Incident Incident {get; set;}
    }
}
