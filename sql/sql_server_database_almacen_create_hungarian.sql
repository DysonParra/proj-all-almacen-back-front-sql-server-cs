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
    [IntIdCentroDeTrabajo]              BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdInterlocutorComercial]        BIGINT                  NULL DEFAULT NULL,
    [IntIdCategoriaCentro]              BIGINT                  NULL DEFAULT NULL,
    [DecCosto]                          DECIMAL(18, 1)          NULL DEFAULT NULL,
    [IntIdBodega]                       BIGINT                  NULL DEFAULT NULL,
    [IntIdMetodoCosteo]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conceptos')
CREATE TABLE [dbo].[Conceptos] (
    [IntIdConcepto]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionConcepto]            VARCHAR(255)            NULL DEFAULT NULL,
    [BitReposicion]                     BIT                     NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'CondicionesPagos')
CREATE TABLE [dbo].[CondicionesPagos] (
    [IntIdCondicionPago]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombreCondicion]                VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcion]                    VARCHAR(255)            NULL DEFAULT NULL,
    [BitDeudor]                         BIT                     NULL DEFAULT NULL,
    [BitAcreedor]                       BIT                     NULL DEFAULT NULL,
    [IntDiiaFijo]                       INT                     NULL DEFAULT NULL,
    [IntMesesAdicionales]               INT                     NULL DEFAULT NULL,
    [IntDiasTolerancia]                 INT                     NULL DEFAULT NULL,
    [IntNumeroPlazos]                   INT                     NULL DEFAULT NULL,
    [FltDescuentoTotal]                 FLOAT                   NULL DEFAULT NULL,
    [FltInteresCredito]                 FLOAT                   NULL DEFAULT NULL,
    [DecHaberMaximo]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosMovimientos')
CREATE TABLE [dbo].[EstadosMovimientos] (
    [IntIdEstadoMovimiento]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionEstadoMovimiento]    VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosRemisiones')
CREATE TABLE [dbo].[EstadosRemisiones] (
    [IntIdEstadoRemision]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionEstadoRemision]      VARCHAR(255)        NOT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'EstadosSaldos')
CREATE TABLE [dbo].[EstadosSaldos] (
    [IntIdEstadoSaldo]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionEstadoSaldo]         VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoColor]                    VARCHAR(255)            NULL DEFAULT NULL,
    [BitEstaEnReposicion]               BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListasPrecios')
CREATE TABLE [dbo].[ListasPrecios] (
    [IntIdListaPrecio]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombreListaPrecios]             VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionListaPrecios]        VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'GrupoInterlocutores')
CREATE TABLE [dbo].[GrupoInterlocutores] (
    [IntIdGrupoInterlocutor]            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombreGrupo]                    VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcion]                    VARCHAR(255)            NULL DEFAULT NULL,
    [StrCuentaContable]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdListaPrecio]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListasPreciosMateriales')
CREATE TABLE [dbo].[ListasPreciosMateriales] (
    [IntId]                             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdMateriales]                   BIGINT              NOT NULL,
    [IntIdListasPrecios]                BIGINT              NOT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'PlanCompra')
CREATE TABLE [dbo].[PlanCompra] (
    [IntIdPlanCompra]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntCodigoMaterial]                 BIGINT                  NULL DEFAULT NULL,
    [StrDescripcion]                    VARCHAR(100)        NOT NULL,
    [DblCantidad]                       FLOAT               NOT NULL,
    [IntIdGrupoProveedor]               INT                     NULL DEFAULT NULL,
    [DtFechaExplosion]                  DATETIME                NULL DEFAULT NULL,
    [DtFechaCreacion]                   DATETIME                NULL DEFAULT NULL,
    [DtFechaModificacion]               DATETIME                NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(100)            NULL DEFAULT NULL,
    [StrEstado]                         VARCHAR(10)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Cotizacion')
CREATE TABLE [dbo].[Cotizacion] (
    [IntIdCotizacion]                   INT                 NOT NULL PRIMARY KEY IDENTITY,
    [IntCabecera]                       INT                     NULL DEFAULT NULL,
    [IntIdPlanCompra]                   BIGINT                  NULL,
    [IntIdProveedor]                    INT                 NOT NULL,
    [StrEstado]                         VARCHAR(20)             NULL DEFAULT NULL,
    [IntCodigoMaterial]                 BIGINT                  NULL DEFAULT NULL,
    [StrDescripcionMaterial]            VARCHAR(256)            NULL DEFAULT NULL,
    [StrNombreProveedor]                VARCHAR(256)            NULL DEFAULT NULL,
    [StrBuzonProveedor]                 VARCHAR(256)            NULL DEFAULT NULL,
    [DblCantidadRequerida]              FLOAT               NOT NULL,
    [DblCantidadCotizada]               FLOAT               NOT NULL,
    [DblValorCotizado]                  FLOAT                   NULL DEFAULT NULL,
    [DblDescuento]                      FLOAT                   NULL DEFAULT NULL,
    [DtFechaNecesaria]                  DATETIME                 NULL DEFAULT NULL,
    [DtFechaEntrega]                    DATETIME             NOT NULL,
    [DtFechaCreacion]                   DATETIME                 NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sociedad')
CREATE TABLE [dbo].[Sociedad] (
    [IntIdSociedad]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoSociedad]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrNombreSociedad]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionSociedad]            VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoInterlocutorComercial')
