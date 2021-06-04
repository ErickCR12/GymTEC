USE[gymTEC_DB]


-----------------------------------GESTION DE SUCURSALES-----------------------------
GO
CREATE FUNCTION GetAllGyms()
RETURNS TABLE
AS
RETURN
(
	SELECT id, id_administrador, nombre, capacidad,provincia, canton, distrito, hora_apertura, hora_cierre, fecha_apertura, estado_spa, estado_tienda
	FROM SUCURSAL
);

GO
CREATE FUNCTION GetGymById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, id_administrador, nombre, capacidad,provincia, canton, distrito, hora_apertura, hora_cierre, fecha_apertura, estado_spa, estado_tienda
	FROM SUCURSAL
	WHERE id = @storedId
);



--------------------GESTION DE TRATAMIENTOS DE SPA-----------------------------------------
GO
CREATE FUNCTION GetAllSpaTreatments()
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM TRATAMIENTO_SPA
);

GO
CREATE FUNCTION GetSpaTreatmentById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM TRATAMIENTO_SPA
	WHERE id = @storedId
);

--------------------GESTION DE TIPOS DE PLANILLA-----------------------------------------
GO
CREATE FUNCTION GetAllPayrolls()
RETURNS TABLE
AS
RETURN
(
	SELECT id, descripcion, pago_horas, pago_mensual, pago_clase
	FROM TIPO_PLANILLA
);

GO
CREATE FUNCTION GetPayrollById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, descripcion, pago_horas, pago_mensual, pago_clase
	FROM TIPO_PLANILLA
	WHERE id = @storedId
);


---------------------------------GESTION DE PUESTOS-----------------------------------------
GO
CREATE FUNCTION GetAllPositions()
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM PUESTO
);

GO
CREATE FUNCTION GetPositionById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM PUESTO
	WHERE id = @storedId
);


-----------------------------------GESTION DE CLASES-----------------------------
GO
CREATE FUNCTION GetAllClasses()
RETURNS TABLE
AS
RETURN
(
	SELECT id, id_servicio, cedula_instructor,hora_inicio, hora_fin, fecha, capacidad, es_grupal
	FROM CLASE
);

GO
CREATE FUNCTION GetClassById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, id_servicio, cedula_instructor, hora_inicio, hora_fin, fecha, capacidad, es_grupal
	FROM CLASE
	WHERE id = @storedId
);



--------------------GESTION DE TIPOS DE EQUIPO-----------------------------------------
GO
CREATE FUNCTION GetAllEquipmentTypes()
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM TIPO_EQUIPO
);

GO
CREATE FUNCTION GetEquipmentTypeById(@storedId int)
RETURNS TABLE
AS
RETURN
(
	SELECT id, nombre
	FROM TIPO_EQUIPO
	WHERE id = @storedId
);

--------------------GESTION DE MÁQUINAS-----------------------------------------
GO
CREATE FUNCTION GetAllMachines()
RETURNS TABLE
AS
RETURN
(
	SELECT numero_serie, tipo_equipo, marca, costo
	FROM MAQUINA
);

GO
CREATE FUNCTION GetMachineBySerialNumber(@storedSerialNumber int)
RETURNS TABLE
AS
RETURN
(
	SELECT numero_serie, tipo_equipo, marca, costo
	FROM MAQUINA
	WHERE numero_serie = @storedSerialNumber
);


--------------------GESTION DE PRODUCTOS-----------------------------------------
GO
CREATE FUNCTION GetAllProducts()
RETURNS TABLE
AS
RETURN
(
	SELECT codigo_barras, nombre, descripcion, costo
	FROM PRODUCTO
);

GO
CREATE FUNCTION GetProductByBarCode(@storedBarCode int)
RETURNS TABLE
AS
RETURN
(
	SELECT codigo_barras, nombre, descripcion, costo
	FROM PRODUCTO
	WHERE codigo_barras = @storedBarCode
);



--------------------GESTION DE EMPLEADOS-----------------------------------------
GO
CREATE FUNCTION GetAllEmployees()
RETURNS TABLE
AS
RETURN
(
	SELECT	numero_cedula, id_sucursal, id_puesto, id_planilla, correo, contraseña,
			nombre, apellido1, apellido2, provincia, canton, distrito, salario
	FROM EMPLEADO
);

GO
CREATE FUNCTION GetEmployeeByIdCard(@storedIdCard DECIMAL)
RETURNS TABLE
AS
RETURN
(
	SELECT numero_cedula, id_sucursal, id_puesto, id_planilla, correo, contraseña,
			nombre, apellido1, apellido2, provincia, canton, distrito, salario
	FROM EMPLEADO
	WHERE numero_cedula = @storedIdCard
);
