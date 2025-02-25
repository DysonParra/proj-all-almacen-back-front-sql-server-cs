/*
 * @fileoverview    {AlmacenContext}
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Almacen.Data {

    /**
     * TODO: Description of {@code AlmacenContext}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class AlmacenContext : DbContext {
        public AlmacenContext (DbContextOptions<AlmacenContext> options)
            : base(options) {
        }

        public DbSet<Project.Models.Agentes> Agentes { get; set; } = default!;

        public DbSet<Project.Models.Bodegas> Bodegas { get; set; }

        public DbSet<Project.Models.CentrosTrabajos> CentrosTrabajos { get; set; }

        public DbSet<Project.Models.Componentes> Componentes { get; set; }

        public DbSet<Project.Models.Conceptos> Conceptos { get; set; }

        public DbSet<Project.Models.CondicionesPagos> CondicionesPagos { get; set; }

        public DbSet<Project.Models.Consecutivos> Consecutivos { get; set; }

        public DbSet<Project.Models.Cotizacion> Cotizacion { get; set; }

        public DbSet<Project.Models.EstadosMovimientos> EstadosMovimientos { get; set; }

        public DbSet<Project.Models.EstadosRemisiones> EstadosRemisiones { get; set; }

        public DbSet<Project.Models.EstadosSaldos> EstadosSaldos { get; set; }

        public DbSet<Project.Models.GrupoInterlocutores> GrupoInterlocutores { get; set; }

        public DbSet<Project.Models.InterlocutoresComerciales> InterlocutoresComerciales { get; set; }

        public DbSet<Project.Models.InterlocutoresCondicionPago> InterlocutoresCondicionPago { get; set; }

        public DbSet<Project.Models.InterlocutorFinanzas> InterlocutorFinanzas { get; set; }

        public DbSet<Project.Models.ListaDeMateriales> ListaDeMateriales { get; set; }

        public DbSet<Project.Models.ListasPrecios> ListasPrecios { get; set; }

        public DbSet<Project.Models.ListasPreciosMateriales> ListasPreciosMateriales { get; set; }

        public DbSet<Project.Models.Localizaciones> Localizaciones { get; set; }

        public DbSet<Project.Models.Materiales> Materiales { get; set; }

        public DbSet<Project.Models.MaterialesCaracteristicas> MaterialesCaracteristicas { get; set; }

        public DbSet<Project.Models.MaterialesCostosPromedios> MaterialesCostosPromedios { get; set; }

        public DbSet<Project.Models.MaterialesDatosCompra> MaterialesDatosCompra { get; set; }

        public DbSet<Project.Models.MaterialesDescripciones> MaterialesDescripciones { get; set; }

        public DbSet<Project.Models.MmCodigoEquivalente> MmCodigoEquivalente { get; set; }

        public DbSet<Project.Models.MmTmcCaracteristica> MmTmcCaracteristica { get; set; }

        public DbSet<Project.Models.MmTmcdDescripciones> MmTmcdDescripciones { get; set; }

        public DbSet<Project.Models.Movimientos> Movimientos { get; set; }

        public DbSet<Project.Models.OrdenDeTrabajo> OrdenDeTrabajo { get; set; }

        public DbSet<Project.Models.OrdenProduccion> OrdenProduccion { get; set; }

        public DbSet<Project.Models.PlanCompra> PlanCompra { get; set; }

        public DbSet<Project.Models.Remisiones> Remisiones { get; set; }

        public DbSet<Project.Models.RemisionesCompras> RemisionesCompras { get; set; }

        public DbSet<Project.Models.RemisionesComprasMateriales> RemisionesComprasMateriales { get; set; }

        public DbSet<Project.Models.RemisionesVenta> RemisionesVenta { get; set; }

        public DbSet<Project.Models.RemisionesVentaMateriales> RemisionesVentaMateriales { get; set; }

        public DbSet<Project.Models.Saldos> Saldos { get; set; }

        public DbSet<Project.Models.Sociedad> Sociedad { get; set; }

        public DbSet<Project.Models.TipoInterlocutorComercial> TipoInterlocutorComercial { get; set; }

        public DbSet<Project.Models.TipoListaMaterial> TipoListaMaterial { get; set; }

        public DbSet<Project.Models.TiposAgentes> TiposAgentes { get; set; }

        public DbSet<Project.Models.TiposDocumentos> TiposDocumentos { get; set; }

        public DbSet<Project.Models.TiposDocumentosConceptos> TiposDocumentosConceptos { get; set; }

        public DbSet<Project.Models.TiposDocumentosTiposAgentes> TiposDocumentosTiposAgentes { get; set; }

        public DbSet<Project.Models.TiposMateriales> TiposMateriales { get; set; }

        public DbSet<Project.Models.TiposMovimientos> TiposMovimientos { get; set; }

        public DbSet<Project.Models.TipoUnidadMedida> TipoUnidadMedida { get; set; }

        public DbSet<Project.Models.Ubicaciones> Ubicaciones { get; set; }

        public DbSet<Project.Models.UnidadMedida> UnidadMedida { get; set; }

        public DbSet<Project.Models.Zonas> Zonas { get; set; }

        public DbSet<Project.Models.MovimientosDetalles> MovimientosDetalles { get; set; }
    }
}
