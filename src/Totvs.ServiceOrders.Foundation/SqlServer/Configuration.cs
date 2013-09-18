using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ServiceOrders.Domain.Entities;

namespace Totvs.ServiceOrders.Infra.SqlServer
{
    /// <summary>
    /// Configurações de banco de dados
    /// </summary>
    public static class Configuration
    {
        public static void ConnectionString(string connectionString)
        {
            UnitOfWork.ConnectionString = connectionString;
        }

        /// <summary>
        /// Mapeamento Objeto-Relacional
        /// </summary>
        public static void Mapping()
        {
            /* Produtos */
            new DataMapper<Product>()
                    .Table("PRODUTO")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.Name, "NOME")
                    .Setup();
            
            /* Versões do Produto */
            new DataMapper<ProductVersion>()
                    .Table("PRODUTOVERSAO")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.ProductId, "PRODUTO")
                    .Column(p => p.Version, "VERSAO")
                    .Setup();

            /* Chamado */
            new DataMapper<Ticket>()
                    .Table("CHAMADO")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.RequestorId, "REQUISITANTE")
                    .Column(p => p.ProductVersionId, "VERSAO_PRODUTO")
                    .Column(p => p.IncidentId, "INCIDENTE")
                    .Setup();

            /* Dono do Chamado */
            new DataMapper<Requestor>()
                    .Table("REQUISITANTES")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.UserName, "USUARIO")
                    .Setup();

            /* Descrição do Chamado */
            new DataMapper<Incident>()
                    .Table("CHAMADOSDESC")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.TicketId, "CHAMADO")
                    .Column(p => p.Description, "DESCRICAO")
                    .Setup();

            /* Usuário do Sistema */
            new DataMapper<User>()
                    .Table("USUARIOS")
                    .Id(p => p.Id, "CODIGO")
                    .Column(p => p.UserName, "NOME")
                    .Column(p => p.Password, "SENHA")
                    .Setup();
        }
    }
}
