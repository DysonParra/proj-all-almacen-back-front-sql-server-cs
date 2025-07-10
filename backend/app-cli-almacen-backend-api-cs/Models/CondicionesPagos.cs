/*
 * @overview        {CondicionesPagos}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code CondicionesPagos}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class CondicionesPagos {

        [Key]
        public Int64? IntIdCondicionPago { get; set; }
        public String? StrNombreCondicion { get; set; }
        public String? StrDescripcion { get; set; }
        public Boolean? BitDeudor { get; set; }
        public Boolean? BitAcreedor { get; set; }
        public Int32? IntDiiaFijo { get; set; }
        public Int32? IntMesesAdicionales { get; set; }
        public Int32? IntDiasTolerancia { get; set; }
        public Int32? IntNumeroPlazos { get; set; }
        public Single? FltDescuentoTotal { get; set; }
        public Single? FltInteresCredito { get; set; }
        public Decimal? DecHaberMaximo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}