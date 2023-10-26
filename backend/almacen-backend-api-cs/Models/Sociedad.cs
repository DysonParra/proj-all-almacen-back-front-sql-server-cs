/*
 * @fileoverview    {Sociedad}
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
 * TODO: Definición de {@code Sociedad}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Sociedad {

        [Key]
        public Int64? IntIdSociedad { get; set; }
        public String? StrCodigoSociedad { get; set; }
        public String? StrNombreSociedad { get; set; }
        public String? StrDescripcionSociedad { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}