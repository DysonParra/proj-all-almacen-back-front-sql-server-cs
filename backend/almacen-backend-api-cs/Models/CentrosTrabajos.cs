/*
 * @fileoverview    {CentrosTrabajos} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code CentrosTrabajos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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