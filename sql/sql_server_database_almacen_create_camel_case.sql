USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Almacen') DROP DATABASE [Almacen]
GO
CREATE DATABASE [Almacen];
GO
USE [Almacen];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CentrosTrabajos')
CREATE TABLE [dbo].[CentrosTrabajos] (
    [IdCentroDeTrabajo]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdInterlocutorComercial]           BIGINT                  NULL DEFAULT NULL,
    [IdCategoriaCentro]                 BIGINT                  NULL DEFAULT NULL,
    [Costo]                             DECIMAL(18, 1)          NULL DEFAULT NULL,
    [IdBodega]                          BIGINT                  NULL DEFAULT NULL,
    [IdMetodoCosteo]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conceptos')
CREATE TABLE [dbo].[Conceptos] (
    [IdConcepto]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionConcepto]               VARCHAR(255)            NULL DEFAULT NULL,
    [Reposicion]                        BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CondicionesPagos')
CREATE TABLE [dbo].[CondicionesPagos] (
    [IdCondicionPago]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NombreCondicion]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Deudor]                            BIT                     NULL DEFAULT NULL,
    [Acreedor]                          BIT                     NULL DEFAULT NULL,
    [DiiaFijo]                          INT                     NULL DEFAULT NULL,
    [MesesAdicionales]                  INT                     NULL DEFAULT NULL,
    [DiasTolerancia]                    INT                     NULL DEFAULT NULL,
    [NumeroPlazos]                      INT                     NULL DEFAULT NULL,
    [DescuentoTotal]                    FLOAT                   NULL DEFAULT NULL,
    [InteresCredito]                    FLOAT                   NULL DEFAULT NULL,
    [HaberMaximo]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosMovimientos')
CREATE TABLE [dbo].[EstadosMovimientos] (
    [IdEstadoMovimiento]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionEstadoMovimiento]       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosRemisiones')
CREATE TABLE [dbo].[EstadosRemisiones] (
    [IdEstadoRemision]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionEstadoRemision]         VARCHAR(255)        NOT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosSaldos')
CREATE TABLE [dbo].[EstadosSaldos] (
    [IdEstadoSaldo]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionEstadoSaldo]            VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoColor]                       VARCHAR(255)            NULL DEFAULT NULL,
    [EstaEnReposicion]                  BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListasPrecios')
CREATE TABLE [dbo].[ListasPrecios] (
    [IdListaPrecio]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NombreListaPrecios]                VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionListaPrecios]           VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'GrupoInterlocutores')
CREATE TABLE [dbo].[GrupoInterlocutores] (
    [IdGrupoInterlocutor]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NombreGrupo]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(255)            NULL DEFAULT NULL,
    [CuentaContable]                    VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdListaPrecio]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListasPreciosMateriales')
CREATE TABLE [dbo].[ListasPreciosMateriales] (
    [Id]                                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdMateriales]                      BIGINT              NOT NULL,
    [IdListasPrecios]                   BIGINT              NOT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'PlanCompra')
CREATE TABLE [dbo].[PlanCompra] (
    [IdPlanCompra]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    BIGINT                  NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(100)        NOT NULL,
    [Cantidad]                          FLOAT               NOT NULL,
    [IdGrupoProveedor]                  INT                     NULL DEFAULT NULL,
    [FechaExplosion]                    DATETIME                NULL DEFAULT NULL,
    [FechaCreacion]                     DATETIME                NULL DEFAULT NULL,
    [FechaModificacion]                 DATETIME                NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Estado]                            VARCHAR(10)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Cotizacion')
CREATE TABLE [dbo].[Cotizacion] (
    [IdCotizacion]                      INT                 NOT NULL PRIMARY KEY IDENTITY,
    [Cabecera]                          INT                     NULL DEFAULT NULL,
    [IdPlanCompra]                      BIGINT                  NULL,
    [IdProveedor]                       INT                 NOT NULL,
    [Estado]                            VARCHAR(20)             NULL DEFAULT NULL,
    [CodigoMaterial]                    BIGINT                  NULL DEFAULT NULL,
    [DescripcionMaterial]               VARCHAR(256)            NULL DEFAULT NULL,
    [NombreProveedor]                   VARCHAR(256)            NULL DEFAULT NULL,
    [BuzonProveedor]                    VARCHAR(256)            NULL DEFAULT NULL,
    [CantidadRequerida]                 FLOAT               NOT NULL,
    [CantidadCotizada]                  FLOAT               NOT NULL,
    [ValorCotizado]                     FLOAT                   NULL DEFAULT NULL,
    [Descuento]                         FLOAT                   NULL DEFAULT NULL,
    [FechaNecesaria]                    DATETIME                NULL DEFAULT NULL,
    [FechaEntrega]                      DATETIME            NOT NULL,
    [FechaCreacion]                     DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sociedad')
CREATE TABLE [dbo].[Sociedad] (
    [IdSociedad]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoSociedad]                    VARCHAR(255)            NULL DEFAULT NULL,
    [NombreSociedad]                    VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionSociedad]               VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoInterlocutorComercial')
