using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Totvs.ServiceOrders.Domain.Entities;
using Totvs.ServiceOrders.Infra.SqlServer;

namespace Totvs.ServiceOrders.UI.FoundationTests
{
    [TestClass]
    public class SqlUpdateParseTest
    {
        public class EntityTest : Entity
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }


        [TestMethod]
        public void UpdateWhith1CollumnAnd1Id()
        {
            new DataMapper<EntityTest>()
            .Table("TESTE")
            .Id(_ => _.Id, "ID")
            .Column(_ => _.Description, "DESCRIPTION")
            .Setup();

            var parser = new SqlServerParser<EntityTest>();
            var entityTest = new EntityTest();
            entityTest.Id = 1;
            entityTest.Description = "Teste";

            var command = parser.CreateUpdateCommand(entityTest);
            Assert.AreEqual(
                @"UPDATE TESTE SET DESCRIPTION = @Description WHERE ID = @Id", 
                command.CommandText, 
                ignoreCase: true);
            Assert.AreEqual("Teste", command.Parameters["@Description"].Value);
            Assert.AreEqual(1, command.Parameters["@Id"].Value);

            var entityTest2 = new EntityTest();
            entityTest.Id = 2;
            entityTest.Description = "Teste 2";
            var command2 = parser.CreateUpdateCommand(entityTest);
            Assert.AreEqual(
                @"UPDATE TESTE SET DESCRIPTION = @Description WHERE ID = @Id",
                command.CommandText,
                ignoreCase: true);
            Assert.AreEqual("Teste 2", command2.Parameters["@Description"].Value);
            Assert.AreEqual(2, command2.Parameters["@Id"].Value);
        }
    }
}
