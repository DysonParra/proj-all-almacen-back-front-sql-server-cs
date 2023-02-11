USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Almacen') DROP DATABASE [Almacen]
GO
CREATE DATABASE [Almacen];
GO
USE [Almacen];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Centros_Trabajos')
CREATE TABLE [dbo].[Centros_Trabajos] (
    [Id_Centro_De_Trabajo]              BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Interlocutor_Comercial]         BIGINT                  NULL DEFAULT NULL,
    [Id_Categoria_Centro]               BIGINT                  NULL DEFAULT NULL,
    [Costo]                             DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Id_Bodega]                         BIGINT                  NULL DEFAULT NULL,
    [Id_Metodo_Costeo]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conceptos')
CREATE TABLE [dbo].[Conceptos] (
    [Id_Concepto]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Concepto]              VARCHAR(255)            NULL DEFAULT NULL,
    [Reposicion]                        BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Condiciones_Pagos')
CREATE TABLE [dbo].[Condiciones_Pagos] (
    [Id_Condicion_Pago]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre_Condicion]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Deudor]                            BIT                     NULL DEFAULT NULL,
    [Acreedor]                          BIT                     NULL DEFAULT NULL,
    [Diia_Fijo]                         INT                     NULL DEFAULT NULL,
    [Meses_Adicionales]                 INT                     NULL DEFAULT NULL,
    [Dias_Tolerancia]                   INT                     NULL DEFAULT NULL,
    [Numero_Plazos]                     INT                     NULL DEFAULT NULL,
    [Descuento_Total]                   FLOAT                   NULL DEFAULT NULL,
    [Interes_Credito]                   FLOAT                   NULL DEFAULT NULL,
    [Haber_Maximo]                      DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Estados_Movimientos')
CREATE TABLE [dbo].[Estados_Movimientos] (
    [Id_Estado_Movimiento]              BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Estado_Movimiento]     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Estados_Remisiones')
CREATE TABLE [dbo].[Estados_Remisiones] (
    [Id_Estado_Remision]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Estado_Remision]       VARCHAR(255)        NOT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Estados_Saldos')
CREATE TABLE [dbo].[Estados_Saldos] (
    [Id_Estado_Saldo]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Estado_Saldo]          VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Color]                      VARCHAR(255)            NULL DEFAULT NULL,
    [Esta_En_Reposicion]                BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Listas_Precios')
CREATE TABLE [dbo].[Listas_Precios] (
    [Id_Lista_Precio]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre_Lista_Precios]              VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Lista_Precios]         VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Grupo_Interlocutores')
CREATE TABLE [dbo].[Grupo_Interlocutores] (
    [Id_Grupo_Interlocutor]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre_Grupo]                      VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Cuenta_Contable]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Lista_Precio]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Listas_Precios_Materiales')
CREATE TABLE [dbo].[Listas_Precios_Materiales] (
    [Id]                                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Materiales]                     BIGINT              NOT NULL,
    [Id_Listas_Precios]                 BIGINT              NOT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Plan_Compra')
CREATE TABLE [dbo].[Plan_Compra] (
    [Id_Plan_Compra]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   BIGINT                  NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(100)        NOT NULL,
    [Cantidad]                          FLOAT               NOT NULL,
    [Id_Grupo_Proveedor]                INT                     NULL DEFAULT NULL,
    [Fecha_Explosion]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Creacion]                    DATETIME                NULL DEFAULT NULL,
    [Fecha_Modificacion]                DATETIME                NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Estado]                            VARCHAR(10)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Cotizacion')
CREATE TABLE [dbo].[Cotizacion] (
    [Id_Cotizacion]                     INT                 NOT NULL PRIMARY KEY IDENTITY,
    [Cabecera]                          INT                     NULL DEFAULT NULL,
    [Id_Plan_Compra]                    BIGINT                  NULL,
    [Id_Proveedor]                      INT                 NOT NULL,
    [Estado]                            VARCHAR(20)             NULL DEFAULT NULL,
    [Codigo_Material]                   BIGINT                  NULL DEFAULT NULL,
    [Descripcion_Material]              VARCHAR(256)            NULL DEFAULT NULL,
    [Nombre_Proveedor]                  VARCHAR(256)            NULL DEFAULT NULL,
    [Buzon_Proveedor]                   VARCHAR(256)            NULL DEFAULT NULL,
    [Cantidad_Requerida]                FLOAT               NOT NULL,
    [Cantidad_Cotizada]                 FLOAT               NOT NULL,
    [Valor_Cotizado]                    FLOAT                   NULL DEFAULT NULL,
    [Descuento]                         FLOAT                   NULL DEFAULT NULL,
    [Fecha_Necesaria]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Entrega]                     DATETIME            NOT NULL,
    [Fecha_Creacion]                    DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Sociedad')
CREATE TABLE [dbo].[Sociedad] (
    [Id_Sociedad]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Sociedad]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Nombre_Sociedad]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Sociedad]              VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipo_Interlocutor_Comercial')
CREATE TABLE [dbo].[Tipo_Interlocutor_Comercial] (
    [Id_Tipo_Interlocutor_Comercial]    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Tipo_Interlocutor]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Tipo_Interlocutor]     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Interlocutores_Comerciales')