CREATE TABLE [dbo].[TipoInterlocutorComercial] (
    [IdTipoInterlocutorComercial]       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [TipoInterlocutor]                  VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionTipoInterlocutor]       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutoresComerciales')
CREATE TABLE [dbo].[InterlocutoresComerciales] (
    [IdInterlocutorComercial]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoInterlocutor]                VARCHAR(255)            NULL DEFAULT NULL,
    [NumeroIdentificacionFinanciera]    VARCHAR(255)            NULL DEFAULT NULL,
    [NombreInterlocutor]                VARCHAR(255)            NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(255)            NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fax]                               VARCHAR(255)            NULL DEFAULT NULL,
    [Email]                             VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdGrupoInterlocutor]               BIGINT                  NULL DEFAULT NULL,
    [IdTipoInterlocutor]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutorFinanzas')
CREATE TABLE [dbo].[InterlocutorFinanzas] (
    [IdInterlocutorFinanzas]            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Impuesto]                          BIT                     NULL DEFAULT NULL,
    [SujetoRetencion]                   BIT                     NULL DEFAULT NULL,
    [NumeroCertificadoRetencion]        VARCHAR(255)            NULL DEFAULT NULL,
    [FechaVencimiento]                  DATETIME                NULL DEFAULT NULL,
    [NumeroAfiliacionSeguridad]         VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutoresCondicionPago')
CREATE TABLE [dbo].[InterlocutoresCondicionPago] (
    [IdInterlocutorCondicionPago]       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NombreCondicion]                   VARCHAR(255)            NULL DEFAULT NULL,
    [InteresMora]                       FLOAT                   NULL DEFAULT NULL,
    [DescuentoTotal]                    FLOAT                   NULL DEFAULT NULL,
    [CupoCredito]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [NumeroCuenta]                      VARCHAR(255)            NULL DEFAULT NULL,
    [Sucursal]                          VARCHAR(255)            NULL DEFAULT NULL,
    [ClaveControl]                      VARCHAR(255)            NULL DEFAULT NULL,
    [EntregaParcial]                    BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdListaPrecio]                     BIGINT                  NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL,
    [IdCondicionPago]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoListaMaterial')
CREATE TABLE [dbo].[TipoListaMaterial] (
    [IdTipoListaMaterial]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NombreTipoLista]                   VARCHAR(20)             NULL DEFAULT NULL,
    [DescripcionLista]                  VARCHAR(200)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoUnidadMedida')
CREATE TABLE [dbo].[TipoUnidadMedida] (
    [IdTipoUnidadMedida]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposAgentes')
CREATE TABLE [dbo].[TiposAgentes] (
    [IdTipoAgente]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionTipoAgente]             VARCHAR(255)            NULL DEFAULT NULL,
    [TablaInformacion]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Agentes')
CREATE TABLE [dbo].[Agentes] (
    [IdAgente]                          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdTipoAgente]                      BIGINT                  NULL DEFAULT NULL,
    [IdEntidad]                         INT                     NULL DEFAULT NULL,
    [IdAlmacen]                         INT                     NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [IdSociedad]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Bodegas')
CREATE TABLE [dbo].[Bodegas] (
    [IdBodega]                          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoBodega]                      VARCHAR(20)             NULL DEFAULT NULL,
    [DescripcionBodega]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [IdAgente]                          BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Localizaciones')
CREATE TABLE [dbo].[Localizaciones] (
    [IdLocalizacion]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdBodega]                          BIGINT                  NULL DEFAULT NULL,
    [NombreLocalizacion]                VARCHAR(255)            NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoPostal]                      VARCHAR(255)            NULL DEFAULT NULL,
    [PoBox]                             VARCHAR(255)            NULL DEFAULT NULL,
    [Ciudad]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Pais]                              VARCHAR(255)            NULL DEFAULT NULL,
    [Region]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(255)            NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fax]                               VARCHAR(255)            NULL DEFAULT NULL,
    [Email]                             VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones')
CREATE TABLE [dbo].[Remisiones] (
    [IdRemision]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroGuia]                        VARCHAR(255)            NULL DEFAULT NULL,
    [FechaCreacion]                     DATETIME                NULL DEFAULT NULL,
    [FechaRecepcion]                    DATETIME                NULL DEFAULT NULL,
    [ConcecutivoInterno]                INT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdAgenteOrigen]                    BIGINT                  NULL DEFAULT NULL,
    [IdAgenteDestino]                   BIGINT                  NULL DEFAULT NULL,
    [IdEstadoRemision]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposMateriales')
CREATE TABLE [dbo].[TiposMateriales] (
    [IdTipoMaterial]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [TipoMaterial]                      VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionTipoMaterial]           VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales')
