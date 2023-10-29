/*
 * @fileoverview    {UnidadMedida}
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
 * TODO: Description of {@code UnidadMedida}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class UnidadMedida {

        [Key]
        public Int64? IntIdUnidadMedida { get; set; }
        public String? StrNombre { get; set; }
        public String? StrSimbolo { get; set; }
        public Single? FltFactor { get; set; }
        public Single? FltPrecision { get; set; }
        public Single? FltConversion { get; set; }
        public Int32? IntDecimales { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTipoUnidadMedida { get; set; }

    }

}