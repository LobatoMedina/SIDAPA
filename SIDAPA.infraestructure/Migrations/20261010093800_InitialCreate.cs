using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SIDAPA.infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sidapa");

            migrationBuilder.CreateTable(
                name: "cat_aduana_seccion",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    clave_aduana = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    seccion = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    denominacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_aduana_seccion", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_clase_sustancia_peligrosa",
                schema: "sidapa",
                columns: table => new
                {
                    clase = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    denominacion = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    definicion = table.Column<string>(type: "text", nullable: true),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_clase_sustancia_peligrosa", x => x.clase);
                });

            migrationBuilder.CreateTable(
                name: "cat_clave_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    grupo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    subgrupo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    supuestos_aplicacion = table.Column<string>(type: "text", nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_clave_pedimento", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_contribucion",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<short>(type: "smallint", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    abreviacion = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nivel = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_contribucion", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_dependencia",
                schema: "sidapa",
                columns: table => new
                {
                    id_dependencia = table.Column<short>(type: "smallint", nullable: false),
                    nombre = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_dependencia", x => x.id_dependencia);
                });

            migrationBuilder.CreateTable(
                name: "cat_destino_mercancia",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_destino_mercancia", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_estatus",
                schema: "sidapa",
                columns: table => new
                {
                    id_estatus = table.Column<short>(type: "smallint", nullable: false),
                    nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    orden = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_estatus", x => x.id_estatus);
                });

            migrationBuilder.CreateTable(
                name: "cat_forma_pago",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_forma_pago", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_identificador",
                schema: "sidapa",
                columns: table => new
                {
                    id_identificador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    clave = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    nivel = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    supuestos_aplicacion = table.Column<string>(type: "text", nullable: false),
                    complemento1 = table.Column<string>(type: "text", nullable: true),
                    complemento2 = table.Column<string>(type: "text", nullable: true),
                    complemento3 = table.Column<string>(type: "text", nullable: true),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_identificador", x => x.id_identificador);
                });

            migrationBuilder.CreateTable(
                name: "cat_incoterm",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    grupo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_incoterm", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_medio_transporte",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_medio_transporte", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_metodo_valoracion",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_metodo_valoracion", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_moneda",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_moneda", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_pais",
                schema: "sidapa",
                columns: table => new
                {
                    clave_m3 = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    clave_fiii = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    nombre = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_pais", x => x.clave_m3);
                });

            migrationBuilder.CreateTable(
                name: "cat_parametro",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    valor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vigente_desde = table.Column<DateOnly>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_parametro", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_recinto_fiscalizado",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<short>(type: "smallint", nullable: false),
                    aduana = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    autorizado_etr = table.Column<bool>(type: "boolean", nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_recinto_fiscalizado", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_regimen",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_regimen", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_rfe",
                schema: "sidapa",
                columns: table => new
                {
                    clave_rfe = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    aduana = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    administrador = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    colindante = table.Column<bool>(type: "boolean", nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_rfe", x => x.clave_rfe);
                });

            migrationBuilder.CreateTable(
                name: "cat_rol",
                schema: "sidapa",
                columns: table => new
                {
                    id_rol = table.Column<short>(type: "smallint", nullable: false),
                    nombre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_rol", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipo_contenedor",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_tipo_contenedor", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipo_documento",
                schema: "sidapa",
                columns: table => new
                {
                    id_tipo_documento = table.Column<short>(type: "smallint", nullable: false),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_tipo_documento", x => x.id_tipo_documento);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipo_operacion",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<short>(type: "smallint", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_tipo_operacion", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipo_tasa",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_tipo_tasa", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "cat_unidad_medida",
                schema: "sidapa",
                columns: table => new
                {
                    clave = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_unidad_medida", x => x.clave);
                });

            migrationBuilder.CreateTable(
                name: "ope_cliente",
                schema: "sidapa",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    rfc = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    curp = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    razon_social = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    domicilio = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    correo_avisos = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "cat_agente_aduanal",
                schema: "sidapa",
                columns: table => new
                {
                    patente = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    rfc = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    tipo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    clave_aduana = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_agente_aduanal", x => x.patente);
                    table.ForeignKey(
                        name: "fk_cat_agente_aduanal_clave_aduana",
                        column: x => x.clave_aduana,
                        principalSchema: "sidapa",
                        principalTable: "cat_aduana_seccion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_division_sustancia_peligrosa",
                schema: "sidapa",
                columns: table => new
                {
                    division = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    clase = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_division_sustancia_peligrosa", x => x.division);
                    table.ForeignKey(
                        name: "fk_cat_division_sustancia_peligrosa_clase",
                        column: x => x.clase,
                        principalSchema: "sidapa",
                        principalTable: "cat_clase_sustancia_peligrosa",
                        principalColumn: "clase",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_regulacion",
                schema: "sidapa",
                columns: table => new
                {
                    id_regulacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_dependencia = table.Column<short>(type: "smallint", nullable: false),
                    clave = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_regulacion", x => x.id_regulacion);
                    table.ForeignKey(
                        name: "fk_cat_regulacion_id_dependencia",
                        column: x => x.id_dependencia,
                        principalSchema: "sidapa",
                        principalTable: "cat_dependencia",
                        principalColumn: "id_dependencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_moneda_pais",
                schema: "sidapa",
                columns: table => new
                {
                    id_moneda_pais = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    pais = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    clave_moneda = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_moneda_pais", x => x.id_moneda_pais);
                    table.ForeignKey(
                        name: "fk_cat_moneda_pais_clave_moneda",
                        column: x => x.clave_moneda,
                        principalSchema: "sidapa",
                        principalTable: "cat_moneda",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipo_cambio",
                schema: "sidapa",
                columns: table => new
                {
                    id_tipo_cambio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    clave_moneda = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    tipo_cambio = table.Column<decimal>(type: "numeric(10,5)", precision: 10, scale: 5, nullable: false),
                    factor_equivalencia = table.Column<decimal>(type: "numeric(14,8)", precision: 14, scale: 8, nullable: true),
                    fuente = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_tipo_cambio", x => x.id_tipo_cambio);
                    table.ForeignKey(
                        name: "fk_cat_tipo_cambio_clave_moneda",
                        column: x => x.clave_moneda,
                        principalSchema: "sidapa",
                        principalTable: "cat_moneda",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_proveedor",
                schema: "sidapa",
                columns: table => new
                {
                    id_proveedor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    id_fiscal = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    domicilio = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    clave_pais = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_proveedor", x => x.id_proveedor);
                    table.ForeignKey(
                        name: "fk_ope_proveedor_clave_pais",
                        column: x => x.clave_pais,
                        principalSchema: "sidapa",
                        principalTable: "cat_pais",
                        principalColumn: "clave_m3",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_rfe_operador",
                schema: "sidapa",
                columns: table => new
                {
                    clave_operador = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    clave_rfe = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    vigente = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_actualizacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_rfe_operador", x => x.clave_operador);
                    table.ForeignKey(
                        name: "fk_cat_rfe_operador_clave_rfe",
                        column: x => x.clave_rfe,
                        principalSchema: "sidapa",
                        principalTable: "cat_rfe",
                        principalColumn: "clave_rfe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_documento_requerido",
                schema: "sidapa",
                columns: table => new
                {
                    id_documento_requerido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    tipo_operacion = table.Column<short>(type: "smallint", nullable: false),
                    clave_pedimento = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: true),
                    id_tipo_documento = table.Column<short>(type: "smallint", nullable: false),
                    obligatorio = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_documento_requerido", x => x.id_documento_requerido);
                    table.ForeignKey(
                        name: "fk_cat_documento_requerido_clave_pedimento",
                        column: x => x.clave_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "cat_clave_pedimento",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_cat_documento_requerido_id_tipo_documento",
                        column: x => x.id_tipo_documento,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_documento",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cat_documento_requerido_tipo_operacion",
                        column: x => x.tipo_operacion,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_operacion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_fraccion_arancelaria",
                schema: "sidapa",
                columns: table => new
                {
                    id_fraccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    fraccion = table.Column<string>(type: "character(8)", fixedLength: true, maxLength: 8, nullable: false),
                    nico = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    clave_unidad_tarifa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    tasa_igi = table.Column<decimal>(type: "numeric(7,4)", precision: 7, scale: 4, nullable: true),
                    tasa_ige = table.Column<decimal>(type: "numeric(7,4)", precision: 7, scale: 4, nullable: true),
                    vigente_desde = table.Column<DateOnly>(type: "date", nullable: false),
                    vigente_hasta = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_fraccion_arancelaria", x => x.id_fraccion);
                    table.ForeignKey(
                        name: "fk_cat_fraccion_arancelaria_clave_unidad_tarifa",
                        column: x => x.clave_unidad_tarifa,
                        principalSchema: "sidapa",
                        principalTable: "cat_unidad_medida",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_usuario",
                schema: "sidapa",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    contrasena_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    id_rol = table.Column<short>(type: "smallint", nullable: false),
                    id_cliente = table.Column<int>(type: "integer", nullable: true),
                    intentos_fallidos = table.Column<short>(type: "smallint", nullable: false),
                    bloqueado_hasta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_usuario", x => x.id_usuario);
                    table.ForeignKey(
                        name: "fk_ope_usuario_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "sidapa",
                        principalTable: "ope_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_usuario_id_rol",
                        column: x => x.id_rol,
                        principalSchema: "sidapa",
                        principalTable: "cat_rol",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cat_consecutivo_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    id_consecutivo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    patente = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    clave_aduana = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    anio = table.Column<short>(type: "smallint", nullable: false),
                    ultimo_consecutivo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cat_consecutivo_pedimento", x => x.id_consecutivo);
                    table.ForeignKey(
                        name: "fk_cat_consecutivo_pedimento_clave_aduana",
                        column: x => x.clave_aduana,
                        principalSchema: "sidapa",
                        principalTable: "cat_aduana_seccion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cat_consecutivo_pedimento_patente",
                        column: x => x.patente,
                        principalSchema: "sidapa",
                        principalTable: "cat_agente_aduanal",
                        principalColumn: "patente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_producto",
                schema: "sidapa",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_cliente = table.Column<int>(type: "integer", nullable: false),
                    numero_parte = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    id_fraccion = table.Column<int>(type: "integer", nullable: true),
                    estado = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    id_glosador = table.Column<int>(type: "integer", nullable: true),
                    fecha_aprobacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_producto", x => x.id_producto);
                    table.ForeignKey(
                        name: "fk_ope_producto_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "sidapa",
                        principalTable: "ope_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_producto_id_fraccion",
                        column: x => x.id_fraccion,
                        principalSchema: "sidapa",
                        principalTable: "cat_fraccion_arancelaria",
                        principalColumn: "id_fraccion",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_producto_id_glosador",
                        column: x => x.id_glosador,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ope_referencia",
                schema: "sidapa",
                columns: table => new
                {
                    id_referencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    numero_referencia = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_cliente = table.Column<int>(type: "integer", nullable: false),
                    id_capturador = table.Column<int>(type: "integer", nullable: true),
                    tipo_operacion = table.Column<short>(type: "smallint", nullable: false),
                    clave_aduana = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    bl_master = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    fecha_arribo = table.Column<DateOnly>(type: "date", nullable: true),
                    observaciones = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    id_estatus = table.Column<short>(type: "smallint", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_referencia", x => x.id_referencia);
                    table.ForeignKey(
                        name: "fk_ope_referencia_clave_aduana",
                        column: x => x.clave_aduana,
                        principalSchema: "sidapa",
                        principalTable: "cat_aduana_seccion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_referencia_id_capturador",
                        column: x => x.id_capturador,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_referencia_id_cliente",
                        column: x => x.id_cliente,
                        principalSchema: "sidapa",
                        principalTable: "ope_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_referencia_id_estatus",
                        column: x => x.id_estatus,
                        principalSchema: "sidapa",
                        principalTable: "cat_estatus",
                        principalColumn: "id_estatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_referencia_tipo_operacion",
                        column: x => x.tipo_operacion,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_operacion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_bitacora_estatus",
                schema: "sidapa",
                columns: table => new
                {
                    id_bitacora = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_referencia = table.Column<int>(type: "integer", nullable: false),
                    id_estatus = table.Column<short>(type: "smallint", nullable: false),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    comentario = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_bitacora_estatus", x => x.id_bitacora);
                    table.ForeignKey(
                        name: "fk_ope_bitacora_estatus_id_estatus",
                        column: x => x.id_estatus,
                        principalSchema: "sidapa",
                        principalTable: "cat_estatus",
                        principalColumn: "id_estatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_bitacora_estatus_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_bitacora_estatus_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_documento",
                schema: "sidapa",
                columns: table => new
                {
                    id_documento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_referencia = table.Column<int>(type: "integer", nullable: false),
                    id_tipo_documento = table.Column<short>(type: "smallint", nullable: false),
                    nombre_archivo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ruta_bucket = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    tamano_bytes = table.Column<int>(type: "integer", nullable: false),
                    estado = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    nota = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    id_usuario_carga = table.Column<int>(type: "integer", nullable: false),
                    fecha_carga = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_documento", x => x.id_documento);
                    table.ForeignKey(
                        name: "fk_ope_documento_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_documento_id_tipo_documento",
                        column: x => x.id_tipo_documento,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_documento",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_documento_id_usuario_carga",
                        column: x => x.id_usuario_carga,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_notificacion",
                schema: "sidapa",
                columns: table => new
                {
                    id_notificacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_referencia = table.Column<int>(type: "integer", nullable: true),
                    mensaje = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    leida = table.Column<bool>(type: "boolean", nullable: false),
                    enviada_correo = table.Column<bool>(type: "boolean", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_notificacion", x => x.id_notificacion);
                    table.ForeignKey(
                        name: "fk_ope_notificacion_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_notificacion_id_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    id_pedimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_referencia = table.Column<int>(type: "integer", nullable: false),
                    numero_pedimento = table.Column<string>(type: "character(15)", fixedLength: true, maxLength: 15, nullable: true),
                    patente = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    tipo_operacion = table.Column<short>(type: "smallint", nullable: false),
                    clave_pedimento = table.Column<string>(type: "character(2)", fixedLength: true, maxLength: 2, nullable: false),
                    clave_regimen = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    clave_destino = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    clave_aduana_despacho = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    clave_aduana_entrada = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: true),
                    medio_entrada = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    medio_arribo = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    medio_salida = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    tipo_cambio = table.Column<decimal>(type: "numeric(10,5)", precision: 10, scale: 5, nullable: false),
                    peso_bruto = table.Column<decimal>(type: "numeric(14,3)", precision: 14, scale: 3, nullable: false),
                    valor_dolares = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    valor_aduana = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    valor_comercial = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    fletes = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    seguros = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    embalajes = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    otros_incrementables = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    fecha_entrada = table.Column<DateOnly>(type: "date", nullable: true),
                    fecha_pago = table.Column<DateOnly>(type: "date", nullable: true),
                    total_efectivo = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    total_otros = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_glosador = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_pedimento", x => x.id_pedimento);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_clave_aduana_despacho",
                        column: x => x.clave_aduana_despacho,
                        principalSchema: "sidapa",
                        principalTable: "cat_aduana_seccion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_clave_aduana_entrada",
                        column: x => x.clave_aduana_entrada,
                        principalSchema: "sidapa",
                        principalTable: "cat_aduana_seccion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_clave_destino",
                        column: x => x.clave_destino,
                        principalSchema: "sidapa",
                        principalTable: "cat_destino_mercancia",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_clave_pedimento",
                        column: x => x.clave_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "cat_clave_pedimento",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_clave_regimen",
                        column: x => x.clave_regimen,
                        principalSchema: "sidapa",
                        principalTable: "cat_regimen",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_id_glosador",
                        column: x => x.id_glosador,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_medio_arribo",
                        column: x => x.medio_arribo,
                        principalSchema: "sidapa",
                        principalTable: "cat_medio_transporte",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_medio_entrada",
                        column: x => x.medio_entrada,
                        principalSchema: "sidapa",
                        principalTable: "cat_medio_transporte",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_medio_salida",
                        column: x => x.medio_salida,
                        principalSchema: "sidapa",
                        principalTable: "cat_medio_transporte",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_patente",
                        column: x => x.patente,
                        principalSchema: "sidapa",
                        principalTable: "cat_agente_aduanal",
                        principalColumn: "patente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_pedimento_tipo_operacion",
                        column: x => x.tipo_operacion,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_operacion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_factura",
                schema: "sidapa",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_referencia = table.Column<int>(type: "integer", nullable: false),
                    id_documento = table.Column<int>(type: "integer", nullable: true),
                    id_proveedor = table.Column<int>(type: "integer", nullable: false),
                    numero_factura = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    fecha_factura = table.Column<DateOnly>(type: "date", nullable: false),
                    clave_moneda = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    incoterm = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    valor_moneda = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    factor_moneda = table.Column<decimal>(type: "numeric(14,8)", precision: 14, scale: 8, nullable: true),
                    valor_dolares = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: true),
                    origen_lectura = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    confirmada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_factura", x => x.id_factura);
                    table.ForeignKey(
                        name: "fk_ope_factura_clave_moneda",
                        column: x => x.clave_moneda,
                        principalSchema: "sidapa",
                        principalTable: "cat_moneda",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_factura_id_documento",
                        column: x => x.id_documento,
                        principalSchema: "sidapa",
                        principalTable: "ope_documento",
                        principalColumn: "id_documento",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_factura_id_proveedor",
                        column: x => x.id_proveedor,
                        principalSchema: "sidapa",
                        principalTable: "ope_proveedor",
                        principalColumn: "id_proveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_factura_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_factura_incoterm",
                        column: x => x.incoterm,
                        principalSchema: "sidapa",
                        principalTable: "cat_incoterm",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_solicitud_documento",
                schema: "sidapa",
                columns: table => new
                {
                    id_solicitud = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_referencia = table.Column<int>(type: "integer", nullable: false),
                    id_tipo_documento = table.Column<short>(type: "smallint", nullable: false),
                    nota = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    id_capturador = table.Column<int>(type: "integer", nullable: false),
                    fecha_solicitud = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id_documento_respuesta = table.Column<int>(type: "integer", nullable: true),
                    fecha_atencion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_solicitud_documento", x => x.id_solicitud);
                    table.ForeignKey(
                        name: "fk_ope_solicitud_documento_id_capturador",
                        column: x => x.id_capturador,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_solicitud_documento_id_documento_respuesta",
                        column: x => x.id_documento_respuesta,
                        principalSchema: "sidapa",
                        principalTable: "ope_documento",
                        principalColumn: "id_documento",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_ope_solicitud_documento_id_referencia",
                        column: x => x.id_referencia,
                        principalSchema: "sidapa",
                        principalTable: "ope_referencia",
                        principalColumn: "id_referencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_solicitud_documento_id_tipo_documento",
                        column: x => x.id_tipo_documento,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_documento",
                        principalColumn: "id_tipo_documento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ope_archivo_validacion",
                schema: "sidapa",
                columns: table => new
                {
                    id_archivo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    nombre_archivo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ruta_bucket = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    fecha_generacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    resultado = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    acuse = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    detalle_respuesta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_archivo_validacion", x => x.id_archivo);
                    table.ForeignKey(
                        name: "fk_ope_archivo_validacion_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_contenedor",
                schema: "sidapa",
                columns: table => new
                {
                    id_contenedor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    numero = table.Column<string>(type: "character(11)", fixedLength: true, maxLength: 11, nullable: false),
                    clave_tipo = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    candados = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_contenedor", x => x.id_contenedor);
                    table.ForeignKey(
                        name: "fk_ope_contenedor_clave_tipo",
                        column: x => x.clave_tipo,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_contenedor",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contenedor_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_contribucion_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    id_contribucion_ped = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    clave_contribucion = table.Column<short>(type: "smallint", nullable: false),
                    clave_tipo_tasa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    tasa = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    clave_forma_pago = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    importe = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_contribucion_pedimento", x => x.id_contribucion_ped);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_pedimento_clave_contribucion",
                        column: x => x.clave_contribucion,
                        principalSchema: "sidapa",
                        principalTable: "cat_contribucion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_pedimento_clave_forma_pago",
                        column: x => x.clave_forma_pago,
                        principalSchema: "sidapa",
                        principalTable: "cat_forma_pago",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_pedimento_clave_tipo_tasa",
                        column: x => x.clave_tipo_tasa,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_tasa",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_pedimento_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_guia",
                schema: "sidapa",
                columns: table => new
                {
                    id_guia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    numero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tipo = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_guia", x => x.id_guia);
                    table.ForeignKey(
                        name: "fk_ope_guia_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_identificador_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    id_identificador_ped = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    id_identificador = table.Column<int>(type: "integer", nullable: false),
                    complemento1 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    complemento2 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    complemento3 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_identificador_pedimento", x => x.id_identificador_ped);
                    table.ForeignKey(
                        name: "fk_ope_identificador_pedimento_id_identificador",
                        column: x => x.id_identificador,
                        principalSchema: "sidapa",
                        principalTable: "cat_identificador",
                        principalColumn: "id_identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_identificador_pedimento_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_partida",
                schema: "sidapa",
                columns: table => new
                {
                    id_partida = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    numero_partida = table.Column<short>(type: "smallint", nullable: false),
                    id_fraccion = table.Column<int>(type: "integer", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    clave_metodo_valoracion = table.Column<string>(type: "character(1)", fixedLength: true, maxLength: 1, nullable: false),
                    clave_umc = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cantidad_umc = table.Column<decimal>(type: "numeric(14,3)", precision: 14, scale: 3, nullable: false),
                    clave_umt = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cantidad_umt = table.Column<decimal>(type: "numeric(14,3)", precision: 14, scale: 3, nullable: false),
                    clave_pais_origen = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    clave_pais_vendedor = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    valor_aduana = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    precio_pagado = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    precio_unitario = table.Column<decimal>(type: "numeric(16,5)", precision: 16, scale: 5, nullable: false),
                    valor_agregado = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_partida", x => x.id_partida);
                    table.ForeignKey(
                        name: "fk_ope_partida_clave_metodo_valoracion",
                        column: x => x.clave_metodo_valoracion,
                        principalSchema: "sidapa",
                        principalTable: "cat_metodo_valoracion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_clave_pais_origen",
                        column: x => x.clave_pais_origen,
                        principalSchema: "sidapa",
                        principalTable: "cat_pais",
                        principalColumn: "clave_m3",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_clave_pais_vendedor",
                        column: x => x.clave_pais_vendedor,
                        principalSchema: "sidapa",
                        principalTable: "cat_pais",
                        principalColumn: "clave_m3",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_clave_umc",
                        column: x => x.clave_umc,
                        principalSchema: "sidapa",
                        principalTable: "cat_unidad_medida",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_clave_umt",
                        column: x => x.clave_umt,
                        principalSchema: "sidapa",
                        principalTable: "cat_unidad_medida",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_id_fraccion",
                        column: x => x.id_fraccion,
                        principalSchema: "sidapa",
                        principalTable: "cat_fraccion_arancelaria",
                        principalColumn: "id_fraccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_partida_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_transporte_pedimento",
                schema: "sidapa",
                columns: table => new
                {
                    id_transporte = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    identificacion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clave_pais = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    transportista = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_transporte_pedimento", x => x.id_transporte);
                    table.ForeignKey(
                        name: "fk_ope_transporte_pedimento_clave_pais",
                        column: x => x.clave_pais,
                        principalSchema: "sidapa",
                        principalTable: "cat_pais",
                        principalColumn: "clave_m3",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_transporte_pedimento_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_renglon_factura",
                schema: "sidapa",
                columns: table => new
                {
                    id_renglon = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_factura = table.Column<int>(type: "integer", nullable: false),
                    numero_parte = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    cantidad = table.Column<decimal>(type: "numeric(14,3)", precision: 14, scale: 3, nullable: false),
                    clave_unidad = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    precio_unitario = table.Column<decimal>(type: "numeric(16,5)", precision: 16, scale: 5, nullable: false),
                    importe = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false),
                    clave_pais_origen = table.Column<string>(type: "character(3)", fixedLength: true, maxLength: 3, nullable: false),
                    confianza = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    id_producto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_renglon_factura", x => x.id_renglon);
                    table.ForeignKey(
                        name: "fk_ope_renglon_factura_clave_pais_origen",
                        column: x => x.clave_pais_origen,
                        principalSchema: "sidapa",
                        principalTable: "cat_pais",
                        principalColumn: "clave_m3",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_renglon_factura_clave_unidad",
                        column: x => x.clave_unidad,
                        principalSchema: "sidapa",
                        principalTable: "cat_unidad_medida",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_renglon_factura_id_factura",
                        column: x => x.id_factura,
                        principalSchema: "sidapa",
                        principalTable: "ope_factura",
                        principalColumn: "id_factura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_renglon_factura_id_producto",
                        column: x => x.id_producto,
                        principalSchema: "sidapa",
                        principalTable: "ope_producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ope_anotacion",
                schema: "sidapa",
                columns: table => new
                {
                    id_anotacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_pedimento = table.Column<int>(type: "integer", nullable: false),
                    id_partida = table.Column<int>(type: "integer", nullable: true),
                    campo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    comentario = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    estado = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    id_glosador = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_anotacion", x => x.id_anotacion);
                    table.ForeignKey(
                        name: "fk_ope_anotacion_id_glosador",
                        column: x => x.id_glosador,
                        principalSchema: "sidapa",
                        principalTable: "ope_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_anotacion_id_partida",
                        column: x => x.id_partida,
                        principalSchema: "sidapa",
                        principalTable: "ope_partida",
                        principalColumn: "id_partida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_anotacion_id_pedimento",
                        column: x => x.id_pedimento,
                        principalSchema: "sidapa",
                        principalTable: "ope_pedimento",
                        principalColumn: "id_pedimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_contribucion_partida",
                schema: "sidapa",
                columns: table => new
                {
                    id_contribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_partida = table.Column<int>(type: "integer", nullable: false),
                    clave_contribucion = table.Column<short>(type: "smallint", nullable: false),
                    clave_tipo_tasa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    tasa = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    clave_forma_pago = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    importe = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_contribucion_partida", x => x.id_contribucion);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_partida_clave_contribucion",
                        column: x => x.clave_contribucion,
                        principalSchema: "sidapa",
                        principalTable: "cat_contribucion",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_partida_clave_forma_pago",
                        column: x => x.clave_forma_pago,
                        principalSchema: "sidapa",
                        principalTable: "cat_forma_pago",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_partida_clave_tipo_tasa",
                        column: x => x.clave_tipo_tasa,
                        principalSchema: "sidapa",
                        principalTable: "cat_tipo_tasa",
                        principalColumn: "clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_contribucion_partida_id_partida",
                        column: x => x.id_partida,
                        principalSchema: "sidapa",
                        principalTable: "ope_partida",
                        principalColumn: "id_partida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_identificador_partida",
                schema: "sidapa",
                columns: table => new
                {
                    id_identificador_partida = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_partida = table.Column<int>(type: "integer", nullable: false),
                    id_identificador = table.Column<int>(type: "integer", nullable: false),
                    complemento1 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    complemento2 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    complemento3 = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_identificador_partida", x => x.id_identificador_partida);
                    table.ForeignKey(
                        name: "fk_ope_identificador_partida_id_identificador",
                        column: x => x.id_identificador,
                        principalSchema: "sidapa",
                        principalTable: "cat_identificador",
                        principalColumn: "id_identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ope_identificador_partida_id_partida",
                        column: x => x.id_partida,
                        principalSchema: "sidapa",
                        principalTable: "ope_partida",
                        principalColumn: "id_partida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ope_permiso_partida",
                schema: "sidapa",
                columns: table => new
                {
                    id_permiso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    id_partida = table.Column<int>(type: "integer", nullable: false),
                    id_regulacion = table.Column<int>(type: "integer", nullable: false),
                    numero_permiso = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    firma_descargo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    valor_dolares = table.Column<decimal>(type: "numeric(16,2)", precision: 16, scale: 2, nullable: true),
                    cantidad_umt = table.Column<decimal>(type: "numeric(14,3)", precision: 14, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ope_permiso_partida", x => x.id_permiso);
                    table.ForeignKey(
                        name: "fk_ope_permiso_partida_id_partida",
                        column: x => x.id_partida,
                        principalSchema: "sidapa",
                        principalTable: "ope_partida",
                        principalColumn: "id_partida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ope_permiso_partida_id_regulacion",
                        column: x => x.id_regulacion,
                        principalSchema: "sidapa",
                        principalTable: "cat_regulacion",
                        principalColumn: "id_regulacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cat_agente_aduanal_clave_aduana",
                schema: "sidapa",
                table: "cat_agente_aduanal",
                column: "clave_aduana");

            migrationBuilder.CreateIndex(
                name: "IX_cat_consecutivo_pedimento_clave_aduana",
                schema: "sidapa",
                table: "cat_consecutivo_pedimento",
                column: "clave_aduana");

            migrationBuilder.CreateIndex(
                name: "uq_cat_consecutivo_pedimento_1",
                schema: "sidapa",
                table: "cat_consecutivo_pedimento",
                columns: new[] { "patente", "clave_aduana", "anio" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cat_dependencia_1",
                schema: "sidapa",
                table: "cat_dependencia",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_division_sustancia_peligrosa_clase",
                schema: "sidapa",
                table: "cat_division_sustancia_peligrosa",
                column: "clase");

            migrationBuilder.CreateIndex(
                name: "IX_cat_documento_requerido_clave_pedimento",
                schema: "sidapa",
                table: "cat_documento_requerido",
                column: "clave_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_cat_documento_requerido_id_tipo_documento",
                schema: "sidapa",
                table: "cat_documento_requerido",
                column: "id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_cat_documento_requerido_tipo_operacion",
                schema: "sidapa",
                table: "cat_documento_requerido",
                column: "tipo_operacion");

            migrationBuilder.CreateIndex(
                name: "uq_cat_estatus_1",
                schema: "sidapa",
                table: "cat_estatus",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_fraccion_arancelaria_clave_unidad_tarifa",
                schema: "sidapa",
                table: "cat_fraccion_arancelaria",
                column: "clave_unidad_tarifa");

            migrationBuilder.CreateIndex(
                name: "uq_cat_fraccion_arancelaria_1",
                schema: "sidapa",
                table: "cat_fraccion_arancelaria",
                columns: new[] { "fraccion", "nico" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cat_identificador_1",
                schema: "sidapa",
                table: "cat_identificador",
                columns: new[] { "clave", "nivel" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_moneda_pais_clave_moneda",
                schema: "sidapa",
                table: "cat_moneda_pais",
                column: "clave_moneda");

            migrationBuilder.CreateIndex(
                name: "uq_cat_pais_1",
                schema: "sidapa",
                table: "cat_pais",
                column: "clave_fiii",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cat_regulacion_1",
                schema: "sidapa",
                table: "cat_regulacion",
                columns: new[] { "id_dependencia", "clave" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_rfe_operador_clave_rfe",
                schema: "sidapa",
                table: "cat_rfe_operador",
                column: "clave_rfe");

            migrationBuilder.CreateIndex(
                name: "uq_cat_rol_1",
                schema: "sidapa",
                table: "cat_rol",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_tipo_cambio_clave_moneda",
                schema: "sidapa",
                table: "cat_tipo_cambio",
                column: "clave_moneda");

            migrationBuilder.CreateIndex(
                name: "uq_cat_tipo_cambio_1",
                schema: "sidapa",
                table: "cat_tipo_cambio",
                columns: new[] { "fecha", "clave_moneda" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cat_tipo_documento_1",
                schema: "sidapa",
                table: "cat_tipo_documento",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ope_anotacion_id_glosador",
                schema: "sidapa",
                table: "ope_anotacion",
                column: "id_glosador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_anotacion_id_partida",
                schema: "sidapa",
                table: "ope_anotacion",
                column: "id_partida");

            migrationBuilder.CreateIndex(
                name: "IX_ope_anotacion_id_pedimento",
                schema: "sidapa",
                table: "ope_anotacion",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_archivo_validacion_id_pedimento",
                schema: "sidapa",
                table: "ope_archivo_validacion",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_bitacora_estatus_id_estatus",
                schema: "sidapa",
                table: "ope_bitacora_estatus",
                column: "id_estatus");

            migrationBuilder.CreateIndex(
                name: "IX_ope_bitacora_estatus_id_referencia",
                schema: "sidapa",
                table: "ope_bitacora_estatus",
                column: "id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ope_bitacora_estatus_id_usuario",
                schema: "sidapa",
                table: "ope_bitacora_estatus",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "uq_ope_cliente_1",
                schema: "sidapa",
                table: "ope_cliente",
                column: "rfc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ope_contenedor_clave_tipo",
                schema: "sidapa",
                table: "ope_contenedor",
                column: "clave_tipo");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contenedor_id_pedimento",
                schema: "sidapa",
                table: "ope_contenedor",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_partida_clave_contribucion",
                schema: "sidapa",
                table: "ope_contribucion_partida",
                column: "clave_contribucion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_partida_clave_forma_pago",
                schema: "sidapa",
                table: "ope_contribucion_partida",
                column: "clave_forma_pago");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_partida_clave_tipo_tasa",
                schema: "sidapa",
                table: "ope_contribucion_partida",
                column: "clave_tipo_tasa");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_partida_id_partida",
                schema: "sidapa",
                table: "ope_contribucion_partida",
                column: "id_partida");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_pedimento_clave_contribucion",
                schema: "sidapa",
                table: "ope_contribucion_pedimento",
                column: "clave_contribucion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_pedimento_clave_forma_pago",
                schema: "sidapa",
                table: "ope_contribucion_pedimento",
                column: "clave_forma_pago");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_pedimento_clave_tipo_tasa",
                schema: "sidapa",
                table: "ope_contribucion_pedimento",
                column: "clave_tipo_tasa");

            migrationBuilder.CreateIndex(
                name: "IX_ope_contribucion_pedimento_id_pedimento",
                schema: "sidapa",
                table: "ope_contribucion_pedimento",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_documento_id_referencia",
                schema: "sidapa",
                table: "ope_documento",
                column: "id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ope_documento_id_tipo_documento",
                schema: "sidapa",
                table: "ope_documento",
                column: "id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_documento_id_usuario_carga",
                schema: "sidapa",
                table: "ope_documento",
                column: "id_usuario_carga");

            migrationBuilder.CreateIndex(
                name: "IX_ope_factura_clave_moneda",
                schema: "sidapa",
                table: "ope_factura",
                column: "clave_moneda");

            migrationBuilder.CreateIndex(
                name: "IX_ope_factura_id_documento",
                schema: "sidapa",
                table: "ope_factura",
                column: "id_documento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_factura_id_proveedor",
                schema: "sidapa",
                table: "ope_factura",
                column: "id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ope_factura_id_referencia",
                schema: "sidapa",
                table: "ope_factura",
                column: "id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ope_factura_incoterm",
                schema: "sidapa",
                table: "ope_factura",
                column: "incoterm");

            migrationBuilder.CreateIndex(
                name: "IX_ope_guia_id_pedimento",
                schema: "sidapa",
                table: "ope_guia",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_identificador_partida_id_identificador",
                schema: "sidapa",
                table: "ope_identificador_partida",
                column: "id_identificador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_identificador_partida_id_partida",
                schema: "sidapa",
                table: "ope_identificador_partida",
                column: "id_partida");

            migrationBuilder.CreateIndex(
                name: "IX_ope_identificador_pedimento_id_identificador",
                schema: "sidapa",
                table: "ope_identificador_pedimento",
                column: "id_identificador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_identificador_pedimento_id_pedimento",
                schema: "sidapa",
                table: "ope_identificador_pedimento",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_notificacion_id_referencia",
                schema: "sidapa",
                table: "ope_notificacion",
                column: "id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ope_notificacion_id_usuario",
                schema: "sidapa",
                table: "ope_notificacion",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_clave_metodo_valoracion",
                schema: "sidapa",
                table: "ope_partida",
                column: "clave_metodo_valoracion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_clave_pais_origen",
                schema: "sidapa",
                table: "ope_partida",
                column: "clave_pais_origen");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_clave_pais_vendedor",
                schema: "sidapa",
                table: "ope_partida",
                column: "clave_pais_vendedor");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_clave_umc",
                schema: "sidapa",
                table: "ope_partida",
                column: "clave_umc");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_clave_umt",
                schema: "sidapa",
                table: "ope_partida",
                column: "clave_umt");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_id_fraccion",
                schema: "sidapa",
                table: "ope_partida",
                column: "id_fraccion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_partida_id_pedimento",
                schema: "sidapa",
                table: "ope_partida",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_clave_aduana_despacho",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "clave_aduana_despacho");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_clave_aduana_entrada",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "clave_aduana_entrada");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_clave_destino",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "clave_destino");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_clave_pedimento",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "clave_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_clave_regimen",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "clave_regimen");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_id_glosador",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "id_glosador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_medio_arribo",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "medio_arribo");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_medio_entrada",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "medio_entrada");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_medio_salida",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "medio_salida");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_patente",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "patente");

            migrationBuilder.CreateIndex(
                name: "IX_ope_pedimento_tipo_operacion",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "tipo_operacion");

            migrationBuilder.CreateIndex(
                name: "uq_ope_pedimento_1",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "id_referencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_ope_pedimento_2",
                schema: "sidapa",
                table: "ope_pedimento",
                column: "numero_pedimento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ope_permiso_partida_id_partida",
                schema: "sidapa",
                table: "ope_permiso_partida",
                column: "id_partida");

            migrationBuilder.CreateIndex(
                name: "IX_ope_permiso_partida_id_regulacion",
                schema: "sidapa",
                table: "ope_permiso_partida",
                column: "id_regulacion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_producto_id_cliente",
                schema: "sidapa",
                table: "ope_producto",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ope_producto_id_fraccion",
                schema: "sidapa",
                table: "ope_producto",
                column: "id_fraccion");

            migrationBuilder.CreateIndex(
                name: "IX_ope_producto_id_glosador",
                schema: "sidapa",
                table: "ope_producto",
                column: "id_glosador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_proveedor_clave_pais",
                schema: "sidapa",
                table: "ope_proveedor",
                column: "clave_pais");

            migrationBuilder.CreateIndex(
                name: "IX_ope_referencia_clave_aduana",
                schema: "sidapa",
                table: "ope_referencia",
                column: "clave_aduana");

            migrationBuilder.CreateIndex(
                name: "IX_ope_referencia_id_capturador",
                schema: "sidapa",
                table: "ope_referencia",
                column: "id_capturador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_referencia_id_cliente",
                schema: "sidapa",
                table: "ope_referencia",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ope_referencia_id_estatus",
                schema: "sidapa",
                table: "ope_referencia",
                column: "id_estatus");

            migrationBuilder.CreateIndex(
                name: "IX_ope_referencia_tipo_operacion",
                schema: "sidapa",
                table: "ope_referencia",
                column: "tipo_operacion");

            migrationBuilder.CreateIndex(
                name: "uq_ope_referencia_1",
                schema: "sidapa",
                table: "ope_referencia",
                column: "numero_referencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ope_renglon_factura_clave_pais_origen",
                schema: "sidapa",
                table: "ope_renglon_factura",
                column: "clave_pais_origen");

            migrationBuilder.CreateIndex(
                name: "IX_ope_renglon_factura_clave_unidad",
                schema: "sidapa",
                table: "ope_renglon_factura",
                column: "clave_unidad");

            migrationBuilder.CreateIndex(
                name: "IX_ope_renglon_factura_id_factura",
                schema: "sidapa",
                table: "ope_renglon_factura",
                column: "id_factura");

            migrationBuilder.CreateIndex(
                name: "IX_ope_renglon_factura_id_producto",
                schema: "sidapa",
                table: "ope_renglon_factura",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_ope_solicitud_documento_id_capturador",
                schema: "sidapa",
                table: "ope_solicitud_documento",
                column: "id_capturador");

            migrationBuilder.CreateIndex(
                name: "IX_ope_solicitud_documento_id_documento_respuesta",
                schema: "sidapa",
                table: "ope_solicitud_documento",
                column: "id_documento_respuesta");

            migrationBuilder.CreateIndex(
                name: "IX_ope_solicitud_documento_id_referencia",
                schema: "sidapa",
                table: "ope_solicitud_documento",
                column: "id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_ope_solicitud_documento_id_tipo_documento",
                schema: "sidapa",
                table: "ope_solicitud_documento",
                column: "id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_transporte_pedimento_clave_pais",
                schema: "sidapa",
                table: "ope_transporte_pedimento",
                column: "clave_pais");

            migrationBuilder.CreateIndex(
                name: "IX_ope_transporte_pedimento_id_pedimento",
                schema: "sidapa",
                table: "ope_transporte_pedimento",
                column: "id_pedimento");

            migrationBuilder.CreateIndex(
                name: "IX_ope_usuario_id_cliente",
                schema: "sidapa",
                table: "ope_usuario",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ope_usuario_id_rol",
                schema: "sidapa",
                table: "ope_usuario",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "uq_ope_usuario_1",
                schema: "sidapa",
                table: "ope_usuario",
                column: "correo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cat_consecutivo_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_division_sustancia_peligrosa",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_documento_requerido",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_moneda_pais",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_parametro",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_recinto_fiscalizado",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_rfe_operador",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_tipo_cambio",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_anotacion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_archivo_validacion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_bitacora_estatus",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_contenedor",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_contribucion_partida",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_contribucion_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_guia",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_identificador_partida",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_identificador_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_notificacion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_permiso_partida",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_renglon_factura",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_solicitud_documento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_transporte_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_clase_sustancia_peligrosa",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_rfe",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_tipo_contenedor",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_contribucion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_forma_pago",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_tipo_tasa",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_identificador",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_partida",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_regulacion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_factura",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_producto",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_metodo_valoracion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_dependencia",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_moneda",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_documento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_proveedor",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_incoterm",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_fraccion_arancelaria",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_destino_mercancia",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_clave_pedimento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_regimen",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_medio_transporte",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_agente_aduanal",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_referencia",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_tipo_documento",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_pais",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_unidad_medida",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_aduana_seccion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_usuario",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_estatus",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_tipo_operacion",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "ope_cliente",
                schema: "sidapa");

            migrationBuilder.DropTable(
                name: "cat_rol",
                schema: "sidapa");
        }
    }
}
