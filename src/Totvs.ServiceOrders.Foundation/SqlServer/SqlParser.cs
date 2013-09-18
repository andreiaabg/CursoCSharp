using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public SqlCommand CreateUpdateCommand(TEntity entity)
        {
            var sqlCommand = new SqlCommand();

            var dataMapper = DataMapper<TEntity>.Instance;
            var stringBuilder = new StringBuilder()
                .Append("UPDATE ")
                .Append(dataMapper.TableName)
                .Append(" SET ");
            foreach (var column in dataMapper.Columns)
            {
                SqlParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = "@" + column.Key.Name;
                sqlParameter.SqlDbType = GetDbType(column.Key.PropertyType);

                sqlParameter.Value = column.Key.GetValue(entity, null);
                sqlCommand.Parameters.Add(sqlParameter);

                stringBuilder
                    .Append(column.Key.Name)
                    .Append(" = ")
                    .Append(sqlParameter.ParameterName)
                    .Append(", ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(" WHERE ");
            foreach (var column in dataMapper.Ids)
            {
                SqlParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = "@" + column.Key.Name;
                sqlParameter.Value = column.Key.GetValue(entity, null);
                sqlCommand.Parameters.Add(sqlParameter);

                stringBuilder
                    .Append(column.Key.Name)
                    .Append(" = ")
                    .Append(sqlParameter.ParameterName)
                    .Append(" AND ");
            }
            stringBuilder.Remove(stringBuilder.Length - 5, 5);
            sqlCommand.CommandText = stringBuilder.ToString();
            return sqlCommand;
        }

        private System.Data.SqlDbType GetDbType(Type type)
        {
            if (type == typeof(string))
                return System.Data.SqlDbType.VarChar;
            if (type == typeof(int))
                return System.Data.SqlDbType.Int;

            throw new Exception();
 
        }
    }
}
