/*
 * @fileoverview    {TipoInterlocutorComercial}
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
 * TODO: Definición de {@code TipoInterlocutorComercial}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TipoInterlocutorComercial {

        [Key]
        public Int64? IntIdTipoInterlocutorComercial { get; set; }
        public String? StrTipoInterlocutor { get; set; }
        public String? StrDescripcionTipoInterlocutor { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}