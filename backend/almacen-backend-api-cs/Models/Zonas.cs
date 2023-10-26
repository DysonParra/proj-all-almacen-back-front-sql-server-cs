/*
 * @fileoverview    {Zonas}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Zonas}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Zonas {

        [Key]
        public String? StrCodigoZona { get; set; }
        public String? StrDescripcionZona { get; set; }
        public Boolean? BitTransitoDirecto { get; set; }
        public Boolean? BitPicking { get; set; }
        public Boolean? BitUbicacion { get; set; }
        public Boolean? BitDespacho { get; set; }
        public Boolean? BitRecepcion { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdBodega { get; set; }

    }

}