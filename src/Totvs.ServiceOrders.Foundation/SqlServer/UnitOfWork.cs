using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Foundation;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _sqlConnection;
        private bool isDispose;

        internal static string ConnectionString;

        public UnitOfWork()
        {
            _sqlConnection = new SqlConnection(ConnectionString);
            _sqlConnection.Open();
        }

        ~UnitOfWork()
        {
            Dispose();
        }

        public void RegisterUpdate<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            var parser = new SqlServerParser<TEntity>();
            using (var sqlCommand = parser.CreateUpdateCommand(entity))
            {
                sqlCommand.Connection = _sqlConnection;
                sqlCommand.ExecuteNonQuery();
            }
        }


        private string ObterSqlInsert<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        private string ObterSqlDelete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public void RegisterInsert<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            var sql = ObterSqlInsert(entity);
            using (var sqlCommand = new SqlCommand(sql, _sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void RegisterDelete<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            var sql = ObterSqlDelete(entity);
            using (var sqlCommand = new SqlCommand(sql, _sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
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

        public void Dispose()
        {
            if (isDispose)
            {
                return;
            }
            isDispose = true;
            _sqlConnection.Close();
            GC.SuppressFinalize(this);
        }
    }
}
