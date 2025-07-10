/*
 * @overview        {CentrosTrabajos}
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
     * TODO: Description of {@code CentrosTrabajos}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class CentrosTrabajos {

        [Key]
        public Int64? IntIdCentroDeTrabajo { get; set; }
        public Int64? IntIdInterlocutorComercial { get; set; }
        public Int64? IntIdCategoriaCentro { get; set; }
        public Decimal? DecCosto { get; set; }
        public Int64? IntIdBodega { get; set; }
        public Int64? IntIdMetodoCosteo { get; set; }

    }

}