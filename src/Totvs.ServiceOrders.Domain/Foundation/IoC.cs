using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Resolve as dependencias da camada de infraestrutura
    /// </summary>
    public static class IoC
    {
        private readonly static ConcurrentDictionary<Type, ContainerRegistration> Table = new ConcurrentDictionary<Type, ContainerRegistration>();


        /// <summary>
        /// Constrói um tipo concreto a partir do tipo abstrato
        /// </summary>
        public static TAbstract Resolve<TAbstract>()
        {
            return Table[typeof(TAbstract)].Instace<TAbstract>();
        }

        /// <summary>
        /// Registra o mapeamento
        /// </summary>
        public static void Register<TAbstract, TConcrete>()
            where TConcrete : TAbstract
        {
            var registration = new ContainerRegistration
            {
                AbstractType = typeof(TAbstract),
                ConcreteType = typeof(TConcrete),
            };
            Table.TryAdd(registration.AbstractType, registration);
        }

        /// <summary>
        /// Regista o mapeamento por fabrica
        /// </summary>
        public static void Register<TAbstract, TConcrete>(Func<object> factory = null)
            where TConcrete : TAbstract
        {
            var registration = new ContainerRegistration
            {
                AbstractType = typeof(TAbstract),
                ConcreteType = typeof(TConcrete),
                Factory = factory
            };
            Table.TryAdd(registration.AbstractType, registration);
        }
    }

    /// <summary>
    /// Registro de Mapeamento
    /// </summary>
    struct ContainerRegistration
    {
        /// <summary>
        /// Tipo Abstrato
        /// </summary>
        public Type AbstractType;
        
        /// <summary>
        /// Tipo Concreto
        /// </summary>
        public Type ConcreteType;
        
        /// <summary>
        /// Fabrica que constrói o tipo concreto
        /// </summary>
        public Func<object> Factory;

        /// <summary>
        /// Cria a instancia
        /// </summary>
        public TAbstract Instace<TAbstract>(params object[] args)
        {
            if (Factory != null)
                return (TAbstract)Factory();

            return (TAbstract)Activator.CreateInstance(ConcreteType, args);
        }
    }
}