CREATE TABLE [dbo].[Materiales] (
    [IdMaterial]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [Referencia]                        VARCHAR(255)            NULL DEFAULT NULL,
    [GeneraRecibo]                      BIT                     NULL DEFAULT NULL,
    [VentaApartado]                     BIT                     NULL DEFAULT NULL,
    [PermiteDevolucion]                 BIT                     NULL DEFAULT NULL,
    [Simbolo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [ValorUnitario]                     FLOAT                   NULL DEFAULT NULL,
    [Costo]                             FLOAT                   NULL DEFAULT NULL,
    [Consumible]                        BIT                     NULL DEFAULT NULL,
    [Producible]                        BIT                     NULL DEFAULT NULL,
    [Comprable]                         BIT                     NULL DEFAULT NULL,
    [Vendible]                          BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTiposMateriales]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesCostosPromedios')
CREATE TABLE [dbo].[MaterialesCostosPromedios] (
    [IdMaterialCostoPromedio]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [CostoPromedio]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [FechaInicial]                      DATETIME                NULL DEFAULT NULL,
    [FechaFinal]                        DATETIME                NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesDescripciones')
CREATE TABLE [dbo].[MaterialesDescripciones] (
    [IdMaterialDescripcion]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [Cultura]                           VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionMaterial]               VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmCodigoEquivalente')
CREATE TABLE [dbo].[MmCodigoEquivalente] (
    [IdMmCodigoEquivalente]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [TipoCodigoEquivalente]             VARCHAR(255)            NULL DEFAULT NULL,
    [ValorCodigoEquivalente]            VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmTmcCaracteristica')
CREATE TABLE [dbo].[MmTmcCaracteristica] (
    [IdMmTmcCaracteristica]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdTipoMaterialCaracteristica]      BIGINT                  NULL DEFAULT NULL,
    [TipoMaterial]                      VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionTipoMaterialCaracteristica]     VARCHAR(255)    NULL DEFAULT NULL,
    [TipoDato]                          INT                     NULL DEFAULT NULL,
    [ReglaValidacion]                   VARCHAR(255)            NULL DEFAULT NULL,
    [VisibleDetalle]                    BIT                     NULL DEFAULT NULL,
    [OrdenDetall]                       INT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoMaterial]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesCaracteristicas')
CREATE TABLE [dbo].[MaterialesCaracteristicas] (
    [IdMaterialCaracteristica]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [ValorCaracteristica]               VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoMaterialCaracteristica]      BIGINT                  NULL DEFAULT NULL,
    [IdTipoMaterial]                    BIGINT                  NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmTmcdDescripciones')
CREATE TABLE [dbo].[MmTmcdDescripciones] (
    [IdMmTmcdDescripciones]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdTipoMaterialCaracteristica]      BIGINT                  NULL DEFAULT NULL,
    [Cultura]                           VARCHAR(255)            NULL DEFAULT NULL,
    [DescripcionMaterial]               VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposMovimientos')
CREATE TABLE [dbo].[TiposMovimientos] (
    [IdTipoMovimiento]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionTipoMovimiento]         VARCHAR(255)            NULL DEFAULT NULL,
    [Signo]                             BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentos')
CREATE TABLE [dbo].[TiposDocumentos] (
    [IdTipoDocumento]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [DescripcionTipoDocumento]          VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoMovimiento]                  BIGINT                  NULL DEFAULT NULL,
    [IdEstadoRemision]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Consecutivos')
CREATE TABLE [dbo].[Consecutivos] (
    [IdConsecutivo]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Resolucion]                        VARCHAR(255)            NULL DEFAULT NULL,
    [ValorInicial]                      INT                     NULL DEFAULT NULL,
    [ValorFinal]                        INT                     NULL DEFAULT NULL,
    [Incremento]                        INT                     NULL DEFAULT NULL,
    [ValorActual]                       INT                     NULL DEFAULT NULL,
    [CaracterLlenado]                   VARCHAR(255)            NULL DEFAULT NULL,
    [FechaInicial]                      DATETIME                NULL DEFAULT NULL,
    [FechaFinal]                        DATETIME                NULL DEFAULT NULL,
    [Sufijo]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Prefijo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Habilitado]                        BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Movimientos')
CREATE TABLE [dbo].[Movimientos] (
    [IdMovimiento]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdRemision]                        BIGINT                  NULL DEFAULT NULL,
    [NumeroDocumento]                   VARCHAR(255)            NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL,
    [IdTipoMovimiento]                  BIGINT                  NULL DEFAULT NULL,
    [IdEstadoMovimiento]                BIGINT                  NULL DEFAULT NULL,
    [IdConcepto]                        BIGINT                  NULL DEFAULT NULL,
    [FechaCreacion]                     DATETIME            NOT NULL DEFAULT GETDATE(),
    [FechaAnulacion]                    DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01',
    [IdBodega]                          BIGINT                  NULL DEFAULT NULL,
    [SobreCosto]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [SobreCostoAplicadoProducto]        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01'
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MovimientosDetalles')
CREATE TABLE [dbo].[MovimientosDetalles] (
    [IdMovimientoDetalle]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroDocumento]                   VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoProducto]                    VARCHAR(255)            NULL DEFAULT NULL,
    [ValorUnitario]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [SobreCosto]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Cantidad]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [IdEstadoSaldo]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesCompras')
