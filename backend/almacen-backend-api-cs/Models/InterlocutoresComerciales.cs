/*
 * @fileoverview    {InterlocutoresComerciales} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code InterlocutoresComerciales}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class InterlocutoresComerciales {

        [Key]
        public Int64? IntIdInterlocutorComercial { get; set; }
        public String? StrCodigoInterlocutor { get; set; }
        public String? StrNumeroIdentificacionFinanciera { get; set; }
        public String? StrNombreInterlocutor { get; set; }
        public String? StrTelefono { get; set; }
        public String? StrCelular { get; set; }
        public String? StrFax { get; set; }
        public String? StrEmail { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdGrupoInterlocutor { get; set; }
        public Int64? IntIdTipoInterlocutor { get; set; }

    }

}