CREATE TABLE [dbo].[TipoInterlocutorComercial] (
    [IntIdTipoInterlocutorComercial]    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrTipoInterlocutor]               VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionTipoInterlocutor]    VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutoresComerciales')
CREATE TABLE [dbo].[InterlocutoresComerciales] (
    [IntIdInterlocutorComercial]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoInterlocutor]             VARCHAR(255)            NULL DEFAULT NULL,
    [StrNumeroIdentificacionFinanciera] VARCHAR(255)            NULL DEFAULT NULL,
    [StrNombreInterlocutor]             VARCHAR(255)            NULL DEFAULT NULL,
    [StrTelefono]                       VARCHAR(255)            NULL DEFAULT NULL,
    [StrCelular]                        VARCHAR(255)            NULL DEFAULT NULL,
    [StrFax]                            VARCHAR(255)            NULL DEFAULT NULL,
    [StrEmail]                          VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdGrupoInterlocutor]            BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoInterlocutor]             BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutorFinanzas')
CREATE TABLE [dbo].[InterlocutorFinanzas] (
    [IntIdInterlocutorFinanzas]         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [BitImpuesto]                       BIT                     NULL DEFAULT NULL,
    [BitSujetoRetencion]                BIT                     NULL DEFAULT NULL,
    [StrNumeroCertificadoRetencion]     VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaVencimiento]                DATETIME                NULL DEFAULT NULL,
    [StrNumeroAfiliacionSeguridad]      VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'InterlocutoresCondicionPago')
CREATE TABLE [dbo].[InterlocutoresCondicionPago] (
    [IntIdInterlocutorCondicionPago]    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombreCondicion]                VARCHAR(255)            NULL DEFAULT NULL,
    [FltInteresMora]                    FLOAT                   NULL DEFAULT NULL,
    [FltDescuentoTotal]                 FLOAT                   NULL DEFAULT NULL,
    [DecCupoCredito]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrNumeroCuenta]                   VARCHAR(255)            NULL DEFAULT NULL,
    [StrSucursal]                       VARCHAR(255)            NULL DEFAULT NULL,
    [StrClaveControl]                   VARCHAR(255)            NULL DEFAULT NULL,
    [BitEntregaParcial]                 BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdListaPrecio]                  BIGINT                  NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdCondicionPago]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoListaMaterial')
CREATE TABLE [dbo].[TipoListaMaterial] (
    [IntIdTipoListaMaterial]            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombreTipoLista]                VARCHAR(20)             NULL DEFAULT NULL,
    [StrDescripcionLista]               VARCHAR(200)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TipoUnidadMedida')
CREATE TABLE [dbo].[TipoUnidadMedida] (
    [IntIdTipoUnidadMedida]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombre]                         VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposAgentes')
CREATE TABLE [dbo].[TiposAgentes] (
    [IntIdTipoAgente]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionTipoAgente]          VARCHAR(255)            NULL DEFAULT NULL,
    [StrTablaInformacion]               VARCHAR(255)            NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Agentes')
CREATE TABLE [dbo].[Agentes] (
    [IntIdAgente]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdTipoAgente]                   BIGINT                  NULL DEFAULT NULL,
    [IntIdEntidad]                      INT                     NULL DEFAULT NULL,
    [IntIdAlmacen]                      INT                     NULL DEFAULT NULL,
    [StrObservaciones]                  VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE(),
    [IntIdSociedad]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Bodegas')
CREATE TABLE [dbo].[Bodegas] (
    [IntIdBodega]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoBodega]                   VARCHAR(20)             NULL DEFAULT NULL,
    [StrDescripcionBodega]              VARCHAR(255)            NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE(),
    [IntIdAgente]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Localizaciones')
CREATE TABLE [dbo].[Localizaciones] (
    [IntIdLocalizacion]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdBodega]                       BIGINT                  NULL DEFAULT NULL,
    [StrNombreLocalizacion]             VARCHAR(255)            NULL DEFAULT NULL,
    [StrDireccion]                      VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoPostal]                   VARCHAR(255)            NULL DEFAULT NULL,
    [StrPoBox]                          VARCHAR(255)            NULL DEFAULT NULL,
    [StrCiudad]                         VARCHAR(255)            NULL DEFAULT NULL,
    [StrPais]                           VARCHAR(255)            NULL DEFAULT NULL,
    [StrRegion]                         VARCHAR(255)            NULL DEFAULT NULL,
    [StrTelefono]                       VARCHAR(255)            NULL DEFAULT NULL,
    [StrCelular]                        VARCHAR(255)            NULL DEFAULT NULL,
    [StrFax]                            VARCHAR(255)            NULL DEFAULT NULL,
    [StrEmail]                          VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones')
CREATE TABLE [dbo].[Remisiones] (
    [IntIdRemision]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroGuia]                     VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaCreacion]                   DATETIME                NULL DEFAULT NULL,
    [DtFechaRecepcion]                  DATETIME                NULL DEFAULT NULL,
    [IntConcecutivoInterno]             INT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdAgenteOrigen]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdAgenteDestino]                BIGINT                  NULL DEFAULT NULL,
    [IntIdEstadoRemision]               BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposMateriales')
CREATE TABLE [dbo].[TiposMateriales] (
    [IntIdTipoMaterial]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrTipoMaterial]                   VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionTipoMaterial]        VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales')
