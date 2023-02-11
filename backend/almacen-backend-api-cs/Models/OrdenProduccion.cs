/*
 * @fileoverview    {OrdenProduccion} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code OrdenProduccion}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class OrdenProduccion {

        [Key]
        public String? StrNumeroOrden { get; set; }
        public String? StrReferencia { get; set; }
        public Int64? IntIdEstadoProduccion { get; set; }
        public Int64? IntIdRutaOrdenTrabajo { get; set; }
        public Int64? IntIdCentroTrabajo { get; set; }
        public DateTime? DtFechaEstimada { get; set; }
        public DateTime? DtFechaInicioEstimada { get; set; }
        public DateTime? DtFechaFinalizacion { get; set; }
        public Decimal? DecCantidadPlanificada { get; set; }
        public String? StrOrigenOrden { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdListaMateriales { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public Int64? IntIdUnidadMedida { get; set; }

    }

}