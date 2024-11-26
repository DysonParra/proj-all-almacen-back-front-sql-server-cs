/*
 * @fileoverview    {TiposMateriales}
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
 * TODO: Description of {@code TiposMateriales}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TiposMateriales {

        [Key]
        public Int64? IntIdTipoMaterial { get; set; }
        public String? StrTipoMaterial { get; set; }
        public String? StrDescripcionTipoMaterial { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}