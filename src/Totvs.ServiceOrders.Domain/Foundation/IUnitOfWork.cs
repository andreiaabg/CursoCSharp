using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Unidade de Trabalho
    /// </summary>
    public interface IUnitOfWork : IDisposable 
    {
        /// <summary>
        /// Registra a entidade para ser atualizada
        /// </summary>
        void RegisterUpdate<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Registra a entidade para ser inserida
        /// </summary>
        void RegisterInsert<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Registra a entidade para ser excluida
        /// </summary>
        void RegisterDelete<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Confirma as transações
        /// </summary>
        void Commit();

        /// <summary>
        /// Cancela as modificações
        /// </summary>
        void Rollback();

        /// <summary>
        /// Obtém o provedor de leitura
        /// </summary>
        IQuery CreateQuery();
    }
}