CREATE TABLE [dbo].[Materiales] (
    [IntIdMaterial]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrReferencia]                     VARCHAR(255)            NULL DEFAULT NULL,
    [BitGeneraRecibo]                   BIT                     NULL DEFAULT NULL,
    [BitVentaApartado]                  BIT                     NULL DEFAULT NULL,
    [BitPermiteDevolucion]              BIT                     NULL DEFAULT NULL,
    [StrSimbolo]                        VARCHAR(255)            NULL DEFAULT NULL,
    [FltValorUnitario]                  FLOAT                   NULL DEFAULT NULL,
    [FltCosto]                          FLOAT                   NULL DEFAULT NULL,
    [BitConsumible]                     BIT                     NULL DEFAULT NULL,
    [BitProducible]                     BIT                     NULL DEFAULT NULL,
    [BitComprable]                      BIT                     NULL DEFAULT NULL,
    [BitVendible]                       BIT                     NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTiposMateriales]              BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesCostosPromedios')
CREATE TABLE [dbo].[MaterialesCostosPromedios] (
    [IntIdMaterialCostoPromedio]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [DecCostoPromedio]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DtFechaInicial]                    DATETIME                NULL DEFAULT NULL,
    [DtFechaFinal]                      DATETIME                NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesDescripciones')
CREATE TABLE [dbo].[MaterialesDescripciones] (
    [IntIdMaterialDescripcion]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrCultura]                        VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionMaterial]            VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmCodigoEquivalente')
CREATE TABLE [dbo].[MmCodigoEquivalente] (
    [IntIdMmCodigoEquivalente]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrTipoCodigoEquivalente]          VARCHAR(255)            NULL DEFAULT NULL,
    [StrValorCodigoEquivalente]         VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmTmcCaracteristica')
CREATE TABLE [dbo].[MmTmcCaracteristica] (
    [IntIdMmTmcCaracteristica]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdTipoMaterialCaracteristica]   BIGINT                  NULL DEFAULT NULL,
    [StrTipoMaterial]                   VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionTipoMaterialCaracteristica]  VARCHAR(255)    NULL DEFAULT NULL,
    [IntTipoDato]                       INT                     NULL DEFAULT NULL,
    [StrReglaValidacion]                VARCHAR(255)            NULL DEFAULT NULL,
    [BitVisibleDetalle]                 BIT                     NULL DEFAULT NULL,
    [IntOrdenDetall]                    INT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoMaterial]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesCaracteristicas')
CREATE TABLE [dbo].[MaterialesCaracteristicas] (
    [IntIdMaterialCaracteristica]       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrValorCaracteristica]            VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoMaterialCaracteristica]   BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoMaterial]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MmTmcdDescripciones')
CREATE TABLE [dbo].[MmTmcdDescripciones] (
    [IntIdMmTmcdDescripciones]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdTipoMaterialCaracteristica]   BIGINT                  NULL DEFAULT NULL,
    [StrCultura]                        VARCHAR(255)            NULL DEFAULT NULL,
    [StrDescripcionMaterial]            VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposMovimientos')
CREATE TABLE [dbo].[TiposMovimientos] (
    [IntIdTipoMovimiento]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionTipoMovimiento]      VARCHAR(255)            NULL DEFAULT NULL,
    [BitSigno]                          BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentos')
CREATE TABLE [dbo].[TiposDocumentos] (
    [IntIdTipoDocumento]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrDescripcionTipoDocumento]       VARCHAR(255)            NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoMovimiento]               BIGINT                  NULL DEFAULT NULL,
    [IntIdEstadoRemision]               BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Consecutivos')
CREATE TABLE [dbo].[Consecutivos] (
    [IntIdConsecutivo]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrResolucion]                     VARCHAR(255)            NULL DEFAULT NULL,
    [IntValorInicial]                   INT                     NULL DEFAULT NULL,
    [IntValorFinal]                     INT                     NULL DEFAULT NULL,
    [IntIncremento]                     INT                     NULL DEFAULT NULL,
    [IntValorActual]                    INT                     NULL DEFAULT NULL,
    [StrCaracterLlenado]                VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaInicial]                    DATETIME                NULL DEFAULT NULL,
    [DtFechaFinal]                      DATETIME                NULL DEFAULT NULL,
    [StrSufijo]                         VARCHAR(255)            NULL DEFAULT NULL,
    [StrPrefijo]                        VARCHAR(255)            NULL DEFAULT NULL,
    [BitHabilitado]                     BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Movimientos')
CREATE TABLE [dbo].[Movimientos] (
    [IntIdMovimiento]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdRemision]                     BIGINT                  NULL DEFAULT NULL,
    [StrNumeroDocumento]                VARCHAR(255)            NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoMovimiento]               BIGINT                  NULL DEFAULT NULL,
    [IntIdEstadoMovimiento]             BIGINT                  NULL DEFAULT NULL,
    [IntIdConcepto]                     BIGINT                  NULL DEFAULT NULL,
    [DtFechaCreacion]                   DATETIME            NOT NULL DEFAULT GETDATE(),
    [DtFechaAnulacion]                  DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01',
    [IntIdBodega]                       BIGINT                  NULL DEFAULT NULL,
    [DecSobreCosto]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecSobreCostoAplicadoProducto]     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrObservaciones]                  VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01'
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MovimientosDetalles')
CREATE TABLE [dbo].[MovimientosDetalles] (
    [IntIdMovimientoDetalle]            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroDocumento]                VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoProducto]                 VARCHAR(255)            NULL DEFAULT NULL,
    [DecValorUnitario]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecSobreCosto]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecCantidad]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE(),
    [IntIdEstadoSaldo]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesCompras')
