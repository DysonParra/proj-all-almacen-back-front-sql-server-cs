/*
 * @fileoverview    {TipoListaMaterial}
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
 * TODO: Description of {@code TipoListaMaterial}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class TipoListaMaterial {

        [Key]
        public Int64? IntIdTipoListaMaterial { get; set; }
        public String? StrNombreTipoLista { get; set; }
        public String? StrDescripcionLista { get; set; }

    }

}