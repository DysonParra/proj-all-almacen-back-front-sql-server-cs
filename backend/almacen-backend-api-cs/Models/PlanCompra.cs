/*
 * @fileoverview    {PlanCompra}
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
 * TODO: Description of {@code PlanCompra}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class PlanCompra {

        [Key]
        public Int64? IntIdPlanCompra { get; set; }
        public Int64? IntCodigoMaterial { get; set; }
        public String? StrDescripcion { get; set; }
        public double? DblCantidad { get; set; }
        public Int32? IntIdGrupoProveedor { get; set; }
        public DateTime? DtFechaExplosion { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public DateTime? DtFechaModificacion { get; set; }
        public String? StrUsuario { get; set; }
        public String? StrEstado { get; set; }

    }

}