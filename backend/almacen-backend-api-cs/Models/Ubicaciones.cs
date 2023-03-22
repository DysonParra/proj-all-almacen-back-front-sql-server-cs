/*
 * @fileoverview    {Ubicaciones}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Ubicaciones}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Ubicaciones {

        [Key]
        public Int64? IntIdUbicacion { get; set; }
        public String? StrCodigoUbicacion { get; set; }
        public String? StrDescripcionUbicacion { get; set; }
        public Boolean? BitDedicado { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public String? StrCodigoZona { get; set; }

    }

}