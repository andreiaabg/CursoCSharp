using System;

namespace Totvs.OrdemServico.Dominio.Entidades
{
    /// <summary>
    /// Incidente
    /// </summary>
    public class Incidente
    {
        /// <summary>
        /// Descrição
        /// </summary>
        private readonly string descricao;

        /// <summary>
        /// Incidente
        /// </summary>
        /// <param name="descricao">Descrição</param>
        public Incidente(string descricao)
        {
            this.descricao = descricao;
        }
    }
}
