/*
 * @fileoverview    {Saldos}
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
 * TODO: Definición de {@code Saldos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Saldos {

        [Key]
        public Int64? IntIdSaldo { get; set; }
        public Decimal? DecCantidad { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdEstadoSaldo { get; set; }
        public String? StrCodigoProducto { get; set; }
        public Int64? IntIdUbicacion { get; set; }

    }

}