/*
 * @fileoverview    {Bodegas}
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
 * TODO: Definición de {@code Bodegas}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Bodegas {

        [Key]
        public Int64? IntIdBodega { get; set; }
        public String? StrCodigoBodega { get; set; }
        public String? StrDescripcionBodega { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdAgente { get; set; }

    }

}