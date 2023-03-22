/*
 * @fileoverview    {Agentes}
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
 * TODO: Definición de {@code Agentes}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Agentes {

        [Key]
        public Int64? IntIdAgente { get; set; }
        public Int32? IntIdEntidad { get; set; }
        public Int32? IntIdAlmacen { get; set; }
        public String? StrObservaciones { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdSociedad { get; set; }
        public Int64? IntIdTipoAgente { get; set; }

    }

}