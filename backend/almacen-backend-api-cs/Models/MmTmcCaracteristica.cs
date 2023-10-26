/*
 * @fileoverview    {MmTmcCaracteristica}
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
 * TODO: Definición de {@code MmTmcCaracteristica}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class MmTmcCaracteristica {

        [Key]
        public Int64? IntIdMmTmcCaracteristica { get; set; }
        public Int64? IntIdTipoMaterialCaracteristica { get; set; }
        public String? StrTipoMaterial { get; set; }
        public String? StrDescripcionTipoMaterialCaracteristica { get; set; }
        public Int32? IntTipoDato { get; set; }
        public String? StrReglaValidacion { get; set; }
        public Boolean? BitVisibleDetalle { get; set; }
        public Int32? IntOrdenDetall { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTipoMaterial { get; set; }

    }

}