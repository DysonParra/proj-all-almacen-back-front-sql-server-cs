/*
 * @fileoverview    {Conceptos}
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
 * TODO: Definición de {@code Conceptos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Conceptos {

        [Key]
        public Int64? IntIdConcepto { get; set; }
        public String? StrDescripcionConcepto { get; set; }
        public Boolean? BitReposicion { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}