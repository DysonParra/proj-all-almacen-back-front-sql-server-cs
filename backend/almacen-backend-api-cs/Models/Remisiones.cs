/*
 * @fileoverview    {Remisiones}
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
 * TODO: Description of {@code Remisiones}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Remisiones {

        [Key]
        public Int64? IntIdRemision { get; set; }
        public String? StrNumeroGuia { get; set; }
        public DateTime? DtFechaCreacion { get; set; }
        public DateTime? DtFechaRecepcion { get; set; }
        public Int32? IntConcecutivoInterno { get; set; }
        public String? StrUsuario { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int64? IntIdAgenteDestino { get; set; }
        public Int64? IntIdAgenteOrigen { get; set; }
        public Int64? IntIdEstadoRemision { get; set; }

    }

}