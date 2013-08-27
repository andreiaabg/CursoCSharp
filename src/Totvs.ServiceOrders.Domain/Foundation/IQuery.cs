using System;
using System.Linq;
using System.Linq.Expressions;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Domain.Foundation
{
    /// <summary>
    /// Leituras da Camada de Persistencia
    /// </summary>
    public interface IQuery
    {
        /// <summary>
        /// Retorna 'verdadeiro' se a especificação foi satisfeita
        /// </summary>
        bool Any<TEntity>(Specification<TEntity> specification) where TEntity : Entity;

        /// <summary>
        /// Obtém um unico registro pela especificação indicada
        /// </summary>
        TEntity Get<TEntity>(Specification<TEntity> specification) where TEntity : Entity;

        /// <summary>
        /// Obtém todos as entidades em que a especificação foi satisfeita
        /// </summary>
        IQueryable<TEntity> GetBySpecification<TEntity>(Specification<TEntity> specification) where TEntity : Entity;

        /// <summary>
        /// Obtém todos os registros
        /// </summary>
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : Entity;
    }
}
