/*
 * @fileoverview    {TiposDocumentos}
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
 * TODO: Description of {@code TiposDocumentos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TiposDocumentos {

        [Key]
        public Int64? IntIdTipoDocumento { get; set; }
        public String? StrDescripcionTipoDocumento { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdEstadoRemision { get; set; }
        public Int64? IntIdTipoMovimiento { get; set; }

    }

}