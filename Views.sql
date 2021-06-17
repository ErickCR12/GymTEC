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