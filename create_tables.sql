CREATE TABLE SUCURSAL (
	id					INT IDENTITY(1,1) NOT NULL,
	id_administrador	DECIMAL		NOT NULL,
	nombre				VARCHAR(50) NOT NULL,
	capacidad			DECIMAL		NOT NULL,
	provincia			VARCHAR(20) NOT NULL,
	canton				VARCHAR(20) NOT NULL,
	distrito			VARCHAR(20) NOT NULL,
	hora_apertura		TIME		NOT NULL,
	hora_cierre			TIME		NOT NULL,
	fecha_apertura		DATE		NOT NULL,
	estado_spa			INT			NOT NULL,
	estado_tienda		INT			NOT NULL,
	PRIMARY KEY	(id)
);

CREATE TABLE CLASE (
	id					INT IDENTITY(1,1) NOT NULL,
	id_sucursal			INT			NOT NULL,
	id_servicio			INT			NOT NULL,
	cedula_instructor	DECIMAL		NOT NULL,
	fecha				DATE		NOT NULL,
	hora_inicio			TIME		NOT NULL,
	hora_fin			TIME		NOT NULL,
	capacidad			DECIMAL		NOT NULL,
	es_grupal			INT			NOT NULL,
	PRIMARY KEY	(id, id_servicio, cedula_instructor, 
	fecha, hora_inicio, hora_fin)
);

CREATE TABLE EMPLEADO (
	numero_cedula		DECIMAL		NOT NULL,
	id_sucursal			INT		NOT NULL,
	id_puesto			INT		NOT NULL,
	id_planilla			INT		NOT NULL,
	correo				VARCHAR(50) NOT NULL,
	contraseña			VARCHAR(30)	NOT NULL,
	nombre				VARCHAR(20) NOT NULL,
	apellido1			VARCHAR(20) NOT NULL,
	apellido2			VARCHAR(20) NOT NULL,
	provincia			VARCHAR(20) NOT NULL,
	canton				VARCHAR(20) NOT NULL,
	distrito			VARCHAR(20) NOT NULL,
	salario				DECIMAL		NOT NULL,
	PRIMARY KEY	(numero_cedula)
);

CREATE TABLE TRATAMIENTO_SPA (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(50) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE TIPO_EQUIPO (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(20) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE SERVICIO (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(20) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE PUESTO (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(40) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE TIPO_PLANILLA (
	id			 INT IDENTITY(1,1) NOT NULL,
	descripcion	 VARCHAR(50) NOT NULL,
	pago_horas	 DECIMAL	 NOT NULL,
	pago_mensual DECIMAL	 NOT NULL,
	pago_clase	 DECIMAL	 NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE MAQUINA (
	numero_serie	DECIMAL		NOT NULL,
	tipo_equipo		INT			NOT NULL,
	marca			VARCHAR(20) NOT NULL,
	costo			DECIMAL		NOT NULL,
	PRIMARY KEY (numero_serie)
);

CREATE TABLE PRODUCTO (
	codigo_barras	DECIMAL		NOT NULL,
	nombre			VARCHAR(20) NOT NULL,
	costo			DECIMAL		NOT NULL,
	descripcion		VARCHAR(50) NOT NULL,
	PRIMARY KEY (codigo_barras)
);

CREATE TABLE SUCURSAL_PRODUCTO (
	id_sucursal		INT		NOT NULL,
	codigo_producto	DECIMAL NOT NULL,
	PRIMARY KEY (id_sucursal, codigo_producto)
);

CREATE TABLE SUCURSAL_TRATAMIENTO (
	id_sucursal	INT	NOT NULL,
	id_tratamiento		INT NOT NULL,
	PRIMARY KEY (id_sucursal, id_tratamiento)
);

CREATE TABLE SUCURSAL_MAQUINA (
	id_sucursal		INT	NOT NULL,
	numero_maquina	DECIMAL NOT NULL,
	PRIMARY KEY (id_sucursal, numero_maquina)
);

CREATE TABLE SUCURSAL_SERVICIO (
	id_sucursal	INT	NOT NULL,
	id_servicio	INT NOT NULL,
	PRIMARY KEY (id_sucursal, id_servicio)
);

CREATE TABLE CLASE_CLIENTE (
	id_clase		DECIMAL	NOT NULL,
	cedula_cliente	DECIMAL NOT NULL,
	PRIMARY KEY (id_clase, cedula_cliente)
);

INSERT INTO SUCURSAL(id_administrador, nombre, capacidad,provincia, canton, distrito, hora_apertura, hora_cierre, fecha_apertura, estado_spa, estado_tienda)
VALUES (1, 'GymTEC Orosi', 50, 'Cartago', 'Paraiso', 'Orosi', '7:00 AM', '9:00 PM', '2020/05/15', 0, 0);

INSERT INTO SUCURSAL(id_administrador, nombre, capacidad,provincia, canton, distrito, hora_apertura, hora_cierre, fecha_apertura, estado_spa, estado_tienda)
VALUES (2, 'GymTEC Paraiso', 50, 'Cartago', 'Paraiso', 'Paraiso', '7:00 AM', '9:00 PM', '2020/05/15', 1, 1);