CREATE TABLE [dbo].[RemisionesCompras] (
    [IntIdRemisionCompra]               BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroRemisionCompra]           VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaContabilizacion]            DATETIME                NULL DEFAULT NULL,
    [DtFechaValidez]                    DATETIME                NULL DEFAULT NULL,
    [DtFechaDocumento]                  DATETIME                NULL DEFAULT NULL,
    [DtFechaNecesaria]                  DATETIME                NULL DEFAULT NULL,
    [StrNumeroReferencia]               VARCHAR(255)            NULL DEFAULT NULL,
    [DecTotalBruto]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DblPorcentajeDescuento]            FLOAT                   NULL DEFAULT NULL,
    [DblPorcentajeImpuesto]             FLOAT                   NULL DEFAULT NULL,
    [DecValorTotal]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrComentarios]                    VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL,
    [IntIdRemision]                     BIGINT                  NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesComprasMateriales')
CREATE TABLE [dbo].[RemisionesComprasMateriales] (
    [IntIdRemisionCompraMaterial]       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroRemisionCompra]           VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaNecesaria]                  DATETIME                NULL DEFAULT NULL,
    [DtFechaSolicitud]                  DATETIME                NULL DEFAULT NULL,
    [DblCantidad]                       FLOAT                   NULL DEFAULT NULL,
    [DecValorUnitario]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [FltPorcentajeDescuento]            FLOAT                   NULL DEFAULT NULL,
    [DecCostoPromedio]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdRemisionCompra]               BIGINT                  NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesVenta')
CREATE TABLE [dbo].[RemisionesVenta] (
    [StrNumeroDocumento]                VARCHAR(255)        NOT NULL PRIMARY KEY,
    [DtFechaContabilizacion]            DATETIME                NULL DEFAULT NULL,
    [DtFechaValidez]                    DATETIME                NULL DEFAULT NULL,
    [DtFechaDocumento]                  DATETIME                NULL DEFAULT NULL,
    [DtFechaNecesaria]                  DATETIME                NULL DEFAULT NULL,
    [StrNumeroReferencia]               VARCHAR(255)            NULL DEFAULT NULL,
    [DecTotalBruto]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DblPorcentajeDescuento]            FLOAT                   NULL DEFAULT NULL,
    [DblPorcentajeImpuesto]             FLOAT                   NULL DEFAULT NULL,
    [DecValorTotal]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrComentarios]                    VARCHAR(255)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL,
    [IntIdRemision]                     BIGINT                  NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL,
    [IntListaPrecio]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentosConceptos')
CREATE TABLE [dbo].[TiposDocumentosConceptos] (
    [IntIdTipoDocumentoConcepto]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL,
    [IntIdConcepto]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TiposDocumentosTiposAgentes')
CREATE TABLE [dbo].[TiposDocumentosTiposAgentes] (
    [IntIdTipoDocumentoTipoAgente]      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoDocumento]                BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoAgente]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'UnidadMedida')
CREATE TABLE [dbo].[UnidadMedida] (
    [IntIdUnidadMedida]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombre]                         VARCHAR(255)            NULL DEFAULT NULL,
    [StrSimbolo]                        VARCHAR(255)            NULL DEFAULT NULL,
    [FltFactor]                         FLOAT                   NULL DEFAULT NULL,
    [FltPrecision]                      FLOAT                   NULL DEFAULT NULL,
    [FltConversion]                     FLOAT                   NULL DEFAULT NULL,
    [IntDecimales]                      INT                     NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdTipoUnidadMedida]             BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ListaDeMateriales')
CREATE TABLE [dbo].[ListaDeMateriales] (
    [IntIdListaMaterial]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdUnidadMedida]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdTipoListaMaterial]            BIGINT                  NULL DEFAULT NULL,
    [IntIdBodega]                       BIGINT                  NULL DEFAULT NULL,
    [DtFechaInicio]                     DATETIME                NULL DEFAULT NULL,
    [DtFechaFin]                        DATETIME                NULL DEFAULT NULL,
    [IntCantidad]                       INT                     NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoComponente]               VARCHAR(255)            NULL DEFAULT NULL,
    [IntIdListaPrecio]                  BIGINT                  NULL DEFAULT NULL,
    [DecPrecioUnitario]                 DECIMAL(18, 1)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(100)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'MaterialesDatosCompra')
CREATE TABLE [dbo].[MaterialesDatosCompra] (
    [IntIdMaterialDatoCompra]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoMaterialCompra]           VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [BitAutomaticPurchase]              BIT                     NULL DEFAULT NULL,
    [BitGestionLotes]                   BIT                     NULL DEFAULT NULL,
    [DecToleranciaEntregaInferior]      DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecToleranciaEntregaSuperior]      DECIMAL(10, 2)          NULL DEFAULT NULL,
    [IntDiasEntrega]                    INT                     NULL DEFAULT NULL,
    [BitRequiereInspeccion]             BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL,
    [IntIdUnidadMedidaBase]             BIGINT                  NULL DEFAULT NULL,
    [IntIdUnidadMedidaCompra]           BIGINT                  NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL,
    [IntIdInterlocutor]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'OrdenProduccion')
