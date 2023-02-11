/*
 * @fileoverview    {CondicionesPagos} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code CondicionesPagos}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class CondicionesPagos {

        [Key]
        public Int64? IntIdCondicionPago { get; set; }
        public String? StrNombreCondicion { get; set; }
        public String? StrDescripcion { get; set; }
        public Boolean? BitDeudor { get; set; }
        public Boolean? BitAcreedor { get; set; }
        public Int32? IntDiiaFijo { get; set; }
        public Int32? IntMesesAdicionales { get; set; }
        public Int32? IntDiasTolerancia { get; set; }
        public Int32? IntNumeroPlazos { get; set; }
        public Single? FltDescuentoTotal { get; set; }
        public Single? FltInteresCredito { get; set; }
        public Decimal? DecHaberMaximo { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }

    }

}