CREATE TABLE [dbo].[RemisionesCompras] (
    [IdRemisionCompra]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroRemisionCompra]              VARCHAR(255)            NULL DEFAULT NULL,
    [FechaContabilizacion]              DATETIME                NULL DEFAULT NULL,
    [FechaValidez]                      DATETIME                NULL DEFAULT NULL,
    [FechaDocumento]                    DATETIME                NULL DEFAULT NULL,
    [FechaNecesaria]                    DATETIME                NULL DEFAULT NULL,
    [NumeroReferencia]                  VARCHAR(255)            NULL DEFAULT NULL,
    [TotalBruto]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PorcentajeDescuento]               FLOAT                   NULL DEFAULT NULL,
    [PorcentajeImpuesto]                FLOAT                   NULL DEFAULT NULL,
    [ValorTotal]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Comentarios]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL,
    [IdRemision]                        BIGINT                  NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesComprasMateriales')
CREATE TABLE [dbo].[RemisionesComprasMateriales] (
    [IdRemisionCompraMaterial]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroRemisionCompra]              VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [FechaNecesaria]                    DATETIME                NULL DEFAULT NULL,
    [FechaSolicitud]                    DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          FLOAT                   NULL DEFAULT NULL,
    [ValorUnitario]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PorcentajeDescuento]               FLOAT                   NULL DEFAULT NULL,
    [CostoPromedio]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdRemisionCompra]                  BIGINT                  NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesVenta')
CREATE TABLE [dbo].[RemisionesVenta] (
    [NumeroDocumento]                   VARCHAR(255)        NOT NULL PRIMARY KEY,
    [FechaContabilizacion]              DATETIME                NULL DEFAULT NULL,
    [FechaValidez]                      DATETIME                NULL DEFAULT NULL,
    [FechaDocumento]                    DATETIME                NULL DEFAULT NULL,
    [FechaNecesaria]                    DATETIME                NULL DEFAULT NULL,
    [NumeroReferencia]                  VARCHAR(255)            NULL DEFAULT NULL,
    [TotalBruto]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PorcentajeDescuento]               FLOAT                   NULL DEFAULT NULL,
    [PorcentajeImpuesto]                FLOAT                   NULL DEFAULT NULL,
    [ValorTotal]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Comentarios]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL,
    [IdRemision]                        BIGINT                  NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL,
    [ListaPrecio]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentosConceptos')
CREATE TABLE [dbo].[TiposDocumentosConceptos] (
    [IdTipoDocumentoConcepto]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL,
    [IdConcepto]                        BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentosTiposAgentes')
CREATE TABLE [dbo].[TiposDocumentosTiposAgentes] (
    [IdTipoDocumentoTipoAgente]         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoDocumento]                   BIGINT                  NULL DEFAULT NULL,
    [IdTipoAgente]                      BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'UnidadMedida')
CREATE TABLE [dbo].[UnidadMedida] (
    [IdUnidadMedida]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Simbolo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Factor]                            FLOAT                   NULL DEFAULT NULL,
    [Precision]                         FLOAT                   NULL DEFAULT NULL,
    [Conversion]                        FLOAT                   NULL DEFAULT NULL,
    [Decimales]                         INT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdTipoUnidadMedida]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListaDeMateriales')
CREATE TABLE [dbo].[ListaDeMateriales] (
    [IdListaMaterial]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdUnidadMedida]                    BIGINT                  NULL DEFAULT NULL,
    [IdTipoListaMaterial]               BIGINT                  NULL DEFAULT NULL,
    [IdBodega]                          BIGINT                  NULL DEFAULT NULL,
    [FechaInicio]                       DATETIME                NULL DEFAULT NULL,
    [FechaFin]                          DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          INT                     NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoComponente]                  VARCHAR(255)            NULL DEFAULT NULL,
    [IdListaPrecio]                     BIGINT                  NULL DEFAULT NULL,
    [PrecioUnitario]                    DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesDatosCompra')
CREATE TABLE [dbo].[MaterialesDatosCompra] (
    [IdMaterialDatoCompra]              BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoMaterialCompra]              VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [AutomaticPurchase]                 BIT                     NULL DEFAULT NULL,
    [GestionLotes]                      BIT                     NULL DEFAULT NULL,
    [ToleranciaEntregaInferior]         DECIMAL(10, 2)          NULL DEFAULT NULL,
    [ToleranciaEntregaSuperior]         DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DiasEntrega]                       INT                     NULL DEFAULT NULL,
    [RequiereInspeccion]                BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [IdUnidadMedidaBase]                BIGINT                  NULL DEFAULT NULL,
    [IdUnidadMedidaCompra]              BIGINT                  NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL,
    [IdInterlocutor]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'OrdenProduccion')