CREATE TABLE [dbo].[Interlocutores_Comerciales] (
    [Id_Interlocutor_Comercial]         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Interlocutor]               VARCHAR(255)            NULL DEFAULT NULL,
    [Numero_Identificacion_Financiera]  VARCHAR(255)            NULL DEFAULT NULL,
    [Nombre_Interlocutor]               VARCHAR(255)            NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(255)            NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fax]                               VARCHAR(255)            NULL DEFAULT NULL,
    [Email]                             VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Grupo_Interlocutor]             BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Interlocutor]              BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Interlocutor_Finanzas')
CREATE TABLE [dbo].[Interlocutor_Finanzas] (
    [Id_Interlocutor_Finanzas]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Impuesto]                          BIT                     NULL DEFAULT NULL,
    [Sujeto_Retencion]                  BIT                     NULL DEFAULT NULL,
    [Numero_Certificado_Retencion]      VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Vencimiento]                 DATETIME                NULL DEFAULT NULL,
    [Numero_Afiliacion_Seguridad]       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Interlocutores_Condicion_Pago')
CREATE TABLE [dbo].[Interlocutores_Condicion_Pago] (
    [Id_Interlocutor_Condicion_Pago]    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre_Condicion]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Interes_Mora]                      FLOAT                   NULL DEFAULT NULL,
    [Descuento_Total]                   FLOAT                   NULL DEFAULT NULL,
    [Cupo_Credito]                      DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Numero_Cuenta]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Sucursal]                          VARCHAR(255)            NULL DEFAULT NULL,
    [Clave_Control]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Entrega_Parcial]                   BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Lista_Precio]                   BIGINT                  NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL,
    [Id_Condicion_Pago]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipo_Lista_Material')
CREATE TABLE [dbo].[Tipo_Lista_Material] (
    [Id_Tipo_Lista_Material]            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre_Tipo_Lista]                 VARCHAR(20)             NULL DEFAULT NULL,
    [Descripcion_Lista]                 VARCHAR(200)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipo_Unidad_Medida')
CREATE TABLE [dbo].[Tipo_Unidad_Medida] (
    [Id_Tipo_Unidad_Medida]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Agentes')
CREATE TABLE [dbo].[Tipos_Agentes] (
    [Id_Tipo_Agente]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Tipo_Agente]           VARCHAR(255)            NULL DEFAULT NULL,
    [Tabla_Informacion]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Agentes')
CREATE TABLE [dbo].[Agentes] (
    [Id_Agente]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Tipo_Agente]                    BIGINT                  NULL DEFAULT NULL,
    [Id_Entidad]                        INT                     NULL DEFAULT NULL,
    [Id_Almacen]                        INT                     NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [Id_Sociedad]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Bodegas')
CREATE TABLE [dbo].[Bodegas] (
    [Id_Bodega]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Bodega]                     VARCHAR(20)             NULL DEFAULT NULL,
    [Descripcion_Bodega]                VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [Id_Agente]                         BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Localizaciones')
CREATE TABLE [dbo].[Localizaciones] (
    [Id_Localizacion]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Bodega]                         BIGINT                  NULL DEFAULT NULL,
    [Nombre_Localizacion]               VARCHAR(255)            NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Postal]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Po_Box]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Ciudad]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Pais]                              VARCHAR(255)            NULL DEFAULT NULL,
    [Region]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(255)            NULL DEFAULT NULL,
    [Celular]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fax]                               VARCHAR(255)            NULL DEFAULT NULL,
    [Email]                             VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones')
CREATE TABLE [dbo].[Remisiones] (
    [Id_Remision]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Guia]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Creacion]                    DATETIME                NULL DEFAULT NULL,
    [Fecha_Recepcion]                   DATETIME                NULL DEFAULT NULL,
    [Concecutivo_Interno]               INT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Agente_Origen]                  BIGINT                  NULL DEFAULT NULL,
    [Id_Agente_Destino]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Estado_Remision]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Materiales')
CREATE TABLE [dbo].[Tipos_Materiales] (
    [Id_Tipo_Material]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Tipo_Material]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Tipo_Material]         VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales')
CREATE TABLE [dbo].[Materiales] (
    [Id_Material]                       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Referencia]                        VARCHAR(255)            NULL DEFAULT NULL,
    [Genera_Recibo]                     BIT                     NULL DEFAULT NULL,
    [Venta_Apartado]                    BIT                     NULL DEFAULT NULL,
    [Permite_Devolucion]                BIT                     NULL DEFAULT NULL,
    [Simbolo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Valor_Unitario]                    FLOAT                   NULL DEFAULT NULL,
    [Costo]                             FLOAT                   NULL DEFAULT NULL,
    [Consumible]                        BIT                     NULL DEFAULT NULL,
    [Producible]                        BIT                     NULL DEFAULT NULL,
    [Comprable]                         BIT                     NULL DEFAULT NULL,
    [Vendible]                          BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipos_Materiales]               BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales_Costos_Promedios')
CREATE TABLE [dbo].[Materiales_Costos_Promedios] (
    [Id_Material_Costo_Promedio]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Costo_Promedio]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Fecha_Inicial]                     DATETIME                NULL DEFAULT NULL,
    [Fecha_Final]                       DATETIME                NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales_Descripciones')
