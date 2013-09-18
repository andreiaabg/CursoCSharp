using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    /// <summary>
    /// Mapeamento Objeto-Relacional
    /// </summary>
    /// <typeparam name="TEntity">Entidade</typeparam>
    public class DataMapper<TEntity> where TEntity : Entity
    {
        public static DataMapper<TEntity> Instance;

        /// <summary>
        /// Nome da Tabela
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Colunas
        /// </summary>
        public Dictionary<PropertyInfo, string> Columns { get; set; }

        public Dictionary<PropertyInfo, string> Ids { get; set; }

        /// <summary>
        /// DataMapper
        /// </summary>
        public DataMapper()
        {
            Columns = new Dictionary<PropertyInfo, string>();
            Ids = new Dictionary<PropertyInfo, string>();
        }

        /// <summary>
        /// Adiciona uma tabela ao mapeamento
        /// </summary>
        public DataMapper<TEntity> Table(string tableName)
        {
            TableName = tableName;
            return this;
        }

        /// <summary>
        /// Adiciona uma Coluna ao mapeamento
        /// </summary>
        public DataMapper<TEntity> Column(Expression<Func<TEntity, object>> property, string column)
        {
            var name =  property.Name;
            Columns.Add(GetProperty(property), column);
            return this;
        }

        /// <summary>
        /// Adiciona uma Coluna ao mapeamento
        /// </summary>
        public DataMapper<TEntity> Id(Expression<Func<TEntity, object>> property, string column)
        {
            var name = property.Name;
            Ids.Add(GetProperty(property), column);
            return this;
        }

        /// <summary>
        /// Define o Mapeamento como padrão
        /// </summary>
        public void Setup()
        {
            Instance = this;
        }

        private static PropertyInfo GetProperty<T>(Expression<Func<T, object>> GetPropertyLambda)
        {
            MemberExpression Exp = null;
            Expression Sub;

            //this line is necessary, because sometimes the expression comes as Convert(originalexpression)
            if (GetPropertyLambda.Body is UnaryExpression)
            {
                UnaryExpression UnExp = (UnaryExpression)GetPropertyLambda.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    Exp = (MemberExpression)UnExp.Operand;
                }
                else
                    throw new Exception();
            }
            else if (GetPropertyLambda.Body is MemberExpression)
            {
                Exp = (MemberExpression)GetPropertyLambda.Body;
            }
            else
            {
                throw new Exception();
                return null;
            }

            return (PropertyInfo)Exp.Member;
        }


    }
}