CREATE TABLE [dbo].[OrdenProduccion] (
    [NumeroOrden]                       VARCHAR(20)         NOT NULL PRIMARY KEY,
    [Referencia]                        VARCHAR(20)             NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [IdEstadoProduccion]                BIGINT                  NULL DEFAULT NULL,
    [IdRutaOrdenTrabajo]                BIGINT                  NULL DEFAULT NULL,
    [IdListaMateriales]                 BIGINT                  NULL DEFAULT NULL,
    [IdUnidadMedida]                    BIGINT                  NULL DEFAULT NULL,
    [IdCentroTrabajo]                   BIGINT                  NULL DEFAULT NULL,
    [FechaEstimada]                     DATETIME                NULL DEFAULT NULL,
    [FechaInicioEstimada]               DATETIME                NULL DEFAULT NULL,
    [FechaFinalizacion]                 DATETIME                NULL DEFAULT NULL,
    [CantidadPlanificada]               DECIMAL(18, 1)          NULL DEFAULT NULL,
    [OrigenOrden]                       VARCHAR(20)             NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(20)             NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Componentes')
CREATE TABLE [dbo].[Componentes] (
    [IdComponente]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroOrden]                       VARCHAR(20)             NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [IdUnidadMedida]                    BIGINT                  NULL DEFAULT NULL,
    [IdAlmacen]                         BIGINT                  NULL DEFAULT NULL,
    [CantidadBase]                      DECIMAL(18, 1)          NULL DEFAULT NULL,
    [CantidadRequerida]                 DECIMAL(18, 1)          NULL DEFAULT NULL,
    [CantidadAdicional]                 DECIMAL(18, 1)          NULL DEFAULT NULL,
    [CantidadConsumida]                 DECIMAL(18, 1)          NULL DEFAULT NULL,
    [FechaEstimada]                     DATETIME                NULL DEFAULT NULL,
    [FechaEfectiva]                     DATETIME                NULL DEFAULT NULL,
    [FechaInicio]                       DATETIME                NULL DEFAULT NULL,
    [FechaFinal]                        DATETIME                NULL DEFAULT NULL,
    [IdEstadoComponente]                BIGINT                  NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(20)             NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'OrdenDeTrabajo')
CREATE TABLE [dbo].[OrdenDeTrabajo] (
    [IdOrdenTrabajo]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdOperacion]                       BIGINT                  NULL DEFAULT NULL,
    [IdCentroTrabajo]                   BIGINT                  NULL DEFAULT NULL,
    [IdEstadoOT]                        BIGINT                  NULL DEFAULT NULL,
    [NumeroOrden]                       VARCHAR(20)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesVentaMateriales')
CREATE TABLE [dbo].[RemisionesVentaMateriales] (
    [IdRemisionVentaMaterial]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [NumeroDocumento]                   VARCHAR(255)            NULL DEFAULT NULL,
    [CodigoMaterial]                    VARCHAR(255)            NULL DEFAULT NULL,
    [FechaNecesaria]                    DATETIME                NULL DEFAULT NULL,
    [FechaSolicitud]                    DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          FLOAT                   NULL DEFAULT NULL,
    [ValorUnitario]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PorcentajeDescuento]               FLOAT                   NULL DEFAULT NULL,
    [CostoPromedio]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [IdRemisionCompra]                  BIGINT                  NULL DEFAULT NULL,
    [IdMaterial]                        BIGINT                  NULL DEFAULT NULL,
    [IdUnidadMedida]                    BIGINT                  NULL DEFAULT NULL,
    [CantidadUnidadMedida]              DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Zonas')
CREATE TABLE [dbo].[Zonas] (
    [CodigoZona]                        VARCHAR(20)         NOT NULL PRIMARY KEY,
    [IdBodega]                          BIGINT                  NULL DEFAULT NULL,
    [DescripcionZona]                   VARCHAR(255)            NULL DEFAULT NULL,
    [TransitoDirecto]                   BIT                     NULL DEFAULT NULL,
    [Picking]                           BIT                     NULL DEFAULT NULL,
    [Ubicacion]                         BIT                     NULL DEFAULT NULL,
    [Despacho]                          BIT                     NULL DEFAULT NULL,
    [Recepcion]                         BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE()
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ubicaciones')
CREATE TABLE [dbo].[Ubicaciones] (
    [IdUbicacion]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [CodigoUbicacion]                   VARCHAR(20)         NOT NULL,
    [CodigoZona]                        VARCHAR(20)             NULL DEFAULT NULL,
    [DescripcionUbicacion]              VARCHAR(255)            NULL DEFAULT NULL,
    [Dedicado]                          BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE()
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Saldos')
CREATE TABLE [dbo].[Saldos] (
    [IdSaldo]                           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdEstadoSaldo]                     BIGINT                  NULL DEFAULT NULL,
    [IdUbicacion]                       BIGINT                  NULL DEFAULT NULL,
    [CodigoProducto]                    VARCHAR(255)            NULL DEFAULT NULL,
    [Cantidad]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE()
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [GrupoInterlocutores]
    ADD CONSTRAINT [FkGrupoInterlocutoresListaPrecioId]
        FOREIGN KEY ([IdListaPrecio])
        REFERENCES [ListasPrecios] ([IdListaPrecio]);

ALTER TABLE [Cotizacion]
    ADD CONSTRAINT [CotizacionPlanCompraIdFk]
        FOREIGN KEY ([IdPlanCompra])
        REFERENCES [PlanCompra] ([IdPlanCompra]);

ALTER TABLE [InterlocutoresComerciales]
    ADD CONSTRAINT [FkInterlocutoresComercialesGrupoInterlocutorId]
        FOREIGN KEY ([IdGrupoInterlocutor])
        REFERENCES [GrupoInterlocutores] ([IdGrupoInterlocutor]),
    CONSTRAINT [FkInterlocutoresComercialesTipointerlocutorId]
        FOREIGN KEY ([IdTipoInterlocutor])
        REFERENCES [TipoInterlocutorComercial] ([IdTipoInterlocutorComercial]);

ALTER TABLE [InterlocutorFinanzas]
    ADD CONSTRAINT [FkInterlocutoresComercialesFinanzasInterlocutorId]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial]);