CREATE TABLE [dbo].[Materiales_Descripciones] (
    [Id_Material_Descripcion]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Cultura]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Material]              VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mm_Codigo_Equivalente')
CREATE TABLE [dbo].[Mm_Codigo_Equivalente] (
    [Id_Mm_Codigo_Equivalente]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Tipo_Codigo_Equivalente]           VARCHAR(255)            NULL DEFAULT NULL,
    [Valor_Codigo_Equivalente]          VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mm_Tmc_Caracteristica')
CREATE TABLE [dbo].[Mm_Tmc_Caracteristica] (
    [Id_Mm_Tmc_Caracteristica]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Tipo_Material_Caracteristica]   BIGINT                  NULL DEFAULT NULL,
    [Tipo_Material]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Tipo_Material_Caracteristica]  VARCHAR(255)    NULL DEFAULT NULL,
    [Tipo_Dato]                         INT                     NULL DEFAULT NULL,
    [Regla_Validacion]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Visible_Detalle]                   BIT                     NULL DEFAULT NULL,
    [Orden_Detall]                      INT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Material]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales_Caracteristicas')
CREATE TABLE [dbo].[Materiales_Caracteristicas] (
    [Id_Material_Caracteristica]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Valor_Caracteristica]              VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Material_Caracteristica]   BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Material]                  BIGINT                  NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mm_Tmcd_Descripciones')
CREATE TABLE [dbo].[Mm_Tmcd_Descripciones] (
    [Id_Mm_Tmcd_Descripciones]          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Tipo_Material_Caracteristica]   BIGINT                  NULL DEFAULT NULL,
    [Cultura]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Descripcion_Material]              VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Movimientos')
CREATE TABLE [dbo].[Tipos_Movimientos] (
    [Id_Tipo_Movimiento]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Tipo_Movimiento]       VARCHAR(255)            NULL DEFAULT NULL,
    [Signo]                             BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Documentos')
CREATE TABLE [dbo].[Tipos_Documentos] (
    [Id_Tipo_Documento]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Descripcion_Tipo_Documento]        VARCHAR(255)            NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Movimiento]                BIGINT                  NULL DEFAULT NULL,
    [Id_Estado_Remision]                BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Consecutivos')
CREATE TABLE [dbo].[Consecutivos] (
    [Id_Consecutivo]                    BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Resolucion]                        VARCHAR(255)            NULL DEFAULT NULL,
    [Valor_Inicial]                     INT                     NULL DEFAULT NULL,
    [Valor_Final]                       INT                     NULL DEFAULT NULL,
    [Incremento]                        INT                     NULL DEFAULT NULL,
    [Valor_Actual]                      INT                     NULL DEFAULT NULL,
    [Caracter_Llenado]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Inicial]                     DATETIME                NULL DEFAULT NULL,
    [Fecha_Final]                       DATETIME                NULL DEFAULT NULL,
    [Sufijo]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Prefijo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Habilitado]                        BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Movimientos')
CREATE TABLE [dbo].[Movimientos] (
    [Id_Movimiento]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Remision]                       BIGINT                  NULL DEFAULT NULL,
    [Numero_Documento]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Movimiento]                BIGINT                  NULL DEFAULT NULL,
    [Id_Estado_Movimiento]              BIGINT                  NULL DEFAULT NULL,
    [Id_Concepto]                       BIGINT                  NULL DEFAULT NULL,
    [Fecha_Creacion]                    DATETIME            NOT NULL DEFAULT GETDATE(),
    [Fecha_Anulacion]                   DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01',
    [Id_Bodega]                         BIGINT                  NULL DEFAULT NULL,
    [Sobre_Costo]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Sobre_Costo_Aplicado_Producto]     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT '1969-12-31 19:00:01'
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Movimientos_Detalles')
CREATE TABLE [dbo].[Movimientos_Detalles] (
    [Id_Movimiento_Detalle]             BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Documento]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Producto]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Valor_Unitario]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Sobre_Costo]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Cantidad]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE(),
    [Id_Estado_Saldo]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones_Compras')
CREATE TABLE [dbo].[Remisiones_Compras] (
    [Id_Remision_Compra]                BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Remision_Compra]            VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Contabilizacion]             DATETIME                NULL DEFAULT NULL,
    [Fecha_Validez]                     DATETIME                NULL DEFAULT NULL,
    [Fecha_Documento]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Necesaria]                   DATETIME                NULL DEFAULT NULL,
    [Numero_Referencia]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Total_Bruto]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Porcentaje_Descuento]              FLOAT                   NULL DEFAULT NULL,
    [Porcentaje_Impuesto]               FLOAT                   NULL DEFAULT NULL,
    [Valor_Total]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Comentarios]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Remision]                       BIGINT                  NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones_Compras_Materiales')
CREATE TABLE [dbo].[Remisiones_Compras_Materiales] (
    [Id_Remision_Compra_Material]       BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Remision_Compra]            VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Necesaria]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Solicitud]                   DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          FLOAT                   NULL DEFAULT NULL,
    [Valor_Unitario]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Porcentaje_Descuento]              FLOAT                   NULL DEFAULT NULL,
    [Costo_Promedio]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Remision_Compra]                BIGINT                  NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones_Venta')
