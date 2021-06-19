USE [gymTEC_DB]

GO
CREATE VIEW PagoMensual AS
SELECT id_sucursal, numero_cedula, nombre, apellido1, apellido2, salario
FROM EMPLEADO
GO

GO
CREATE VIEW PagoPorClase AS
SELECT E.id_sucursal, numero_cedula, nombre, apellido1, apellido2, COUNT(C.id) AS cantidadClases, COUNT(C.id)*salario AS monto
FROM (EMPLEADO AS E JOIN CLASE AS C ON numero_cedula = cedula_instructor)	
GROUP BY E.id_sucursal, numero_cedula, nombre, apellido1, apellido2, salario
GO

GO
CREATE VIEW PagoPorHoras AS
SELECT E.id_sucursal, numero_cedula, nombre, apellido1, apellido2, SUM(DATEDIFF(HH, C.hora_inicio, C.hora_fin)) AS horasTrabajadas, SUM(DATEDIFF(HH, C.hora_inicio, C.hora_fin))*salario AS monto
FROM (EMPLEADO AS E JOIN CLASE AS C ON numero_cedula = cedula_instructor)	
GROUP BY E.id_sucursal, numero_cedula, nombre, apellido1, apellido2, salario
GO

GO
CREATE VIEW InfoClases AS
SELECT C.id as clase_id, S.id AS sucursal_id, SER.id AS servicio_id, SER.nombre AS nombre_servicio, C.fecha, C.hora_inicio, C.hora_fin, E.numero_cedula, E.nombre AS nombre_instructor, E.apellido1, E.apellido2, C.capacidad-COUNT(id_clase) AS cupos_disponibles
FROM ((((CLASE AS C JOIN EMPLEADO AS E ON cedula_instructor = numero_cedula)
		 JOIN SUCURSAL AS S ON C.id_sucursal = S.id)
		 JOIN SERVICIO AS SER ON C.id_servicio = SER.id)
		 LEFT JOIN CLASE_CLIENTE ON C.id = id_clase)
GROUP BY C.id, S.id, SER.id, SER.nombre, C.fecha, C.hora_inicio, C.hora_fin, E.numero_cedula, E.nombre, E.apellido1, E.apellido2, C.capacidad
GO