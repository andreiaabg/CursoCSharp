using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.OrdemServico.Domain.Foundation;

namespace Totvs.OrdemServico.Infraestrutura.EntityFramework
{
    public class AppContext : DbContext, IQuery, IUnitOfWork
    {
        public AppContext() :
            base("ContextoTrabalho")
        {
        }

        /// <summary>
        /// Mapeamento do Modelo
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public bool Any<TEntity>(Specification<TEntity> specification) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public TEntity Get<TEntity>(Specification<TEntity> specification) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetBySpecification<TEntity>(Specification<TEntity> specification) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public void RegisterUpdate<TEntity>(TEntity entity) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public void RegisterInsert<TEntity>(TEntity entity) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public void RegisterDelete<TEntity>(TEntity entity) where TEntity : ServiceOrders.Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public IQuery CreateQuery()
        {
            throw new NotImplementedException();
        }
    }
}