CREATE TABLE [dbo].[Remisiones_Venta] (
    [Numero_Documento]                  VARCHAR(255)        NOT NULL PRIMARY KEY,
    [Fecha_Contabilizacion]             DATETIME                NULL DEFAULT NULL,
    [Fecha_Validez]                     DATETIME                NULL DEFAULT NULL,
    [Fecha_Documento]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Necesaria]                   DATETIME                NULL DEFAULT NULL,
    [Numero_Referencia]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Total_Bruto]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Porcentaje_Descuento]              FLOAT                   NULL DEFAULT NULL,
    [Porcentaje_Impuesto]               FLOAT                   NULL DEFAULT NULL,
    [Valor_Total]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Comentarios]                       VARCHAR(255)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Remision]                       BIGINT                  NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL,
    [Lista_Precio]                      BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Documentos_Conceptos')
CREATE TABLE [dbo].[Tipos_Documentos_Conceptos] (
    [Id_Tipo_Documento_Concepto]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Concepto]                       BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Tipos_Documentos_Tipos_Agentes')
CREATE TABLE [dbo].[Tipos_Documentos_Tipos_Agentes] (
    [Id_Tipo_Documento_Tipo_Agente]     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Documento]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Agente]                    BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Unidad_Medida')
CREATE TABLE [dbo].[Unidad_Medida] (
    [Id_Unidad_Medida]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombre]                            VARCHAR(255)            NULL DEFAULT NULL,
    [Simbolo]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Factor]                            FLOAT                   NULL DEFAULT NULL,
    [Precision]                         FLOAT                   NULL DEFAULT NULL,
    [Conversion]                        FLOAT                   NULL DEFAULT NULL,
    [Decimales]                         INT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Tipo_Unidad_Medida]             BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Lista_De_Materiales')
CREATE TABLE [dbo].[Lista_De_Materiales] (
    [Id_Lista_Material]                 BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Unidad_Medida]                  BIGINT                  NULL DEFAULT NULL,
    [Id_Tipo_Lista_Material]            BIGINT                  NULL DEFAULT NULL,
    [Id_Bodega]                         BIGINT                  NULL DEFAULT NULL,
    [Fecha_Inicio]                      DATETIME                NULL DEFAULT NULL,
    [Fecha_Fin]                         DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          INT                     NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Componente]                 VARCHAR(255)            NULL DEFAULT NULL,
    [Id_Lista_Precio]                   BIGINT                  NULL DEFAULT NULL,
    [Precio_Unitario]                   DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Materiales_Datos_Compra')
CREATE TABLE [dbo].[Materiales_Datos_Compra] (
    [Id_Material_Dato_Compra]           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Material_Compra]            VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Automatic_Purchase]                BIT                     NULL DEFAULT NULL,
    [Gestion_Lotes]                     BIT                     NULL DEFAULT NULL,
    [Tolerancia_Entrega_Inferior]       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Tolerancia_Entrega_Superior]       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Dias_Entrega]                      INT                     NULL DEFAULT NULL,
    [Requiere_Inspeccion]               BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL,
    [Id_Unidad_Medida_Base]             BIGINT                  NULL DEFAULT NULL,
    [Id_Unidad_Medida_Compra]           BIGINT                  NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL,
    [Id_Interlocutor]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Orden_Produccion')
CREATE TABLE [dbo].[Orden_Produccion] (
    [Numero_Orden]                      VARCHAR(20)         NOT NULL PRIMARY KEY,
    [Referencia]                        VARCHAR(20)             NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Id_Estado_Produccion]              BIGINT                  NULL DEFAULT NULL,
    [Id_Ruta_Orden_Trabajo]             BIGINT                  NULL DEFAULT NULL,
    [Id_Lista_Materiales]               BIGINT                  NULL DEFAULT NULL,
    [Id_Unidad_Medida]                  BIGINT                  NULL DEFAULT NULL,
    [Id_Centro_Trabajo]                 BIGINT                  NULL DEFAULT NULL,
    [Fecha_Estimada]                    DATETIME                NULL DEFAULT NULL,
    [Fecha_Inicio_Estimada]             DATETIME                NULL DEFAULT NULL,
    [Fecha_Finalizacion]                DATETIME                NULL DEFAULT NULL,
    [Cantidad_Planificada]              DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Origen_Orden]                      VARCHAR(20)             NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(20)             NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Componentes')
CREATE TABLE [dbo].[Componentes] (
    [Id_Componente]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Orden]                      VARCHAR(20)             NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Id_Unidad_Medida]                  BIGINT                  NULL DEFAULT NULL,
    [Id_Almacen]                        BIGINT                  NULL DEFAULT NULL,
    [Cantidad_Base]                     DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Cantidad_Requerida]                DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Cantidad_Adicional]                DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Cantidad_Consumida]                DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Fecha_Estimada]                    DATETIME                NULL DEFAULT NULL,
    [Fecha_Efectiva]                    DATETIME                NULL DEFAULT NULL,
    [Fecha_Inicio]                      DATETIME                NULL DEFAULT NULL,
    [Fecha_Final]                       DATETIME                NULL DEFAULT NULL,
    [Id_Estado_Componente]              BIGINT                  NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(20)             NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Orden_De_Trabajo')
