/*
 * @fileoverview    {InterlocutorFinanzas} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code InterlocutorFinanzas}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class InterlocutorFinanzas {

        [Key]
        public Int64? IntIdInterlocutorFinanzas { get; set; }
        public Boolean? BitImpuesto { get; set; }
        public Boolean? BitSujetoRetencion { get; set; }
        public String? StrNumeroCertificadoRetencion { get; set; }
        public DateTime? DtFechaVencimiento { get; set; }
        public String? StrNumeroAfiliacionSeguridad { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdInterlocutor { get; set; }

    }

}