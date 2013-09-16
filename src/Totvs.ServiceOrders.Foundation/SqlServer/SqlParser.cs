using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    public class SqlServerParser<TEntity>
        where TEntity : Entity
    {
        private static readonly DataMapper<TEntity> _dataMapper = 
            new DataMapper<TEntity>();


        public string GenerateSqlUpdate()
        {
            var sql = "UPDATE [TABLE] SET [FIELDS] WHERE [CONDICOES]";
            throw new NotImplementedException();
        }

        public SqlCommand CreateUpdateCommand(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
