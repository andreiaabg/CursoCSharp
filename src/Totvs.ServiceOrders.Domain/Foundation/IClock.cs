using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.OrdemServico.Domain.Foundation
{
    /// <summary>
    /// Relógio
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Data/Hora de Agora
        /// </summary>
        DateTime GetNow();
    }
}
