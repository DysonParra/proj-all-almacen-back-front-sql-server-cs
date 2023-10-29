/*
 * @fileoverview    {ListasPrecios}
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
 * TODO: Description of {@code ListasPrecios}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class ListasPrecios {

        [Key]
        public Int64? IntIdListaPrecio { get; set; }
        public String? StrNombreListaPrecios { get; set; }
        public String? StrDescripcionListaPrecios { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}