CREATE TABLE [dbo].[OrdenProduccion] (
    [StrNumeroOrden]                    VARCHAR(20)         NOT NULL PRIMARY KEY,
    [StrReferencia]                     VARCHAR(20)             NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [IntIdEstadoProduccion]             BIGINT                  NULL DEFAULT NULL,
    [IntIdRutaOrdenTrabajo]             BIGINT                  NULL DEFAULT NULL,
    [IntIdListaMateriales]              BIGINT                  NULL DEFAULT NULL,
    [IntIdUnidadMedida]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdCentroTrabajo]                BIGINT                  NULL DEFAULT NULL,
    [DtFechaEstimada]                   DATETIME                NULL DEFAULT NULL,
    [DtFechaInicioEstimada]             DATETIME                NULL DEFAULT NULL,
    [DtFechaFinalizacion]               DATETIME                NULL DEFAULT NULL,
    [DecCantidadPlanificada]            DECIMAL(18, 1)          NULL DEFAULT NULL,
    [StrOrigenOrden]                    VARCHAR(20)             NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(20)             NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Componentes')
CREATE TABLE [dbo].[Componentes] (
    [IntIdComponente]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroOrden]                    VARCHAR(20)             NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [IntIdUnidadMedida]                 BIGINT                  NULL DEFAULT NULL,
    [IntIdAlmacen]                      BIGINT                  NULL DEFAULT NULL,
    [DecCantidadBase]                   DECIMAL(18, 1)          NULL DEFAULT NULL,
    [DecCantidadRequerida]              DECIMAL(18, 1)          NULL DEFAULT NULL,
    [DecCantidadAdicional]              DECIMAL(18, 1)          NULL DEFAULT NULL,
    [DecCantidadConsumida]              DECIMAL(18, 1)          NULL DEFAULT NULL,
    [DtFechaEstimada]                   DATETIME                NULL DEFAULT NULL,
    [DtFechaEfectiva]                   DATETIME                NULL DEFAULT NULL,
    [DtFechaInicio]                     DATETIME                NULL DEFAULT NULL,
    [DtFechaFinal]                      DATETIME                NULL DEFAULT NULL,
    [IntIdEstadoComponente]             BIGINT                  NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(20)             NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'OrdenDeTrabajo')
CREATE TABLE [dbo].[OrdenDeTrabajo] (
    [IntIdOrdenTrabajo]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdOperacion]                    BIGINT                  NULL DEFAULT NULL,
    [IntIdCentroTrabajo]                BIGINT                  NULL DEFAULT NULL,
    [IntIdEstadoOT]                     BIGINT                  NULL DEFAULT NULL,
    [StrNumeroOrden]                    VARCHAR(20)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RemisionesVentaMateriales')
CREATE TABLE [dbo].[RemisionesVentaMateriales] (
    [IntIdRemisionVentaMaterial]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNumeroDocumento]                VARCHAR(255)            NULL DEFAULT NULL,
    [StrCodigoMaterial]                 VARCHAR(255)            NULL DEFAULT NULL,
    [DtFechaNecesaria]                  DATETIME                NULL DEFAULT NULL,
    [DtFechaSolicitud]                  DATETIME                NULL DEFAULT NULL,
    [DblCantidad]                       FLOAT                   NULL DEFAULT NULL,
    [DecValorUnitario]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [FltPorcentajeDescuento]            FLOAT                   NULL DEFAULT NULL,
    [DecCostoPromedio]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [IntIdRemisionCompra]               BIGINT                  NULL DEFAULT NULL,
    [IntIdMaterial]                     BIGINT                  NULL DEFAULT NULL,
    [IntIdUnidadMedida]                 BIGINT                  NULL DEFAULT NULL,
    [DecCantidadUnidadMedida]           DECIMAL(18, 1)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Zonas')
CREATE TABLE [dbo].[Zonas] (
    [StrCodigoZona]                     VARCHAR(20)         NOT NULL PRIMARY KEY,
    [IntIdBodega]                       BIGINT                  NULL DEFAULT NULL,
    [StrDescripcionZona]                VARCHAR(255)            NULL DEFAULT NULL,
    [BitTransitoDirecto]                BIT                     NULL DEFAULT NULL,
    [BitPicking]                        BIT                     NULL DEFAULT NULL,
    [BitUbicacion]                      BIT                     NULL DEFAULT NULL,
    [BitDespacho]                       BIT                     NULL DEFAULT NULL,
    [BitRecepcion]                      BIT                     NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE()
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ubicaciones')
CREATE TABLE [dbo].[Ubicaciones] (
    [IntIdUbicacion]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrCodigoUbicacion]                VARCHAR(20)         NOT NULL,
    [StrCodigoZona]                     VARCHAR(20)             NULL DEFAULT NULL,
    [StrDescripcionUbicacion]           VARCHAR(255)            NULL DEFAULT NULL,
    [BitDedicado]                       BIT                     NULL DEFAULT NULL,
    [BitActivo]                         BIT                     NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE()
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Saldos')
CREATE TABLE [dbo].[Saldos] (
    [IntIdSaldo]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdEstadoSaldo]                  BIGINT                  NULL DEFAULT NULL,
    [IntIdUbicacion]                    BIGINT                  NULL DEFAULT NULL,
    [StrCodigoProducto]                 VARCHAR(255)            NULL DEFAULT NULL,
    [DecCantidad]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(255)            NULL DEFAULT NULL,
    [DtFecha]                           DATETIME            NOT NULL DEFAULT GETDATE()
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [GrupoInterlocutores]
    ADD CONSTRAINT [FkGrupoInterlocutoresListaPrecioId]
        FOREIGN KEY ([IntIdListaPrecio])
        REFERENCES [ListasPrecios] ([IntIdListaPrecio]);

ALTER TABLE [Cotizacion]
    ADD CONSTRAINT [CotizacionPlanCompraIdFk]
        FOREIGN KEY ([IntIdPlanCompra])
        REFERENCES [PlanCompra] ([IntIdPlanCompra]);

ALTER TABLE [InterlocutoresComerciales]
    ADD CONSTRAINT [FkInterlocutoresComercialesGrupoInterlocutorId]
        FOREIGN KEY ([IntIdGrupoInterlocutor])
        REFERENCES [GrupoInterlocutores] ([IntIdGrupoInterlocutor]),
    CONSTRAINT [FkInterlocutoresComercialesTipointerlocutorId]
        FOREIGN KEY ([IntIdTipoInterlocutor])
        REFERENCES [TipoInterlocutorComercial] ([IntIdTipoInterlocutorComercial]);

ALTER TABLE [InterlocutorFinanzas]
    ADD CONSTRAINT [FkInterlocutoresComercialesFinanzasInterlocutorId]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial]);

