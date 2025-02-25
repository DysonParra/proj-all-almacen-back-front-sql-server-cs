/*
 * @fileoverview    {EstadosMovimientos}
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
     * TODO: Description of {@code EstadosMovimientos}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class EstadosMovimientos {

        [Key]
        public Int64? IntIdEstadoMovimiento { get; set; }
        public String? StrDescripcionEstadoMovimiento { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}