ALTER TABLE [InterlocutoresCondicionPago]
    ADD CONSTRAINT [FkInterlocutoresCondicionPagoCondicionPagoId]
        FOREIGN KEY ([IdCondicionPago])
        REFERENCES [CondicionesPagos] ([IdCondicionPago]),
    CONSTRAINT [FkInterlocutoresCondicionPagoListaPrecioId]
        FOREIGN KEY ([IdListaPrecio])
        REFERENCES [ListasPrecios] ([IdListaPrecio]),
    CONSTRAINT [FkInterlocutoresCondicionPagoInterlocutorId]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial]);

ALTER TABLE [Agentes]
    ADD CONSTRAINT [AgentesSociedadIdFk]
        FOREIGN KEY ([IdSociedad])
        REFERENCES [Sociedad] ([IdSociedad])
        ON UPDATE NO ACTION,
    CONSTRAINT [AgentesTiposAgentesIdFk]
        FOREIGN KEY ([IdTipoAgente])
        REFERENCES [TiposAgentes] ([IdTipoAgente])
        ON UPDATE NO ACTION;

ALTER TABLE [Bodegas]
    ADD CONSTRAINT [BodegasCodigoBodegaUindex]
        UNIQUE ([CodigoBodega]),
    CONSTRAINT [BodegasAgentesIdFk]
        FOREIGN KEY ([IdAgente])
        REFERENCES [Agentes] ([IdAgente])
        ON UPDATE NO ACTION;

