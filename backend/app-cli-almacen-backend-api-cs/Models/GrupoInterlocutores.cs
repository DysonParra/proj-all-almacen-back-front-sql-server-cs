/*
 * @fileoverview    {GrupoInterlocutores}
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
     * TODO: Description of {@code GrupoInterlocutores}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class GrupoInterlocutores {

        [Key]
        public Int64? IntIdGrupoInterlocutor { get; set; }
        public String? StrNombreGrupo { get; set; }
        public String? StrDescripcion { get; set; }
        public String? StrCuentaContable { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdListaPrecio { get; set; }

    }

}