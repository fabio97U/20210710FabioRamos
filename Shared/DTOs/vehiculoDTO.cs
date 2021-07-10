using VentaAutos.Shared.Modelos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VentaAutos.Shared.DTOs
{
    public class vehiculoDTO
    {
        [Required]
        public marca marca { get; set; }
        [Required]
        public modelo modelo { get; set; }
        [Required]
        public tipo_negocio tipo_Negocio { get; set; }
        [ValidateComplexType]
        public vehiculo vehiculo { get; set; } = new vehiculo();
    }
}
