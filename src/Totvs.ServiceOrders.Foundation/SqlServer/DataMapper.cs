using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    public class DataMapper<TEntity>
    {
        public string TableName { get; set; }


        public DataMapper<TEntity> Table(string tableName)
        {
            TableName = tableName;
            return this;
        }

        public DataMapper<TEntity> Column(Expression<Func<TEntity, object>> property, string column)
        {
            var name =  property.Name;
            return this;
        }
    }
}