CREATE TABLE [dbo].[Orden_De_Trabajo] (
    [Id_Orden_Trabajo]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Operacion]                      BIGINT                  NULL DEFAULT NULL,
    [Id_Centro_Trabajo]                 BIGINT                  NULL DEFAULT NULL,
    [Id_Estado_O_T]                     BIGINT                  NULL DEFAULT NULL,
    [Numero_Orden]                      VARCHAR(20)             NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Remisiones_Venta_Materiales')
CREATE TABLE [dbo].[Remisiones_Venta_Materiales] (
    [Id_Remision_Venta_Material]        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Numero_Documento]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Codigo_Material]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha_Necesaria]                   DATETIME                NULL DEFAULT NULL,
    [Fecha_Solicitud]                   DATETIME                NULL DEFAULT NULL,
    [Cantidad]                          FLOAT                   NULL DEFAULT NULL,
    [Valor_Unitario]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Porcentaje_Descuento]              FLOAT                   NULL DEFAULT NULL,
    [Costo_Promedio]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Id_Remision_Compra]                BIGINT                  NULL DEFAULT NULL,
    [Id_Material]                       BIGINT                  NULL DEFAULT NULL,
    [Id_Unidad_Medida]                  BIGINT                  NULL DEFAULT NULL,
    [Cantidad_Unidad_Medida]            DECIMAL(18, 1)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Zonas')
CREATE TABLE [dbo].[Zonas] (
    [Codigo_Zona]                       VARCHAR(20)         NOT NULL PRIMARY KEY,
    [Id_Bodega]                         BIGINT                  NULL DEFAULT NULL,
    [Descripcion_Zona]                  VARCHAR(255)            NULL DEFAULT NULL,
    [Transito_Directo]                  BIT                     NULL DEFAULT NULL,
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
    [Id_Ubicacion]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Codigo_Ubicacion]                  VARCHAR(20)         NOT NULL,
    [Codigo_Zona]                       VARCHAR(20)             NULL DEFAULT NULL,
    [Descripcion_Ubicacion]             VARCHAR(255)            NULL DEFAULT NULL,
    [Dedicado]                          BIT                     NULL DEFAULT NULL,
    [Activo]                            BIT                     NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE()
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Saldos')
CREATE TABLE [dbo].[Saldos] (
    [Id_Saldo]                          BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Estado_Saldo]                   BIGINT                  NULL DEFAULT NULL,
    [Id_Ubicacion]                      BIGINT                  NULL DEFAULT NULL,
    [Codigo_Producto]                   VARCHAR(255)            NULL DEFAULT NULL,
    [Cantidad]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(255)            NULL DEFAULT NULL,
    [Fecha]                             DATETIME            NOT NULL DEFAULT GETDATE()
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Grupo_Interlocutores]
    ADD CONSTRAINT [Fk_Grupo_Interlocutores_Lista_Precio_Id]
        FOREIGN KEY ([Id_Lista_Precio])
        REFERENCES [Listas_Precios] ([Id_Lista_Precio]);

ALTER TABLE [Cotizacion]
    ADD CONSTRAINT [Cotizacion_Plan_Compra_Id_Fk]
        FOREIGN KEY ([Id_Plan_Compra])
        REFERENCES [Plan_Compra] ([Id_Plan_Compra]);

ALTER TABLE [Interlocutores_Comerciales]
    ADD CONSTRAINT [Fk_Interlocutores_Comerciales_Grupo_Interlocutor_Id]
        FOREIGN KEY ([Id_Grupo_Interlocutor])
        REFERENCES [Grupo_Interlocutores] ([Id_Grupo_Interlocutor]),
    CONSTRAINT [Fk_Interlocutores_Comerciales_Tipointerlocutor_Id]
        FOREIGN KEY ([Id_Tipo_Interlocutor])
        REFERENCES [Tipo_Interlocutor_Comercial] ([Id_Tipo_Interlocutor_Comercial]);

ALTER TABLE [Interlocutor_Finanzas]
    ADD CONSTRAINT [Fk_Interlocutores_Comerciales_Finanzas_Interlocutor_Id]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial]);

ALTER TABLE [Interlocutores_Condicion_Pago]
    ADD CONSTRAINT [Fk_Interlocutores_Condicion_Pago_Condicion_Pago_Id]
        FOREIGN KEY ([Id_Condicion_Pago])
        REFERENCES [Condiciones_Pagos] ([Id_Condicion_Pago]),
    CONSTRAINT [Fk_Interlocutores_Condicion_Pago_Lista_Precio_Id]
        FOREIGN KEY ([Id_Lista_Precio])
        REFERENCES [Listas_Precios] ([Id_Lista_Precio]),
    CONSTRAINT [Fk_Interlocutores_Condicion_Pago_Interlocutor_Id]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial]);

ALTER TABLE [Agentes]
    ADD CONSTRAINT [Agentes_Sociedad_Id_Fk]
        FOREIGN KEY ([Id_Sociedad])
        REFERENCES [Sociedad] ([Id_Sociedad])
        ON UPDATE NO ACTION,
    CONSTRAINT [Agentes_Tipos_Agentes_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Agente])
        REFERENCES [Tipos_Agentes] ([Id_Tipo_Agente])
        ON UPDATE NO ACTION;

ALTER TABLE [Bodegas]
    ADD CONSTRAINT [Bodegas_Codigo_Bodega_Uindex]
        UNIQUE ([Codigo_Bodega]),
    CONSTRAINT [Bodegas_Agentes_Id_Fk]
        FOREIGN KEY ([Id_Agente])
        REFERENCES [Agentes] ([Id_Agente])
        ON UPDATE NO ACTION;

