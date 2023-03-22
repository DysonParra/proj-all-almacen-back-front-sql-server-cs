/*
 * @fileoverview    {MovimientosDetalles}
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
 * TODO: Definición de {@code MovimientosDetalles}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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