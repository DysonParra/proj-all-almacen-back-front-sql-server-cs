/*
 * @fileoverview    {RemisionesVentaMateriales}
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
 * TODO: Definición de {@code RemisionesVentaMateriales}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class RemisionesVentaMateriales {

        [Key]
        public Int64? IntIdRemisionVentaMaterial { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public DateTime? DtFechaNecesaria { get; set; }
        public DateTime? DtFechaSolicitud { get; set; }
        public Double? DblCantidad { get; set; }
        public Decimal? DecValorUnitario { get; set; }
        public Single? FltPorcentajeDescuento { get; set; }
        public Decimal? DecCostoPromedio { get; set; }
        public Int64? IntIdRemisionCompra { get; set; }
        public Decimal? DecCantidadUnidadMedida { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdMaterial { get; set; }
        public String? StrNumeroDocumento { get; set; }
        public Int64? IntIdUnidadMedida { get; set; }

    }

}