/*
 * @fileoverview    {Movimientos}
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
     * TODO: Description of {@code Movimientos}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Movimientos {

        [Key]
        public Int64? IntIdMovimiento { get; set; }
        public String? StrNumeroDocumento { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public DateTime? DtFechaAnulacion { get; set; }
        public Decimal? DecSobreCosto { get; set; }
        public Decimal? DecSobreCostoAplicadoProducto { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdBodega { get; set; }
        public Int64? IntIdConcepto { get; set; }
        public Int64? IntIdEstadoMovimiento { get; set; }
        public Int64? IntIdRemision { get; set; }
        public Int64? IntIdTipoDocumento { get; set; }
        public Int64? IntIdTipoMovimiento { get; set; }

    }

}