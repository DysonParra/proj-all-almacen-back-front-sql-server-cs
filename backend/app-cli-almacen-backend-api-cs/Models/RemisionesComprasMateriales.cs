/*
 * @overview        {RemisionesComprasMateriales}
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
     * TODO: Description of {@code RemisionesComprasMateriales}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class RemisionesComprasMateriales {

        [Key]
        public Int64? IntIdRemisionCompraMaterial { get; set; }
        public String? StrNumeroRemisionCompra { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public DateTime? DtFechaNecesaria { get; set; }
        public DateTime? DtFechaSolicitud { get; set; }
        public Double? DblCantidad { get; set; }
        public Decimal? DecValorUnitario { get; set; }
        public Single? FltPorcentajeDescuento { get; set; }
        public Decimal? DecCostoPromedio { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdMaterial { get; set; }
        public Int64? IntIdRemisionCompra { get; set; }

    }

}