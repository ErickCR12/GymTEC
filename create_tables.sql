USE[gymTEC_DB]

CREATE TABLE SUCURSAL (
	id					INT IDENTITY(1,1) NOT NULL,
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

CREATE TABLE ADMINISTRADOR_SUCURSAL(
	id_admin	DECIMAL NOT NULL,
	id_sucursal	INT		NOT NULL,
	PRIMARY KEY(id_admin, id_sucursal)
)

CREATE TABLE CLASE (
	id					INT IDENTITY(1,1) NOT NULL,
	id_sucursal			INT			NOT NULL,	
	id_servicio			INT			NOT NULL,
	cedula_instructor	DECIMAL,
	fecha				DATE		NOT NULL,
	hora_inicio			TIME		NOT NULL,
	hora_fin			TIME		NOT NULL,
	capacidad			DECIMAL		NOT NULL,
	es_grupal			INT			NOT NULL,
	PRIMARY KEY	(id)
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
	nombre	VARCHAR(50) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE SERVICIO (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(50) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE PUESTO (
	id		INT IDENTITY(1,1) NOT NULL,
	nombre	VARCHAR(50) NOT NULL,
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
	marca			VARCHAR(50) NOT NULL,
	costo			DECIMAL		NOT NULL,
	PRIMARY KEY (numero_serie)
);

CREATE TABLE PRODUCTO (
	codigo_barras	DECIMAL		NOT NULL,
	nombre			VARCHAR(50) NOT NULL,
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
	id_clase		INT	NOT NULL,
	cedula_cliente	DECIMAL NOT NULL,
	PRIMARY KEY (id_clase, cedula_cliente)
);

ALTER TABLE ADMINISTRADOR_SUCURSAL
ADD CONSTRAINT ADMINISTRADOR_SUCURSAL_EMPLEADO_FK FOREIGN KEY (id_admin)
REFERENCES EMPLEADO (numero_cedula);

ALTER TABLE ADMINISTRADOR_SUCURSAL
ADD CONSTRAINT ADMINISTRADOR_SUCURSAL_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE CLASE
ADD CONSTRAINT CLASE_SERVICIO_FK FOREIGN KEY (id_servicio)
REFERENCES SERVICIO (id);

ALTER TABLE CLASE
ADD CONSTRAINT CLASE_EMPLEADO_FK FOREIGN KEY (cedula_instructor)
REFERENCES EMPLEADO (numero_cedula);

ALTER TABLE EMPLEADO
ADD CONSTRAINT EMPLEADO_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE EMPLEADO
ADD CONSTRAINT EMPLEADO_PUESTO_FK FOREIGN KEY (id_puesto)
REFERENCES PUESTO (id);

ALTER TABLE EMPLEADO
ADD CONSTRAINT EMPLEADO_PLANILLA_FK FOREIGN KEY (id_planilla)
REFERENCES TIPO_PLANILLA (id);

ALTER TABLE MAQUINA
ADD CONSTRAINT MAQUINA_TIPO_EQUIPO_FK FOREIGN KEY (tipo_equipo)
REFERENCES TIPO_EQUIPO (id);

ALTER TABLE SUCURSAL_PRODUCTO
ADD CONSTRAINT SUCURSAL_PRODUCTO_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE SUCURSAL_PRODUCTO
ADD CONSTRAINT SUCURSAL_PRODUCTO_PRODUCTO_FK FOREIGN KEY (codigo_producto)
REFERENCES PRODUCTO (codigo_barras);

ALTER TABLE SUCURSAL_TRATAMIENTO
ADD CONSTRAINT SUCURSAL_TRATAMIENTO_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE SUCURSAL_TRATAMIENTO
ADD CONSTRAINT SUCURSAL_TRATAMIENTO_TRATAMIENTO_FK FOREIGN KEY (id_tratamiento)
REFERENCES TRATAMIENTO_SPA (id);

ALTER TABLE SUCURSAL_MAQUINA
ADD CONSTRAINT SUCURSAL_MAQUINA_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE SUCURSAL_MAQUINA
ADD CONSTRAINT SUCURSAL_MAQUINA_MAQUINA_FK FOREIGN KEY (numero_maquina)
REFERENCES MAQUINA (numero_serie);

ALTER TABLE SUCURSAL_SERVICIO
ADD CONSTRAINT SUCURSAL_SERVICIO_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);

ALTER TABLE SUCURSAL_SERVICIO
ADD CONSTRAINT SUCURSAL_SERVICIO_SERVICIO_FK FOREIGN KEY (id_servicio)
REFERENCES SERVICIO (id);

ALTER TABLE CLASE_CLIENTE
ADD CONSTRAINT CLASE_CLIENTE_CLASE_FK FOREIGN KEY (id_clase)
REFERENCES CLASE (id);

ALTER TABLE CLASE
ADD CONSTRAINT CLASE_SUCURSAL_FK FOREIGN KEY (id_sucursal)
REFERENCES SUCURSAL (id);
