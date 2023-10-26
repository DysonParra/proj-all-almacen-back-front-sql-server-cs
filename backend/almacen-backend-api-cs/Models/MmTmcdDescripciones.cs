/*
 * @fileoverview    {MmTmcdDescripciones}
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
 * TODO: Definición de {@code MmTmcdDescripciones}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class MmTmcdDescripciones {

        [Key]
        public Int64? IntIdMmTmcdDescripciones { get; set; }
        public String? StrCultura { get; set; }
        public String? StrDescripcionMaterial { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTipoMaterialCaracteristica { get; set; }

    }

}