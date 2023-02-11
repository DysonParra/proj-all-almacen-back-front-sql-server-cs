/*
 * @fileoverview    {RemisionesVenta} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code RemisionesVenta}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class RemisionesVenta {

        [Key]
        public String? StrNumeroDocumento { get; set; }
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
        public Int64? IntListaPrecio { get; set; }

    }

}