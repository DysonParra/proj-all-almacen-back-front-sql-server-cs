/*
 * @fileoverview    {TiposDocumentosTiposAgentes}
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
 * TODO: Definición de {@code TiposDocumentosTiposAgentes}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TiposDocumentosTiposAgentes {

        [Key]
        public Int64? IntIdTipoDocumentoTipoAgente { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTipoAgente { get; set; }
        public Int64? IntIdTipoDocumento { get; set; }

    }

}