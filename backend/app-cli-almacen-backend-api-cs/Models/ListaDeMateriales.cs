/*
 * @overview        {ListaDeMateriales}
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
     * TODO: Description of {@code ListaDeMateriales}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ListaDeMateriales {

        [Key]
        public Int64? IntIdListaMaterial { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtFechaFin { get; set; }
        public Int32? IntCantidad { get; set; }
        public Decimal? DecPrecioUnitario { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdBodega { get; set; }
        public Int64? IntIdTipoListaMaterial { get; set; }
        public Int64? IntIdListaPrecio { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public String? StrCodigoComponente { get; set; }
        public Int64? IntIdUnidadMedida { get; set; }

    }

}