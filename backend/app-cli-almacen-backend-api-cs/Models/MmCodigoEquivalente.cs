/*
 * @overview        {MmCodigoEquivalente}
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
     * TODO: Description of {@code MmCodigoEquivalente}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
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