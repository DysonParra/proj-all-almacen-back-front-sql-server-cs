/*
 * @fileoverview    {Consecutivos}
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
 * TODO: Description of {@code Consecutivos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Consecutivos {

        [Key]
        public Int64? IntIdConsecutivo { get; set; }
        public String? StrResolucion { get; set; }
        public Int32? IntValorInicial { get; set; }
        public Int32? IntValorFinal { get; set; }
        public Int32? IntIncremento { get; set; }
        public Int32? IntValorActual { get; set; }
        public String? StrCaracterLlenado { get; set; }
        public DateTime? DtFechaInicial { get; set; }
        public DateTime? DtFechaFinal { get; set; }
        public String? StrSufijo { get; set; }
        public String? StrPrefijo { get; set; }
        public Boolean? BitHabilitado { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTipoDocumento { get; set; }

    }

}