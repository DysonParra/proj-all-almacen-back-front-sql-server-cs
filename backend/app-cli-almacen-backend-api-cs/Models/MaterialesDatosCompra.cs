/*
 * @overview        {MaterialesDatosCompra}
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
     * TODO: Description of {@code MaterialesDatosCompra}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MaterialesDatosCompra {

        [Key]
        public Int64? IntIdMaterialDatoCompra { get; set; }
        public String? StrCodigoMaterialCompra { get; set; }
        public Boolean? BitAutomaticPurchase { get; set; }
        public Boolean? BitGestionLotes { get; set; }
        public Decimal? DecToleranciaEntregaInferior { get; set; }
        public Decimal? DecToleranciaEntregaSuperior { get; set; }
        public Int32? IntDiasEntrega { get; set; }
        public Boolean? BitRequiereInspeccion { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdMaterial { get; set; }
        public Int64? IntIdInterlocutor { get; set; }
        public String? StrCodigoMaterial { get; set; }
        public Int64? IntIdUnidadMedidaBase { get; set; }
        public Int64? IntIdUnidadMedidaCompra { get; set; }

    }

}