ALTER TABLE [Localizaciones]
    ADD CONSTRAINT [Fk_Localizaciones_Interlocutor_Id]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial]),
    CONSTRAINT [Localizaciones_Bodegas_Id_Fk]
        FOREIGN KEY ([Id_Bodega])
        REFERENCES [Bodegas] ([Id_Bodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Remisiones]
    ADD CONSTRAINT [Fk_Remisiones_Agentedestino_Id]
        FOREIGN KEY ([Id_Agente_Destino])
        REFERENCES [Agentes] ([Id_Agente]),
    CONSTRAINT [Fk_Remisiones_Agenteorigen_Id]
        FOREIGN KEY ([Id_Agente_Origen])
        REFERENCES [Agentes] ([Id_Agente]),
    CONSTRAINT [Fk_Remisiones_Estado_Remision_Id]
        FOREIGN KEY ([Id_Estado_Remision])
        REFERENCES [Estados_Remisiones] ([Id_Estado_Remision]);

ALTER TABLE [Materiales]
    ADD CONSTRAINT [Materiales_Codigo_Producto_Uindex]
        UNIQUE ([Codigo_Material]),
    CONSTRAINT [Materiales_Tipos_Materiales_Id_Tipo_Material_Fk]
        FOREIGN KEY ([Id_Tipos_Materiales])
        REFERENCES [Tipos_Materiales] ([Id_Tipo_Material])
        ON UPDATE NO ACTION;

ALTER TABLE [Materiales_Costos_Promedios]
    ADD CONSTRAINT [Materiales_Costos_Promedios_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION;

ALTER TABLE [Materiales_Descripciones]
    ADD CONSTRAINT [Materiales_Descripciones_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material]);

ALTER TABLE [Mm_Codigo_Equivalente]
    ADD CONSTRAINT [Mm_Codigo_Equivalente_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION;

ALTER TABLE [Mm_Tmc_Caracteristica]
    ADD CONSTRAINT [Fk_Tipos_Materiales_Caracteristicas_Tipo_Material_Id]
        FOREIGN KEY ([Id_Tipo_Material])
        REFERENCES [Tipos_Materiales] ([Id_Tipo_Material]);

ALTER TABLE [Materiales_Caracteristicas]
    ADD CONSTRAINT [Materiales_Caracteristicas_Materiales_Id_Material_Fk]
        FOREIGN KEY ([Id_Material])
        REFERENCES [Materiales] ([Id_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Materiales_Caracteristicas_Mm_Tmc_Caracteristica_Fk]
        FOREIGN KEY ([Id_Tipo_Material_Caracteristica])
        REFERENCES [Mm_Tmc_Caracteristica] ([Id_Mm_Tmc_Caracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [Materiales_Caracteristicas]
    ADD CONSTRAINT [Materiales_Caracteristicas_Tipos_Materiales_Id_Tipo_Material_Fk]
        FOREIGN KEY ([Id_Tipo_Material])
        REFERENCES [Tipos_Materiales] ([Id_Tipo_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Materiales_Caracteristicas_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION;

ALTER TABLE [Mm_Tmcd_Descripciones]
    ADD CONSTRAINT [Mm_Tmcd_Tmc_Fk]
        FOREIGN KEY ([Id_Tipo_Material_Caracteristica])
        REFERENCES [Mm_Tmc_Caracteristica] ([Id_Mm_Tmc_Caracteristica])
        ON UPDATE NO ACTION;

ALTER TABLE [Tipos_Documentos]
    ADD CONSTRAINT [Fk_Tipos_Documentos_Estado_Remision_Id]
        FOREIGN KEY ([Id_Estado_Remision])
        REFERENCES [Estados_Remisiones] ([Id_Estado_Remision]),
    CONSTRAINT [Fk_Tipos_Documentos_Tipo_Movimiento_Id1]
        FOREIGN KEY ([Id_Tipo_Movimiento])
        REFERENCES [Tipos_Movimientos] ([Id_Tipo_Movimiento]),
    CONSTRAINT [Fk_Tipos_Documentos_Tipomovimiento_Id2]
        FOREIGN KEY ([Id_Tipo_Movimiento])
        REFERENCES [Tipos_Movimientos] ([Id_Tipo_Movimiento]);

ALTER TABLE [Consecutivos]
    ADD CONSTRAINT [Consecutivos_Tipos_Documentos_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento])
        ON UPDATE NO ACTION;

ALTER TABLE [Movimientos]
    ADD CONSTRAINT [Movimientos_Numero_Documento_Uindex]
        UNIQUE ([Numero_Documento]),
    CONSTRAINT [Movimientos_Bodegas_Id_Fk]
        FOREIGN KEY ([Id_Bodega])
        REFERENCES [Bodegas] ([Id_Bodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [Movimientos_Conceptos_Id_Fk]
        FOREIGN KEY ([Id_Concepto])
        REFERENCES [Conceptos] ([Id_Concepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [Movimientos_Estados_Movimientos_Id_Fk]
        FOREIGN KEY ([Id_Estado_Movimiento])
        REFERENCES [Estados_Movimientos] ([Id_Estado_Movimiento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [Movimientos_Remisiones_Id_Fk]
        FOREIGN KEY ([Id_Remision])
        REFERENCES [Remisiones] ([Id_Remision])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [Movimientos_Tipos_Documentos_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT [Movimientos_Tipos_Movimientos_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Movimiento])
        REFERENCES [Tipos_Movimientos] ([Id_Tipo_Movimiento])
        ON UPDATE NO ACTION;

ALTER TABLE [Movimientos_Detalles]
    ADD CONSTRAINT [Movimientos_Detalles_Estados_Saldos_Id_Fk]
        FOREIGN KEY ([Id_Estado_Saldo])
        REFERENCES [Estados_Saldos] ([Id_Estado_Saldo]),
    CONSTRAINT [Movimientos_Detalles_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Producto])
        REFERENCES [Materiales] ([Codigo_Material]),
    CONSTRAINT [Movimientos_Detalles_Movimientos_Numero_Documento_Fk]
        FOREIGN KEY ([Numero_Documento])
        REFERENCES [Movimientos] ([Numero_Documento]);

ALTER TABLE [Remisiones_Compras]
    ADD CONSTRAINT [Fk_Remisiones_Compras_Tipo_Documento_Id]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento]),
    CONSTRAINT [Fk_Remisiones_Compras_Interlocutor_Id]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial]),
    CONSTRAINT [Fk_Remisiones_Compras_Remision_Id]
        FOREIGN KEY ([Id_Remision])
        REFERENCES [Remisiones] ([Id_Remision]);

ALTER TABLE [Remisiones_Compras_Materiales]
    ADD CONSTRAINT [Fk_Remisiones_Compras_Materiales_Material_Id]
        FOREIGN KEY ([Id_Material])
        REFERENCES [Materiales] ([Id_Material]),
    CONSTRAINT [Fk_Remisiones_Compras_Materiales_Remision_Compra_Id]
        FOREIGN KEY ([Id_Remision_Compra])
        REFERENCES [Remisiones_Compras] ([Id_Remision_Compra]);

ALTER TABLE [Remisiones_Venta]
    ADD CONSTRAINT [Remisiones_Venta_Listas_Precios_Id_Lista_Precio_Fk]
        FOREIGN KEY ([Lista_Precio])
        REFERENCES [Listas_Precios] ([Id_Lista_Precio])
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Remisiones_Venta_Tipo_Documento_Id]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento]),
    CONSTRAINT [Fk_Remisiones_Venta_Interlocutor_Id]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial]),
    CONSTRAINT [Fk_Remisiones_Venta_Remision_Id]
        FOREIGN KEY ([Id_Remision])
        REFERENCES [Remisiones] ([Id_Remision]);

ALTER TABLE [Tipos_Documentos_Conceptos]
    ADD CONSTRAINT [Tipos_Documentos_Conceptos_Conceptos_Id_Fk]
        FOREIGN KEY ([Id_Concepto])
        REFERENCES [Conceptos] ([Id_Concepto])
        ON UPDATE NO ACTION,
    CONSTRAINT [Tipos_Documentos_Conceptos_Tipos_Documentos_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento])
        ON UPDATE NO ACTION;

ALTER TABLE [Tipos_Documentos_Tipos_Agentes]
    ADD CONSTRAINT [Tipos_Documentos_Tipos_Agentes_Tipos_Agentes_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Agente])
        REFERENCES [Tipos_Agentes] ([Id_Tipo_Agente])
        ON UPDATE NO ACTION,
    CONSTRAINT [Tipos_Documentos_Tipos_Agentes_Tipos_Documentos_Id_Fk]
        FOREIGN KEY ([Id_Tipo_Documento])
        REFERENCES [Tipos_Documentos] ([Id_Tipo_Documento])
        ON UPDATE NO ACTION;

