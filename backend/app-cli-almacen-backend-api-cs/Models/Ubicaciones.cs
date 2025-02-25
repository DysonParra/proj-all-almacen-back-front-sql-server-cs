/*
 * @fileoverview    {Ubicaciones}
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
     * TODO: Description of {@code Ubicaciones}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Ubicaciones {

        [Key]
        public Int64? IntIdUbicacion { get; set; }
        public String? StrCodigoUbicacion { get; set; }
        public String? StrDescripcionUbicacion { get; set; }
        public Boolean? BitDedicado { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public String? StrCodigoZona { get; set; }

    }

}