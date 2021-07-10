using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaAutos.Client.Helpers;
using VentaAutos.Client.Repositorio;
using VentaAutos.Shared.Modelos;

namespace VentaAutos.Client.Pages.Marcas
{
    public partial class InicioMarca
    {
        [Inject] IRepositorio repositorio { get; set; }
        [Inject] IMostrarMensajes mostrarMensajes { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] IJSRuntime js { get; set; }

        public static bool ShowDialog { get; set; } = true;
        public static bool EsBorrar { get; set; } = false;
        public bool SubmitDisabled { get; set; } = false;
        public string Titulo { get; set; } = "";
        public string ModalCabezera { get; set; } = "";
        public string ModalTextoDetalle { get; set; } = "";
        public string TextoBoton { get; set; }

        public string RutaOpcion { get; set; }
        public string Opcion { get; set; }

        private int paginaActual = 1;
        private int paginasTotales;
        private string totalRegistros;

        public string ENDPOINT_NAME { get; set; } = "marcas";
        public string DTO { get; set; } = "/paginacion";//Si tiene ruta get por DTO, colocar /DTO/paginacion, sino /paginacion

        public List<marca> lst_datos { get; set; }
        private marca modelo = new marca();

        protected async override Task OnAfterRenderAsync (bool firstRender)
        {
            if (firstRender)
            {
                RutaOpcion = await js.RutaPadre("");
                Opcion = await js.RutaHija("");
            }
        }

        private async Task Cargar ()
        {
            SubmitDisabled = false;
            var ruta = $"api/marcas";
            //if (filtrar != "" && filtrar != null)
            //{
            //    ruta = $"api/{ENDPOINT_NAME}{DTO}/filtrar?pagina={pagina}&cant_rows={modeloServicio.CantidadRegistros_mostrar}&texto_buscado={filtrar}";
            //}

            var httpResponse = await repositorio.Get<List<marca>>(ruta);
            if (!httpResponse.Error)
            {
                lst_datos = httpResponse.Response;

                //totalRegistros = httpResponse.HttpResponseMessage.Headers.GetValues("conteo").FirstOrDefault();
                //paginasTotales = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("totalPaginas").FirstOrDefault());
            }
        }

        protected async override Task OnInitializedAsync ()
        {
            await Cargar();
        }

        private async Task Crear ()
        {
            SubmitDisabled = true;
            if (EsBorrar)
            {
                await Borrar(modelo);
                await Reiniciar();
                return;
            }
            if (modelo.id_marca != 0)//Es Update
            {
                //modelo.car_codusr_modificacion = ClaimUser.CodigoUsuario(await authentication);
                var httpResponse = await repositorio.Put($"api/{ENDPOINT_NAME}/{modelo.id_marca}", modelo);
                if (httpResponse.Error)
                {
                    await mostrarMensajes.MostrarMensajeError(await httpResponse.GetBody());
                }
                await Reiniciar();
            }
            else//Es insert
            {
                var httpResponse = await repositorio.Post($"api/{ENDPOINT_NAME}", modelo);
                if (httpResponse.Error)
                {
                    var body = await httpResponse.GetBody();
                    await mostrarMensajes.MostrarMensajeError(body);
                }
                else
                {
                    await Reiniciar();
                }
            }
        }

        private async Task Editar (int codigo, bool borrar)
        {
            EsBorrar = borrar;

            var httpResponse = await repositorio.Get<marca>($"api/{ENDPOINT_NAME}/{codigo}");
            if (httpResponse.Error)
            {
                if (httpResponse.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("Inicio");
                }
                else
                {
                    await mostrarMensajes.MostrarMensajeError(await httpResponse.GetBody());
                }
            }
            else
            {
                Titulo = $"Actualizar {Opcion}";
                TextoBoton = "Actualizar";

                ModalCabezera = "Actualizado";
                ModalTextoDetalle = "Registro actualizado con exito";

                modelo = httpResponse.Response;

                if (borrar)
                    Titulo = $"Borrar {Opcion}";
            }
        }

        private async Task Borrar (marca modelo)
        {
            var responseHttp = await repositorio.Delete($"api/{ENDPOINT_NAME}/{modelo.id_marca}");
            if (responseHttp.Error)
            {
                await mostrarMensajes.MostrarMensajeError(await responseHttp.GetBody());
            }
            else
            {
                await Cargar();
            }
        }

        public async Task Reiniciar ()
        {
            await Cargar();
            modelo = new marca();
            if (EsBorrar == false)
                await js.ModalMostrar("modal-success");

            await js.AcultarModal("modal-report");

        }

        protected void Add ()
        {
            Titulo = $"Agregar {Opcion}";
            TextoBoton = "Guardar cambios";

            ModalCabezera = "Agregado";
            ModalTextoDetalle = "Registro agregado con exito";

            modelo = new marca();
            EsBorrar = false;
        }

        protected void Borrar ()
        {
            Titulo = $"Agregar {Opcion}";
            TextoBoton = "Guardar cambios";
            modelo = new marca();
        }
    }
}