ALTER TABLE [Unidad_Medida]
    ADD CONSTRAINT [Fk_Unidad_Medida_Tipo_Unidad_Medida_Id]
        FOREIGN KEY ([Id_Tipo_Unidad_Medida])
        REFERENCES [Tipo_Unidad_Medida] ([Id_Tipo_Unidad_Medida]);

ALTER TABLE [Lista_De_Materiales]
    ADD CONSTRAINT [Lista_De_Materiales_Pk]
        UNIQUE ([Id_Lista_Material]),
    CONSTRAINT [Lista_De_Materiales_Bodegas_Id_Bodega_Fk]
        FOREIGN KEY ([Id_Bodega])
        REFERENCES [Bodegas] ([Id_Bodega])
        ON UPDATE NO ACTION,
    CONSTRAINT [Lista_De_Materiales_Listas_Precios_Id_Lista_Precio_Fk]
        FOREIGN KEY ([Id_Lista_Precio])
        REFERENCES [Listas_Precios] ([Id_Lista_Precio]),
    CONSTRAINT [Lista_De_Materiales_Materiales_Codigo_Material_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Lista_De_Materiales_Materiales_Codigo_Material_Fk2]
        FOREIGN KEY ([Codigo_Componente])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Lista_De_Materiales_Id_Tipo_Lista_Material_Fk]
        FOREIGN KEY ([Id_Tipo_Lista_Material])
        REFERENCES [Tipo_Lista_Material] ([Id_Tipo_Lista_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Lista_De_Materiales_Unidad_Medida_Id_Unidad_Medida_Fk]
        FOREIGN KEY ([Id_Unidad_Medida])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION;

ALTER TABLE [Materiales_Datos_Compra]
    ADD CONSTRAINT [Materiales_Datos_Compra_Interlocutores_Comerciales_Fk]
        FOREIGN KEY ([Id_Interlocutor])
        REFERENCES [Interlocutores_Comerciales] ([Id_Interlocutor_Comercial])
        ON UPDATE NO ACTION,
    CONSTRAINT [Materiales_Datos_Compra_Unidad_Medida_Id_Unidad_Medida_Fk]
        FOREIGN KEY ([Id_Unidad_Medida_Base])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION,
    CONSTRAINT [Materiales_Datos_Compra_Unidad_Medida_Id_Unidad_Medida_Fk2]
        FOREIGN KEY ([Id_Unidad_Medida_Compra])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION,
    CONSTRAINT [Materiales_Datos_Compra_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION;

ALTER TABLE [Orden_Produccion]
    ADD CONSTRAINT [Orden_Produccion_Lista_De_Materiales_Id_Lista_Material_Fk]
        FOREIGN KEY ([Id_Lista_Materiales])
        REFERENCES [Lista_De_Materiales] ([Id_Lista_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Orden_Produccion_Materiales_Codigo_Material_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Orden_Produccion_Unidad_Medida_Id_Unidad_Medida_Fk]
        FOREIGN KEY ([Id_Unidad_Medida])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION;

ALTER TABLE [Componentes]
    ADD CONSTRAINT [Componentes_Materiales_Codigo_Material_Fk]
        FOREIGN KEY ([Codigo_Material])
        REFERENCES [Materiales] ([Codigo_Material])
        ON UPDATE NO ACTION,
    CONSTRAINT [Componentes_Orden_Produccion_Numero_Orden_Fk]
        FOREIGN KEY ([Numero_Orden])
        REFERENCES [Orden_Produccion] ([Numero_Orden])
        ON UPDATE NO ACTION,
    CONSTRAINT [Componentes_Unidad_Medida_Id_Unidad_Medida_Fk]
        FOREIGN KEY ([Id_Unidad_Medida])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION;

ALTER TABLE [Orden_De_Trabajo]
    ADD CONSTRAINT [Orden_De_Trabajo_Centros_Trabajos_Id_Centro_De_Trabajo_Fk]
        FOREIGN KEY ([Id_Centro_Trabajo])
        REFERENCES [Centros_Trabajos] ([Id_Centro_De_Trabajo])
        ON UPDATE NO ACTION,
    CONSTRAINT [Orden_De_Trabajo_Orden_Produccion_Numero_Orden_Fk]
        FOREIGN KEY ([Numero_Orden])
        REFERENCES [Orden_Produccion] ([Numero_Orden])
        ON UPDATE NO ACTION;

ALTER TABLE [Remisiones_Venta_Materiales]
    ADD CONSTRAINT [Remisiones_Venta_Materiales_Unidad_Medida_Id_Unidad_Medida_Fk]
        FOREIGN KEY ([Id_Unidad_Medida])
        REFERENCES [Unidad_Medida] ([Id_Unidad_Medida])
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Remisiones_Venta_Materiales_Material_Id]
        FOREIGN KEY ([Id_Material])
        REFERENCES [Materiales] ([Id_Material]),
    CONSTRAINT [Fk_Remisiones_Venta_Materiales_Remision_Compra_Id]
        FOREIGN KEY ([Numero_Documento])
        REFERENCES [Remisiones_Venta] ([Numero_Documento]);

ALTER TABLE [Zonas]
    ADD CONSTRAINT [Izonas_Codigo_Zona_Uindex]
        UNIQUE ([Codigo_Zona]),
    CONSTRAINT [Zonas_Bodegas_Id_Fk]
        FOREIGN KEY ([Id_Bodega])
        REFERENCES [Bodegas] ([Id_Bodega])
        ON UPDATE NO ACTION;

ALTER TABLE [Ubicaciones]
    ADD CONSTRAINT [Ubicaciones_Codigo_Ubicacion_Uindex]
        UNIQUE ([Codigo_Ubicacion]),
    CONSTRAINT [Ubicaciones_Zonas_Codigo_Zona_Fk]
        FOREIGN KEY ([Codigo_Zona])
        REFERENCES [Zonas] ([Codigo_Zona])
        ON UPDATE NO ACTION;

ALTER TABLE [Saldos]
    ADD CONSTRAINT [Saldos_Estados_Saldos_Id_Fk]
        FOREIGN KEY ([Id_Estado_Saldo])
        REFERENCES [Estados_Saldos] ([Id_Estado_Saldo])
        ON UPDATE NO ACTION,
    CONSTRAINT [Saldos_Materiales_Codigo_Producto_Fk]
        FOREIGN KEY ([Codigo_Producto])
        REFERENCES [Materiales] ([Codigo_Material]),
    CONSTRAINT [Saldos_Ubicaciones_Id_Fk]
        FOREIGN KEY ([Id_Ubicacion])
        REFERENCES [Ubicaciones] ([Id_Ubicacion])
        ON UPDATE NO ACTION
        ON DELETE NO ACTION;