ALTER TABLE [InterlocutoresCondicionPago]
    ADD CONSTRAINT [FkInterlocutoresCondicionPagoCondicionPagoId]
        FOREIGN KEY ([IntIdCondicionPago])
        REFERENCES [CondicionesPagos] ([IntIdCondicionPago]),
    CONSTRAINT [FkInterlocutoresCondicionPagoListaPrecioId]
        FOREIGN KEY ([IntIdListaPrecio])
        REFERENCES [ListasPrecios] ([IntIdListaPrecio]),
    CONSTRAINT [FkInterlocutoresCondicionPagoInterlocutorId]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial]);

ALTER TABLE [Agentes]
    ADD CONSTRAINT [AgentesSociedadIdFk]
        FOREIGN KEY ([IntIdSociedad])
        REFERENCES [Sociedad] ([IntIdSociedad])
        ON UPDATE NO ACTION,
    CONSTRAINT [AgentesTiposAgentesIdFk]
        FOREIGN KEY ([IntIdTipoAgente])
        REFERENCES [TiposAgentes] ([IntIdTipoAgente])
        ON UPDATE NO ACTION;

ALTER TABLE [Bodegas]
    ADD CONSTRAINT [BodegasCodigoBodegaUindex]
        UNIQUE ([StrCodigoBodega]),
    CONSTRAINT [BodegasAgentesIdFk]
        FOREIGN KEY ([IntIdAgente])
        REFERENCES [Agentes] ([IntIdAgente])
        ON UPDATE NO ACTION;

