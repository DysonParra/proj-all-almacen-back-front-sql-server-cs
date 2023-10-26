/*
 * @fileoverview    {Componentes}
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
 * TODO: Definición de {@code Componentes}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Componentes {

        [Key]
        public Int64? IntIdComponente { get; set; }
        public Int64? IntIdAlmacen { get; set; }
        public Decimal? DecCantidadBase { get; set; }
        public Decimal? DecCantidadRequerida { get; set; }
        public Decimal? DecCantidadAdicional { get; set; }
        public Decimal? DecCantidadConsumida { get; set; }
        public DateTime? DtFechaEstimada { get; set; }
        public DateTime? DtFechaEfectiva { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtFechaFinal { get; set; }
        public Int64? IntIdEstadoComponente { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public String? StrNumeroOrden { get; set; }
        public Int64? IntIdUnidadMedida { get; set; }

    }

}