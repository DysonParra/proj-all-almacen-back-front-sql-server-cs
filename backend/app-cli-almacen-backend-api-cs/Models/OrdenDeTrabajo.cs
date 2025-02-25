/*
 * @fileoverview    {OrdenDeTrabajo}
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
     * TODO: Description of {@code OrdenDeTrabajo}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class OrdenDeTrabajo {

        [Key]
        public Int64? IntIdOrdenTrabajo { get; set; }
        public Int64? IntIdOperacion { get; set; }
        public Int64? IntIdEstadoOT { get; set; }
        public Int64? IntIdCentroTrabajo { get; set; }
        public String? StrNumeroOrden { get; set; }

    }

}