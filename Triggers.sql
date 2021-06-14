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
