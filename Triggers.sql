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
CREATE TRIGGER ModifySpas
ON TRATAMIENTO_SPA
INSTEAD OF UPDATE
AS
	DECLARE @spaId int
	DECLARE @nombre VARCHAR(50)
	SELECT @spaId = id, @nombre = nombre FROM inserted

	IF @spaId > 4
		BEGIN
			UPDATE TRATAMIENTO_SPA
			SET nombre = @nombre
			WHERE id = @spaId
		END
GO

GO
CREATE TRIGGER DeleteSpas
ON TRATAMIENTO_SPA
INSTEAD OF DELETE
AS
	DECLARE @spaId int
	SELECT @spaId = id FROM deleted

	IF @spaId > 4
		BEGIN
			DECLARE @idVerificacion INT
			SELECT @idVerificacion = id_tratamiento FROM SUCURSAL_TRATAMIENTO WHERE id_tratamiento = @spaId

			IF @idVerificacion is NULL
			BEGIN
				DELETE TRATAMIENTO_SPA
				WHERE id = @spaId
			END
		END
GO

GO
CREATE TRIGGER ModifyPositions
ON PUESTO
INSTEAD OF UPDATE
AS
	DECLARE @puestoId int
	DECLARE @nombre VARCHAR(50)
	SELECT @puestoId = id, @nombre = nombre FROM inserted

	IF @puestoId > 4
		BEGIN
			UPDATE PUESTO
			SET nombre = @nombre
			WHERE id = @puestoId
		END
GO

GO
CREATE TRIGGER DeletePositions
ON PUESTO
INSTEAD OF DELETE
AS
	DECLARE @puestoId int
	SELECT @puestoId = id FROM deleted

	IF @puestoId > 4
		BEGIN
			DELETE PUESTO
			WHERE id = @puestoId
		END
GO

GO
CREATE TRIGGER ModifyService
ON SERVICIO
INSTEAD OF UPDATE
AS
	DECLARE @servicioId int
	DECLARE @nombre VARCHAR(50)
	SELECT @servicioId = id, @nombre = nombre FROM inserted

	IF @servicioId > 4
		BEGIN
			UPDATE SERVICIO
			SET nombre = @nombre
			WHERE id = @servicioId
		END
GO

GO
CREATE TRIGGER DeleteService
ON SERVICIO
INSTEAD OF DELETE
AS
	DECLARE @servicioId int
	SELECT @servicioId = id FROM deleted

	IF @servicioId > 4
		BEGIN
			DELETE SERVICIO
			WHERE id = @servicioId
		END
GO

GO
CREATE TRIGGER ModifyEquipmentTypes
ON TIPO_EQUIPO
INSTEAD OF UPDATE
AS
	DECLARE @equipoId int
	DECLARE @nombre VARCHAR(50)
	SELECT @equipoId = id, @nombre = nombre FROM inserted

	IF @equipoId > 4
		BEGIN
			UPDATE TIPO_EQUIPO
			SET nombre = @nombre
			WHERE id = @equipoId
		END
GO

GO
CREATE TRIGGER DeleteEquipmentType
ON TIPO_EQUIPO
INSTEAD OF DELETE
AS
	DECLARE @equipoId int
	SELECT @equipoId = id FROM deleted

	IF @equipoId > 4
		BEGIN
			DELETE TIPO_EQUIPO
			WHERE id = @equipoId
		END
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

	