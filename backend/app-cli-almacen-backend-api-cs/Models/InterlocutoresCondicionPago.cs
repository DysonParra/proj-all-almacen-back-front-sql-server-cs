/*
 * @fileoverview    {InterlocutoresCondicionPago}
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
     * TODO: Description of {@code InterlocutoresCondicionPago}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class InterlocutoresCondicionPago {

        [Key]
        public Int64? IntIdInterlocutorCondicionPago { get; set; }
        public String? StrNombreCondicion { get; set; }
        public Single? FltInteresMora { get; set; }
        public Single? FltDescuentoTotal { get; set; }
        public Decimal? DecCupoCredito { get; set; }
        public String? StrNumeroCuenta { get; set; }
        public String? StrSucursal { get; set; }
        public String? StrClaveControl { get; set; }
        public Boolean? BitEntregaParcial { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdCondicionPago { get; set; }
        public Int64? IntIdInterlocutor { get; set; }
        public Int64? IntIdListaPrecio { get; set; }

    }

}