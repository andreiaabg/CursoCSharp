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
        private readonly string descricao;

        /// <summary>
        /// Incidente
        /// </summary>
        /// <param name="descricao">Descrição</param>
        public Incident(string descricao)
        {
            this.descricao = descricao;
        }
    }
}
