/*
 * @fileoverview    {ListasPreciosMateriales} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code ListasPreciosMateriales}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class ListasPreciosMateriales {

        [Key]
        public Int64? IntId { get; set; }
        public Int64? IntIdMateriales { get; set; }
        public Int64? IntIdListasPrecios { get; set; }

    }

}