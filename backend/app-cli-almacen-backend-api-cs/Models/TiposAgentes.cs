/*
 * @fileoverview    {TiposAgentes}
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
     * TODO: Description of {@code TiposAgentes}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class TiposAgentes {

        [Key]
        public Int64? IntIdTipoAgente { get; set; }
        public String? StrDescripcionTipoAgente { get; set; }
        public String? StrTablaInformacion { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}