ALTER TABLE [Localizaciones]
    ADD CONSTRAINT [FkLocalizacionesInterlocutorId]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial]),
    CONSTRAINT [LocalizacionesBodegasIdFk]
        FOREIGN KEY ([IdBodega])
        REFERENCES [Bodegas] ([IdBodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Remisiones]
    ADD CONSTRAINT [FkRemisionesAgentedestinoId]
        FOREIGN KEY ([IdAgenteDestino])
        REFERENCES [Agentes] ([IdAgente]),
    CONSTRAINT [FkRemisionesAgenteorigenId]
        FOREIGN KEY ([IdAgenteOrigen])
        REFERENCES [Agentes] ([IdAgente]),
    CONSTRAINT [FkRemisionesEstadoRemisionId]
        FOREIGN KEY ([IdEstadoRemision])
        REFERENCES [EstadosRemisiones] ([IdEstadoRemision]);

ALTER TABLE [Materiales]
    ADD CONSTRAINT [MaterialesCodigoProductoUindex]
        UNIQUE ([CodigoMaterial]),
    CONSTRAINT [MaterialesTiposMaterialesIdTipoMaterialFk]
        FOREIGN KEY ([IdTiposMateriales])
        REFERENCES [TiposMateriales] ([IdTipoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesCostosPromedios]
    ADD CONSTRAINT [MaterialesCostosPromediosMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesDescripciones]
    ADD CONSTRAINT [MaterialesDescripcionesMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial]);

ALTER TABLE [MmCodigoEquivalente]
    ADD CONSTRAINT [MmCodigoEquivalenteMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MmTmcCaracteristica]
    ADD CONSTRAINT [FkTiposMaterialesCaracteristicasTipoMaterialId]
        FOREIGN KEY ([IdTipoMaterial])
        REFERENCES [TiposMateriales] ([IdTipoMaterial]);

ALTER TABLE [MaterialesCaracteristicas]
    ADD CONSTRAINT [MaterialesCaracteristicasMaterialesIdMaterialFk]
        FOREIGN KEY ([IdMaterial])
        REFERENCES [Materiales] ([IdMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesCaracteristicasMmTmcCaracteristicaFk]
        FOREIGN KEY ([IdTipoMaterialCaracteristica])
        REFERENCES [MmTmcCaracteristica] ([IdMmTmcCaracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesCaracteristicas]
    ADD CONSTRAINT [MaterialesCaracteristicasTiposMaterialesIdTipoMaterialFk]
        FOREIGN KEY ([IdTipoMaterial])
        REFERENCES [TiposMateriales] ([IdTipoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesCaracteristicasFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MmTmcdDescripciones]
    ADD CONSTRAINT [MmTmcdTmcFk]
        FOREIGN KEY ([IdTipoMaterialCaracteristica])
        REFERENCES [MmTmcCaracteristica] ([IdMmTmcCaracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [TiposDocumentos]
    ADD CONSTRAINT [FkTiposDocumentosEstadoRemisionId]
        FOREIGN KEY ([IdEstadoRemision])
        REFERENCES [EstadosRemisiones] ([IdEstadoRemision]),
    CONSTRAINT [FkTiposDocumentosTipoMovimientoId1]
        FOREIGN KEY ([IdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IdTipoMovimiento]),
    CONSTRAINT [FkTiposDocumentosTipomovimientoId2]
        FOREIGN KEY ([IdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IdTipoMovimiento]);

ALTER TABLE [Consecutivos]
    ADD CONSTRAINT [ConsecutivosTiposDocumentosIdFk]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [Movimientos]
    ADD CONSTRAINT [MovimientosNumeroDocumentoUindex]
        UNIQUE ([NumeroDocumento]),
    CONSTRAINT [MovimientosBodegasIdFk]
        FOREIGN KEY ([IdBodega])
        REFERENCES [Bodegas] ([IdBodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [MovimientosConceptosIdFk]
        FOREIGN KEY ([IdConcepto])
        REFERENCES [Conceptos] ([IdConcepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [MovimientosEstadosMovimientosIdFk]
        FOREIGN KEY ([IdEstadoMovimiento])
        REFERENCES [EstadosMovimientos] ([IdEstadoMovimiento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosRemisionesIdFk]
        FOREIGN KEY ([IdRemision])
        REFERENCES [Remisiones] ([IdRemision])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosTiposDocumentosIdFk]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosTiposMovimientosIdFk]
        FOREIGN KEY ([IdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IdTipoMovimiento])
        ON UPDATE NO ACTION;

ALTER TABLE [MovimientosDetalles]
    ADD CONSTRAINT [MovimientosDetallesEstadosSaldosIdFk]
        FOREIGN KEY ([IdEstadoSaldo])
        REFERENCES [EstadosSaldos] ([IdEstadoSaldo]),
    CONSTRAINT [MovimientosDetallesMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoProducto])
        REFERENCES [Materiales] ([CodigoMaterial]),
    CONSTRAINT [MovimientosDetallesMovimientosNumeroDocumentoFk]
        FOREIGN KEY ([NumeroDocumento])
        REFERENCES [Movimientos] ([NumeroDocumento]);

ALTER TABLE [RemisionesCompras]
    ADD CONSTRAINT [FkRemisionesComprasTipoDocumentoId]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento]),
    CONSTRAINT [FkRemisionesComprasInterlocutorId]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial]),
    CONSTRAINT [FkRemisionesComprasRemisionId]
        FOREIGN KEY ([IdRemision])
        REFERENCES [Remisiones] ([IdRemision]);

ALTER TABLE [RemisionesComprasMateriales]
    ADD CONSTRAINT [FkRemisionesComprasMaterialesMaterialId]
        FOREIGN KEY ([IdMaterial])
        REFERENCES [Materiales] ([IdMaterial]),
    CONSTRAINT [FkRemisionesComprasMaterialesRemisionCompraId]
        FOREIGN KEY ([IdRemisionCompra])
        REFERENCES [RemisionesCompras] ([IdRemisionCompra]);

ALTER TABLE [RemisionesVenta]
    ADD CONSTRAINT [RemisionesVentaListasPreciosIdListaPrecioFk]
        FOREIGN KEY ([ListaPrecio])
        REFERENCES [ListasPrecios] ([IdListaPrecio])
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRemisionesVentaTipoDocumentoId]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento]),
    CONSTRAINT [FkRemisionesVentaInterlocutorId]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial]),
    CONSTRAINT [FkRemisionesVentaRemisionId]
        FOREIGN KEY ([IdRemision])
        REFERENCES [Remisiones] ([IdRemision]);

