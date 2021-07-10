using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutos.Client.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        public async Task MostrarMensajeError (string mensaje)
        {
            await Task.FromResult(0);
        }
    }
}
