using System;

namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Entidade
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Identificador único da entidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Criado por
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Data da Criação
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Modificado por
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Data da modificação
        /// </summary>
        public DateTime ModifiedAt { get; set; }
    }
}
