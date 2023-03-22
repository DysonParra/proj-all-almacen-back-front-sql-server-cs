/*
 * @fileoverview    {MmCodigoEquivalente}
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
 * TODO: Definición de {@code MmCodigoEquivalente}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class MmCodigoEquivalente {

        [Key]
        public Int64? IntIdMmCodigoEquivalente { get; set; }
        public String? StrTipoCodigoEquivalente { get; set; }
        public String? StrValorCodigoEquivalente { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdMaterial { get; set; }
        public String? StrCodigoMaterial { get; set; }

    }

}