using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Especificação
    /// </summary>
    public abstract class Specification<TEntity>
        where TEntity : class 
    {

        /// <summary>
        /// Especificação
        /// </summary>
        protected Specification()
        {
        }

        /// <summary>
        /// Especificação
        /// </summary>
        protected Specification(Expression<Func<TEntity, bool>> satisfiedBy)
        {
            this.SatisfiedBy = satisfiedBy;
        }

        /// <summary>
        /// Espressão
        /// </summary>
        public Expression<Func<TEntity, bool>> SatisfiedBy { get; protected set; }
    }
}
