using System;

namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Incidente
    /// </summary>
    public class Incident : Entity
    {
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incidente
        /// </summary>
        /// <param name="descricao">Descrição</param>
        public Incident(string descricao)
        {
            this.Description = descricao;
        }
    }
}
