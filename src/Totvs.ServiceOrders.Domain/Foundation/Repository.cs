using System;
using System.Linq;
using System.Threading;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Funciona como um mediador entre a cada de dominio e a camada de persistencia para as entidades
    /// </summary>
    public class Repository<TEntity> : IDisposable
        where TEntity : Entity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IQuery _query;
        protected readonly IClock _clock;

        /// <summary>
        /// Repositório
        /// </summary>
        public Repository()
        {
            _unitOfWork = UnitOfWorkManager.GetInstance();
            _query = _unitOfWork.CreateQuery();
            _clock = IoC.Resolve<IClock>();
        }

        /// <summary>
        /// Obtém um unico registro pela especificação indicada
        /// </summary>
        protected TEntity Get(Specification<TEntity> specification)
        {
            var entity = _query.Get(specification);
            return entity;
        }

        /// <summary>
        /// Retorna 'verdadeiro' se a especificação foi satisfeita
        /// </summary>
        protected bool Any(Specification<TEntity> specification)
        {
            var any = _query.Any(specification);
            return any;
        }

        /// <summary>
        /// Obtém todos as entidades em que a especificação foi satisfeita
        /// </summary>
        protected IQueryable<TEntity> GetFrom(Specification<TEntity> specification)
        {
            var entities = _query.GetBySpecification(specification);
            return entities;
        }

        /// <summary>
        /// Insere a entidade 
        /// </summary>
        public virtual void Insert(TEntity entity)
        {
            entity.CreatedAt = entity.ModifiedAt = _clock.GetNow();
            entity.CreatedBy = entity.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;

            _unitOfWork.RegisterInsert(entity);
        }

        /// <summary>
        /// Atualiza a entidade 
        /// </summary>
        public virtual void Update(TEntity entity)
        {
            entity.ModifiedAt = _clock.GetNow();
            entity.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;

            _unitOfWork.RegisterUpdate(entity);
        }

        /// <summary>
        /// Exclui a entidade
        /// </summary>
        public virtual void Delete(TEntity entity)
        {
            _unitOfWork.RegisterDelete(entity);
        }

        /// <summary>
        /// Avisa a unidade de trabalho quanto a não utilização
        /// </summary>
        public void Dispose()
        {
            UnitOfWorkManager.Unregister();
            GC.SuppressFinalize(this);
        }
    }
}
