/*
 * @fileoverview    {TipoListaMaterial} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code TipoListaMaterial}.
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