using System;


namespace Totvs.OrdemServico.Dominio.Entidades
{
    /// <summary>
    /// Solicitante
    /// </summary>
    public class Solicitante
    {
        /// <summary>
        /// Id: Nome do Usuário
        /// </summary>
        public string NomeUsuario { get; set;}

        /// <summary>
        /// Solicitante
        /// </summary>
        /// <param name="nomeUsuario">Nome do Usuário</param>
        public Solicitante(string nomeUsuario)
        {
            this.NomeUsuario = nomeUsuario;
        }
    }
}
