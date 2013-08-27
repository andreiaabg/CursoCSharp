using System;


namespace Totvs.ServiceOrders.Domain.Entities
{
    /// <summary>
    /// Solicitante
    /// </summary>
    public class Requestor : Entity
    {
        /// <summary>
        /// Id: Nome do Usuário
        /// </summary>
        public string UserName { get; set;}

        /// <summary>
        /// Solicitante
        /// </summary>
        /// <param name="userName">Nome do Usuário</param>
        public Requestor(string userName)
        {
            this.UserName = userName;
        }
    }
}