ALTER TABLE [Localizaciones]
    ADD CONSTRAINT [FkLocalizacionesInterlocutorId]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial]),
    CONSTRAINT [LocalizacionesBodegasIdFk]
        FOREIGN KEY ([IntIdBodega])
        REFERENCES [Bodegas] ([IntIdBodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Remisiones]
    ADD CONSTRAINT [FkRemisionesAgentedestinoId]
        FOREIGN KEY ([IntIdAgenteDestino])
        REFERENCES [Agentes] ([IntIdAgente]),
    CONSTRAINT [FkRemisionesAgenteorigenId]
        FOREIGN KEY ([IntIdAgenteOrigen])
        REFERENCES [Agentes] ([IntIdAgente]),
    CONSTRAINT [FkRemisionesEstadoRemisionId]
        FOREIGN KEY ([IntIdEstadoRemision])
        REFERENCES [EstadosRemisiones] ([IntIdEstadoRemision]);

ALTER TABLE [Materiales]
    ADD CONSTRAINT [MaterialesCodigoProductoUindex]
        UNIQUE ([StrCodigoMaterial]),
    CONSTRAINT [MaterialesTiposMaterialesIdTipoMaterialFk]
        FOREIGN KEY ([IntIdTiposMateriales])
        REFERENCES [TiposMateriales] ([IntIdTipoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesCostosPromedios]
    ADD CONSTRAINT [MaterialesCostosPromediosMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesDescripciones]
    ADD CONSTRAINT [MaterialesDescripcionesMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial]);

ALTER TABLE [MmCodigoEquivalente]
    ADD CONSTRAINT [MmCodigoEquivalenteMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MmTmcCaracteristica]
    ADD CONSTRAINT [FkTiposMaterialesCaracteristicasTipoMaterialId]
        FOREIGN KEY ([IntIdTipoMaterial])
        REFERENCES [TiposMateriales] ([IntIdTipoMaterial]);

ALTER TABLE [MaterialesCaracteristicas]
    ADD CONSTRAINT [MaterialesCaracteristicasMaterialesIdMaterialFk]
        FOREIGN KEY ([IntIdMaterial])
        REFERENCES [Materiales] ([IntIdMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesCaracteristicasMmTmcCaracteristicaFk]
        FOREIGN KEY ([IntIdTipoMaterialCaracteristica])
        REFERENCES [MmTmcCaracteristica] ([IntIdMmTmcCaracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesCaracteristicas]
    ADD CONSTRAINT [MaterialesCaracteristicasTiposMaterialesIdTipoMaterialFk]
        FOREIGN KEY ([IntIdTipoMaterial])
        REFERENCES [TiposMateriales] ([IntIdTipoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesCaracteristicasFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [MmTmcdDescripciones]
    ADD CONSTRAINT [MmTmcdTmcFk]
        FOREIGN KEY ([IntIdTipoMaterialCaracteristica])
        REFERENCES [MmTmcCaracteristica] ([IntIdMmTmcCaracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [TiposDocumentos]
    ADD CONSTRAINT [FkTiposDocumentosEstadoRemisionId]
        FOREIGN KEY ([IntIdEstadoRemision])
        REFERENCES [EstadosRemisiones] ([IntIdEstadoRemision]),
    CONSTRAINT [FkTiposDocumentosTipoMovimientoId1]
        FOREIGN KEY ([IntIdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IntIdTipoMovimiento]),
    CONSTRAINT [FkTiposDocumentosTipomovimientoId2]
        FOREIGN KEY ([IntIdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IntIdTipoMovimiento]);

ALTER TABLE [Consecutivos]
    ADD CONSTRAINT [ConsecutivosTiposDocumentosIdFk]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [Movimientos]
    ADD CONSTRAINT [MovimientosNumeroDocumentoUindex]
        UNIQUE ([StrNumeroDocumento]),
    CONSTRAINT [MovimientosBodegasIdFk]
        FOREIGN KEY ([IntIdBodega])
        REFERENCES [Bodegas] ([IntIdBodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [MovimientosConceptosIdFk]
        FOREIGN KEY ([IntIdConcepto])
        REFERENCES [Conceptos] ([IntIdConcepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [MovimientosEstadosMovimientosIdFk]
        FOREIGN KEY ([IntIdEstadoMovimiento])
        REFERENCES [EstadosMovimientos] ([IntIdEstadoMovimiento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosRemisionesIdFk]
        FOREIGN KEY ([IntIdRemision])
        REFERENCES [Remisiones] ([IntIdRemision])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosTiposDocumentosIdFk]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [MovimientosTiposMovimientosIdFk]
        FOREIGN KEY ([IntIdTipoMovimiento])
        REFERENCES [TiposMovimientos] ([IntIdTipoMovimiento])
        ON UPDATE NO ACTION;

ALTER TABLE [MovimientosDetalles]
    ADD CONSTRAINT [MovimientosDetallesEstadosSaldosIdFk]
        FOREIGN KEY ([IntIdEstadoSaldo])
        REFERENCES [EstadosSaldos] ([IntIdEstadoSaldo]),
    CONSTRAINT [MovimientosDetallesMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoProducto])
        REFERENCES [Materiales] ([StrCodigoMaterial]),
    CONSTRAINT [MovimientosDetallesMovimientosNumeroDocumentoFk]
        FOREIGN KEY ([StrNumeroDocumento])
        REFERENCES [Movimientos] ([StrNumeroDocumento]);

ALTER TABLE [RemisionesCompras]
    ADD CONSTRAINT [FkRemisionesComprasTipoDocumentoId]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento]),
    CONSTRAINT [FkRemisionesComprasInterlocutorId]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial]),
    CONSTRAINT [FkRemisionesComprasRemisionId]
        FOREIGN KEY ([IntIdRemision])
        REFERENCES [Remisiones] ([IntIdRemision]);

ALTER TABLE [RemisionesComprasMateriales]
    ADD CONSTRAINT [FkRemisionesComprasMaterialesMaterialId]
        FOREIGN KEY ([IntIdMaterial])
        REFERENCES [Materiales] ([IntIdMaterial]),
    CONSTRAINT [FkRemisionesComprasMaterialesRemisionCompraId]
        FOREIGN KEY ([IntIdRemisionCompra])
        REFERENCES [RemisionesCompras] ([IntIdRemisionCompra]);

ALTER TABLE [RemisionesVenta]
    ADD CONSTRAINT [RemisionesVentaListasPreciosIdListaPrecioFk]
        FOREIGN KEY ([IntListaPrecio])
        REFERENCES [ListasPrecios] ([IntIdListaPrecio])
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRemisionesVentaTipoDocumentoId]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento]),
    CONSTRAINT [FkRemisionesVentaInterlocutorId]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial]),
    CONSTRAINT [FkRemisionesVentaRemisionId]
        FOREIGN KEY ([IntIdRemision])
        REFERENCES [Remisiones] ([IntIdRemision]);

ALTER TABLE [TiposDocumentosConceptos]
    ADD CONSTRAINT [TiposDocumentosConceptosConceptosIdFk]
        FOREIGN KEY ([IntIdConcepto])
        REFERENCES [Conceptos] ([IntIdConcepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [TiposDocumentosConceptosTiposDocumentosIdFk]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [TiposDocumentosTiposAgentes]
    ADD CONSTRAINT [TiposDocumentosTiposAgentesTiposAgentesIdFk]
        FOREIGN KEY ([IntIdTipoAgente])
        REFERENCES [TiposAgentes] ([IntIdTipoAgente])
        ON UPDATE NO ACTION,
    CONSTRAINT [TiposDocumentosTiposAgentesTiposDocumentosIdFk]
        FOREIGN KEY ([IntIdTipoDocumento])
        REFERENCES [TiposDocumentos] ([IntIdTipoDocumento])
        ON UPDATE NO ACTION;

ALTER TABLE [UnidadMedida]
    ADD CONSTRAINT [FkUnidadMedidaTipoUnidadMedidaId]
        FOREIGN KEY ([IntIdTipoUnidadMedida])
        REFERENCES [TipoUnidadMedida] ([IntIdTipoUnidadMedida]);

ALTER TABLE [ListaDeMateriales]
    ADD CONSTRAINT [ListaDeMaterialesPk]
        UNIQUE ([IntIdListaMaterial]),
    CONSTRAINT [ListaDeMaterialesBodegasIdBodegaFk]
        FOREIGN KEY ([IntIdBodega])
        REFERENCES [Bodegas] ([IntIdBodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesListasPreciosIdListaPrecioFk]
        FOREIGN KEY ([IntIdListaPrecio])
        REFERENCES [ListasPrecios] ([IntIdListaPrecio]),
    CONSTRAINT [ListaDeMaterialesMaterialesCodigoMaterialFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesMaterialesCodigoMaterialFk2]
        FOREIGN KEY ([StrCodigoComponente])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesIdTipoListaMaterialFk]
        FOREIGN KEY ([IntIdTipoListaMaterial])
        REFERENCES [TipoListaMaterial] ([IntIdTipoListaMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ListaDeMaterialesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IntIdUnidadMedida])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [MaterialesDatosCompra]
    ADD CONSTRAINT [MaterialesDatosCompraInterlocutoresComercialesFk]
        FOREIGN KEY ([IntIdInterlocutor])
        REFERENCES [InterlocutoresComerciales] ([IntIdInterlocutorComercial])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IntIdUnidadMedidaBase])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraUnidadMedidaIdUnidadMedidaFk2]
        FOREIGN KEY ([IntIdUnidadMedidaCompra])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [MaterialesDatosCompraMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION;

ALTER TABLE [OrdenProduccion]
    ADD CONSTRAINT [OrdenProduccionListaDeMaterialesIdListaMaterialFk]
        FOREIGN KEY ([IntIdListaMateriales])
        REFERENCES [ListaDeMateriales] ([IntIdListaMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenProduccionMaterialesCodigoMaterialFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenProduccionUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IntIdUnidadMedida])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [Componentes]
    ADD CONSTRAINT [ComponentesMaterialesCodigoMaterialFk]
        FOREIGN KEY ([StrCodigoMaterial])
        REFERENCES [Materiales] ([StrCodigoMaterial])
        ON UPDATE NO ACTION,
    CONSTRAINT [ComponentesOrdenProduccionNumeroOrdenFk]
        FOREIGN KEY ([StrNumeroOrden])
        REFERENCES [OrdenProduccion] ([StrNumeroOrden])
        ON UPDATE NO ACTION,
    CONSTRAINT [ComponentesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IntIdUnidadMedida])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION;

