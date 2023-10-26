/*
 * @fileoverview    {TiposMovimientos}
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
 * TODO: Definición de {@code TiposMovimientos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TiposMovimientos {

        [Key]
        public Int64? IntIdTipoMovimiento { get; set; }
        public String? StrDescripcionTipoMovimiento { get; set; }
        public Boolean? BitSigno { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}