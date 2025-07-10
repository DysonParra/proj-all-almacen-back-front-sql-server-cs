/*
 * @overview        {MovimientosDetalles}
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
     * TODO: Description of {@code MovimientosDetalles}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MovimientosDetalles {

        [Key]
        public Int64? IntIdMovimientoDetalle { get; set; }
        public Decimal? DecValorUnitario { get; set; }
        public Decimal? DecSobreCosto { get; set; }
        public Decimal? DecCantidad { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdEstadoSaldo { get; set; }
        public String? StrCodigoProducto { get; set; }
        public String? StrNumeroDocumento { get; set; }

    }

}