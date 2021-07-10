using System;
using VentaAutos.Client.Helpers;
using VentaAutos.Client.Repositorio;
using VentaAutos.Shared.Modelos;
using VentaAutos.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutos.Client.Pages.Autos
{
    public partial class InicioAuto
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

        public string ENDPOINT_NAME { get; set; } = "vehiculoes";
        public string DTO { get; set; } = "/DTO";//Si tiene ruta get por DTO, colocar /DTO, sino vacio

        public List<vehiculoDTO> lst_datos { get; set; }
        private vehiculoDTO modelo = new vehiculoDTO();
        //private tde_tipo_estudio tde_value = new tde_tipo_estudio();

        protected async override Task OnAfterRenderAsync (bool firstRender)
        {
            if (firstRender)
            {
                RutaOpcion = await js.RutaPadre("");
                Opcion = await js.RutaHija("");
            }
        }

        private async Task CargarDatosGrid ()
        {
            SubmitDisabled = false;
            var ruta = $"api/{ENDPOINT_NAME}{DTO}";//Sin filtro

            var httpResponse = await repositorio.Get<List<vehiculoDTO>>(ruta);
            if (!httpResponse.Error)
            {
                lst_datos = httpResponse.Response;

                //totalRegistros = httpResponse.HttpResponseMessage.Headers.GetValues("conteo").FirstOrDefault();
                //paginasTotales = int.Parse(httpResponse.HttpResponseMessage.Headers.GetValues("totalPaginas").FirstOrDefault());
            }
        }

        protected async override Task OnInitializedAsync ()
        {
            await CargarDatosGrid();
        }


        /// <summary>
        /// Se ejecuta cuando se preciona en crear un nuevo registro
        /// </summary>
        /// <returns></returns>
        private async Task Crear ()
        {
            SubmitDisabled = true;
            if (EsBorrar)
            {
                await Borrar(modelo);
                await Reiniciar();
                return;
            }
            //Inicio: Si tiene FK, hacer la asignacion de cada una de sus llaves en el modelo principal
            modelo.vehiculo.id_marca = modelo.marca.id_marca;
            modelo.vehiculo.id_modelo = modelo.modelo.id_modelo;
            modelo.vehiculo.id_tipo_negocio = modelo.tipo_Negocio.id_tipo_negocio;
            //Fin 

            if (modelo.vehiculo.id_vehiculo != 0)//Es Update
            {
                var httpResponse = await repositorio.Put($"api/{ENDPOINT_NAME}/{modelo.vehiculo.id_vehiculo}", modelo.vehiculo);
                if (httpResponse.Error)
                {
                    await mostrarMensajes.MostrarMensajeError(await httpResponse.GetBody());
                }
                await Reiniciar();
            }
            else//Es insert
            {
                var httpResponse = await repositorio.Post($"api/{ENDPOINT_NAME}", modelo.vehiculo);
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
        /// <summary>
        /// Se ejectua cuando se va editar o borar un registro, realiza el llenado del modelo
        /// </summary>
        /// <param name="codigo">PK del modelo</param>
        /// <param name="borrar">bool es borar</param>
        /// <returns></returns>
        private async Task Editar (int codigo, bool borrar)
        {
            EsBorrar = borrar;

            var httpResponse = await repositorio.Get<vehiculoDTO>($"api/{ENDPOINT_NAME}{DTO}/{codigo}");
            if (httpResponse.Error)
            {
                await mostrarMensajes.MostrarMensajeError(await httpResponse.GetBody());
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

        private async Task Borrar (vehiculoDTO vehiculoDTO)
        {
            var responseHttp = await repositorio.Delete($"api/{ENDPOINT_NAME}/{vehiculoDTO.vehiculo.id_vehiculo}");
            if (responseHttp.Error)
                await mostrarMensajes.MostrarMensajeError(await responseHttp.GetBody());
            else
                await CargarDatosGrid();
        }

        public async Task Reiniciar ()
        {
            await CargarDatosGrid();
            modelo = new vehiculoDTO();
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

            modelo = new vehiculoDTO();
            EsBorrar = false;
        }

        protected void Borrar ()
        {
            Titulo = $"Agregar {Opcion}";
            TextoBoton = "Guardar cambios";
            modelo = new vehiculoDTO();
        }

    }
}
