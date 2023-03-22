/*
 * @fileoverview    {MaterialesDatosCompra}
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
 * TODO: Definición de {@code MaterialesDatosCompra}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

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