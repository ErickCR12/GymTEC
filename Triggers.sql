USE [gymTEC_DB]

GO
CREATE TRIGGER DefaultSpasTrigger
ON SUCURSAL
AFTER INSERT
AS
	DECLARE @nuevaSucursal int
	SELECT @nuevaSucursal = id FROM INSERTED

	INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento) VALUES (@nuevaSucursal, 1)
	INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento) VALUES (@nuevaSucursal, 2)
	INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento) VALUES (@nuevaSucursal, 3)
	INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento) VALUES (@nuevaSucursal, 4)
GO

GO
CREATE TRIGGER DefaultServicesTrigger
ON SUCURSAL
AFTER INSERT
AS
	DECLARE @nuevaSucursal int
	SELECT @nuevaSucursal = id FROM INSERTED

	INSERT INTO SUCURSAL_SERVICIO(id_sucursal, id_servicio) VALUES (@nuevaSucursal, 1)
	INSERT INTO SUCURSAL_SERVICIO(id_sucursal, id_servicio) VALUES (@nuevaSucursal, 2)
	INSERT INTO SUCURSAL_SERVICIO(id_sucursal, id_servicio) VALUES (@nuevaSucursal, 3)
	INSERT INTO SUCURSAL_SERVICIO(id_sucursal, id_servicio) VALUES (@nuevaSucursal, 4)
	INSERT INTO SUCURSAL_SERVICIO(id_sucursal, id_servicio) VALUES (@nuevaSucursal, 5)
GO

GO
CREATE TRIGGER DeleteDefaultServicesTrigger
ON SUCURSAL
INSTEAD OF DELETE
AS
	DECLARE @sucursal int
	SELECT @sucursal = id FROM DELETED

	DELETE FROM SUCURSAL_TRATAMIENTO
	WHERE id_sucursal = @sucursal

	DELETE FROM SUCURSAL_SERVICIO
	WHERE id_sucursal = @sucursal

	DELETE FROM SUCURSAL
	WHERE id = @sucursal
GO

	