ALTER TABLE [TiposDocumentosConceptos]
    ADD CONSTRAINT [TiposDocumentosConceptosConceptosIdFk]
        FOREIGN KEY ([IdConcepto])
        REFERENCES [Conceptos] ([IdConcepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [TiposDocumentosConceptosTiposDocumentosIdFk]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [TiposDocumentosTiposAgentes]
    ADD CONSTRAINT [TiposDocumentosTiposAgentesTiposAgentesIdFk]
        FOREIGN KEY ([IdTipoAgente])
        REFERENCES [TiposAgentes] ([IdTipoAgente])
        ON UPDATE NO ACTION,
    CONSTRAINT [TiposDocumentosTiposAgentesTiposDocumentosIdFk]
        FOREIGN KEY ([IdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [UnidadMedida]
    ADD CONSTRAINT [FkUnidadMedidaTipoUnidadMedidaId]
        FOREIGN KEY ([IdTipoUnidadMedida])
        REFERENCES [TipoUnidadMedida] ([IdTipoUnidadMedida]);

ALTER TABLE [ListaDeMateriales]
    ADD CONSTRAINT [ListaDeMaterialesPk]
        UNIQUE ([IdListaMaterial]),
    CONSTRAINT [ListaDeMaterialesBodegasIdBodegaFk]
        FOREIGN KEY ([IdBodega])
        REFERENCES [Bodegas] ([IdBodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesListasPreciosIdListaPrecioFk]
        FOREIGN KEY ([IdListaPrecio])
        REFERENCES [ListasPrecios] ([IdListaPrecio]),
    CONSTRAINT [ListaDeMaterialesMaterialesCodigoMaterialFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesMaterialesCodigoMaterialFk2]
        FOREIGN KEY ([CodigoComponente])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesIdTipoListaMaterialFk]
        FOREIGN KEY ([IdTipoListaMaterial])
        REFERENCES [TipoListaMaterial] ([IdTipoListaMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IdUnidadMedida])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesDatosCompra]
    ADD CONSTRAINT [MaterialesDatosCompraInterlocutoresComercialesFk]
        FOREIGN KEY ([IdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IdInterlocutorComercial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IdUnidadMedidaBase])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraUnidadMedidaIdUnidadMedidaFk2]
        FOREIGN KEY ([IdUnidadMedidaCompra])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [OrdenProduccion]
    ADD CONSTRAINT [OrdenProduccionListaDeMaterialesIdListaMaterialFk]
        FOREIGN KEY ([IdListaMateriales])
        REFERENCES [ListaDeMateriales] ([IdListaMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenProduccionMaterialesCodigoMaterialFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenProduccionUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IdUnidadMedida])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [Componentes]
    ADD CONSTRAINT [ComponentesMaterialesCodigoMaterialFk]
        FOREIGN KEY ([CodigoMaterial])
        REFERENCES [Materiales] ([CodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ComponentesOrdenProduccionNumeroOrdenFk]
        FOREIGN KEY ([NumeroOrden])
        REFERENCES [OrdenProduccion] ([NumeroOrden])
        ON UPDATE NO ACTION,
    CONSTRAINT [ComponentesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IdUnidadMedida])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [OrdenDeTrabajo]
    ADD CONSTRAINT [OrdenDeTrabajoCentrosTrabajosIdCentroDeTrabajoFk]
        FOREIGN KEY ([IdCentroTrabajo])
        REFERENCES [CentrosTrabajos] ([IdCentroDeTrabajo])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenDeTrabajoOrdenProduccionNumeroOrdenFk]
        FOREIGN KEY ([NumeroOrden])
        REFERENCES [OrdenProduccion] ([NumeroOrden])
        ON UPDATE NO ACTION;

ALTER TABLE [RemisionesVentaMateriales]
    ADD CONSTRAINT [RemisionesVentaMaterialesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IdUnidadMedida])
        REFERENCES [UnidadMedida] ([IdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRemisionesVentaMaterialesMaterialId]
        FOREIGN KEY ([IdMaterial])
        REFERENCES [Materiales] ([IdMaterial]),
    CONSTRAINT [FkRemisionesVentaMaterialesRemisionCompraId]
        FOREIGN KEY ([NumeroDocumento])
        REFERENCES [RemisionesVenta] ([NumeroDocumento]);

ALTER TABLE [Zonas]
    ADD CONSTRAINT [IzonasCodigoZonaUindex]
        UNIQUE ([CodigoZona]),
    CONSTRAINT [ZonasBodegasIdFk]
        FOREIGN KEY ([IdBodega])
        REFERENCES [Bodegas] ([IdBodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Ubicaciones]
    ADD CONSTRAINT [UbicacionesCodigoUbicacionUindex]
        UNIQUE ([CodigoUbicacion]),
    CONSTRAINT [UbicacionesZonasCodigoZonaFk]
        FOREIGN KEY ([CodigoZona])
        REFERENCES [Zonas] ([CodigoZona])
        ON UPDATE NO ACTION;

ALTER TABLE [Saldos]
    ADD CONSTRAINT [SaldosEstadosSaldosIdFk]
        FOREIGN KEY ([IdEstadoSaldo])
        REFERENCES [EstadosSaldos] ([IdEstadoSaldo])
        ON UPDATE NO ACTION,
    CONSTRAINT [SaldosMaterialesCodigoProductoFk]
        FOREIGN KEY ([CodigoProducto])
        REFERENCES [Materiales] ([CodigoMaterial]),
    CONSTRAINT [SaldosUbicacionesIdFk]
        FOREIGN KEY ([IdUbicacion])
        REFERENCES [Ubicaciones] ([IdUbicacion])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION;
