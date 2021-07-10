using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutos.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
          public static async ValueTask<bool> Confirm (this IJSRuntime js, string mensaje)
        {
            await js.InvokeVoidAsync("console.log", "prueba de console.log");
            return await js.InvokeAsync<bool>("confirm", mensaje);
        }

        public static async ValueTask<string> RutaPadre (this IJSRuntime js, string parametro)
        {
            return await js.InvokeAsync<string>("opcionPadre", parametro);
        }
        public static async ValueTask<string> RutaHija (this IJSRuntime js, string parametro)
        {
            return await js.InvokeAsync<string>("opcionHijo", parametro);
        }

        public static async Task ModalMostrar (this IJSRuntime js, string elementId)
        {
            await js.InvokeVoidAsync("mostrarModal", elementId);
        }

        public static async Task AcultarModal (this IJSRuntime js, string elementId)
        {
            await js.InvokeVoidAsync("ocultarModal", elementId);
        }
    }
}
