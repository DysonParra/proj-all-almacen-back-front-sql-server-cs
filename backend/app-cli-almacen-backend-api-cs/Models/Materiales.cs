/*
 * @fileoverview    {Materiales}
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
     * TODO: Description of {@code Materiales}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Materiales {

        [Key]
        public Int64? IntIdMaterial { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public String? StrReferencia { get; set; }
        public Boolean? BitGeneraRecibo { get; set; }
        public Boolean? BitVentaApartado { get; set; }
        public Boolean? BitPermiteDevolucion { get; set; }
        public String? StrSimbolo { get; set; }
        public Single? FltValorUnitario { get; set; }
        public Single? FltCosto { get; set; }
        public Boolean? BitConsumible { get; set; }
        public Boolean? BitProducible { get; set; }
        public Boolean? BitComprable { get; set; }
        public Boolean? BitVendible { get; set; }
        public Boolean? BitActivo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdTiposMateriales { get; set; }

    }

}