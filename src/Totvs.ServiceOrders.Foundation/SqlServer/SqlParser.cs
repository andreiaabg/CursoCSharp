using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    public class SqlServerParser<TEntity>
        where TEntity : Entity
    {
        private static string _sqlUpdate;

        public SqlCommand CreateUpdateCommand(TEntity entity)
        {
            var sqlCommand = new SqlCommand();
            StringBuilder stringBuilder = null;

            var dataMapper = DataMapper<TEntity>.Instance;

            if (_sqlUpdate == null)
            {
                stringBuilder = new StringBuilder()
                    .Append("UPDATE ")
                    .Append(dataMapper.TableName)
                    .Append(" SET ");
            }
            foreach (var column in dataMapper.Columns)
            {
                var sqlParameter = CreateParameter(entity, sqlCommand, column.Key);
                if (_sqlUpdate == null)
                {
                    stringBuilder
                        .Append(column.Key.Name)
                        .Append(" = ")
                        .Append(sqlParameter.ParameterName)
                        .Append(", ");
                }
            }
            if (_sqlUpdate == null)
            {
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append(" WHERE ");
            }
            foreach (var column in dataMapper.Ids)
            {
                var sqlParameter = CreateParameter(entity, sqlCommand, column.Key);

                if (_sqlUpdate == null)
                {
                    stringBuilder
                        .Append(column.Key.Name)
                        .Append(" = ")
                        .Append(sqlParameter.ParameterName)
                        .Append(" AND ");
                }
            }
            if (_sqlUpdate == null)
            {
                stringBuilder.Remove(stringBuilder.Length - 5, 5);
                _sqlUpdate = stringBuilder.ToString();
            }
            sqlCommand.CommandText = _sqlUpdate;
            return sqlCommand;
        }

        /// <summary>
        /// Cria e Adiciona um Parametro no Command
        /// </summary>
        private SqlParameter CreateParameter(TEntity entity, SqlCommand sqlCommand, PropertyInfo propertyInfo)
        {
            var sqlParameter = sqlCommand.CreateParameter();
            sqlParameter.ParameterName = "@" + propertyInfo.Name;
            sqlParameter.SqlDbType = GetDbType(propertyInfo.PropertyType);

            sqlParameter.Value = propertyInfo.GetValue(entity, null);
            sqlCommand.Parameters.Add(sqlParameter);
            return sqlParameter;
        }

        /// <summary>
        /// Converte o Tipo do Banco de dados em um tipo Sql
        /// </summary>
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
