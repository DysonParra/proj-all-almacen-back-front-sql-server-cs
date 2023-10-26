/*
 * @fileoverview    {RemisionesCompras}
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
 * TODO: Definición de {@code RemisionesCompras}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class RemisionesCompras {

        [Key]
        public Int64? IntIdRemisionCompra { get; set; }
        public String? StrNumeroRemisionCompra { get; set; }
        public DateTime? DtFechaContabilizacion { get; set; }
        public DateTime? DtFechaValidez { get; set; }
        public DateTime? DtFechaDocumento { get; set; }
        public DateTime? DtFechaNecesaria { get; set; }
        public String? StrNumeroReferencia { get; set; }
        public Decimal? DecTotalBruto { get; set; }
        public Double? DblPorcentajeDescuento { get; set; }
        public Double? DblPorcentajeImpuesto { get; set; }
        public Decimal? DecValorTotal { get; set; }
        public String? StrComentarios { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdInterlocutor { get; set; }
        public Int64? IntIdRemision { get; set; }
        public Int64? IntIdTipoDocumento { get; set; }

    }

}