ALTER TABLE [OrdenDeTrabajo]
    ADD CONSTRAINT [OrdenDeTrabajoCentrosTrabajosIdCentroDeTrabajoFk]
        FOREIGN KEY ([IntIdCentroTrabajo])
        REFERENCES [CentrosTrabajos] ([IntIdCentroDeTrabajo])
        ON UPDATE NO ACTION,
    CONSTRAINT [OrdenDeTrabajoOrdenProduccionNumeroOrdenFk]
        FOREIGN KEY ([StrNumeroOrden])
        REFERENCES [OrdenProduccion] ([StrNumeroOrden])
        ON UPDATE NO ACTION;

ALTER TABLE [RemisionesVentaMateriales]
    ADD CONSTRAINT [RemisionesVentaMaterialesUnidadMedidaIdUnidadMedidaFk]
        FOREIGN KEY ([IntIdUnidadMedida])
        REFERENCES [UnidadMedida] ([IntIdUnidadMedida])
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRemisionesVentaMaterialesMaterialId]
        FOREIGN KEY ([IntIdMaterial])
        REFERENCES [Materiales] ([IntIdMaterial]),
    CONSTRAINT [FkRemisionesVentaMaterialesRemisionCompraId]
        FOREIGN KEY ([StrNumeroDocumento])
        REFERENCES [RemisionesVenta] ([StrNumeroDocumento]);

ALTER TABLE [Zonas]
    ADD CONSTRAINT [IzonasCodigoZonaUindex]
        UNIQUE ([StrCodigoZona]),
    CONSTRAINT [ZonasBodegasIdFk]
        FOREIGN KEY ([IntIdBodega])
        REFERENCES [Bodegas] ([IntIdBodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Ubicaciones]
    ADD CONSTRAINT [UbicacionesCodigoUbicacionUindex]
        UNIQUE ([StrCodigoUbicacion]),
    CONSTRAINT [UbicacionesZonasCodigoZonaFk]
        FOREIGN KEY ([StrCodigoZona])
        REFERENCES [Zonas] ([StrCodigoZona])
        ON UPDATE NO ACTION;

ALTER TABLE [Saldos]
    ADD CONSTRAINT [SaldosEstadosSaldosIdFk]
        FOREIGN KEY ([IntIdEstadoSaldo])
        REFERENCES [EstadosSaldos] ([IntIdEstadoSaldo])
        ON UPDATE NO ACTION,
    CONSTRAINT [SaldosMaterialesCodigoProductoFk]
        FOREIGN KEY ([StrCodigoProducto])
        REFERENCES [Materiales] ([StrCodigoMaterial]),
    CONSTRAINT [SaldosUbicacionesIdFk]
        FOREIGN KEY ([IntIdUbicacion])
        REFERENCES [Ubicaciones] ([IntIdUbicacion])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION;
