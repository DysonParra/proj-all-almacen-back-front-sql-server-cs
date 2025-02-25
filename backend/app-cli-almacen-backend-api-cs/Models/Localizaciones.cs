/*
 * @fileoverview    {Localizaciones}
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
     * TODO: Description of {@code Localizaciones}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Localizaciones {

        [Key]
        public Int64? IntIdLocalizacion { get; set; }
        public String? StrNombreLocalizacion { get; set; }
        public String? StrDireccion { get; set; }
        public String? StrCodigoPostal { get; set; }
        public String? StrPoBox { get; set; }
        public String? StrCiudad { get; set; }
        public String? StrPais { get; set; }
        public String? StrRegion { get; set; }
        public String? StrTelefono { get; set; }
        public String? StrCelular { get; set; }
        public String? StrFax { get; set; }
        public String? StrEmail { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdInterlocutor { get; set; }
        public Int64? IntIdBodega { get; set; }

    }

}