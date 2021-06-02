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

GO
CREATE PROCEDURE CreateUpdateDelete_Gym 
(
	@id INT = 0,
	@id_administrador DECIMAL = 0,
	@nombre VARCHAR(50) = 0,
	@capacidad DECIMAL = 0,
	@provincia VARCHAR(20) = 0,
	@canton	VARCHAR(20) = 0,
	@distrito VARCHAR(20) = 0,
	@hora_apertura TIME = '',
	@hora_cierre TIME = '',
	@fecha_apertura	DATE = '',
	@estado_spa	INT = 0,
	@estado_tienda	INT = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO SUCURSAL
							   (id_administrador, 
								nombre, 
								capacidad,
								provincia, 
								canton, 
								distrito, 
								hora_apertura, 
								hora_cierre, 
								fecha_apertura, 
								estado_spa, 
								estado_tienda)
			VALUES			   (@id_administrador, 
								@nombre, 
								@capacidad,
								@provincia, 
								@canton, 
								@distrito, 
								@hora_apertura, 
								@hora_cierre, 
								@fecha_apertura, 
								0, 
								0)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE SUCURSAL  
            SET	id_administrador = @id_administrador,
				nombre = @nombre,
				capacidad = @capacidad,
				provincia = @provincia,
				canton = @canton, 
				distrito = @distrito, 
				hora_apertura = @hora_apertura, 
				hora_cierre = @hora_cierre, 
				fecha_apertura = @fecha_apertura, 
				estado_spa = @estado_spa, 
				estado_tienda = @estado_tienda 
            WHERE  id = @id  
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM SUCURSAL  
            WHERE  id = @id  
        END  
  END    

EXEC	CreateUpdateDelete_Gym @id_administrador = 4, @nombre = 'GymTEC Orosi', @capacidad = 50, 
							@provincia = 'Cartago', @canton = 'Paraiso', @distrito = 'Orosi', 
							@hora_apertura = '7:00 AM', @hora_cierre = '9:00 PM', @fecha_apertura = '2020/05/15', 
							@estado_spa = 0, @estado_tienda = 0, @StatementType = 'INSERT';

EXEC	CreateUpdateDelete_Gym @id = 4, @StatementType = 'DELETE';




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

GO
CREATE PROCEDURE CreateUpdateDelete_SpaTreatment
(
	@id INT = 0,
	@nombre VARCHAR(50) = '',
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO TRATAMIENTO_SPA (nombre)
			VALUES (@nombre)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE TRATAMIENTO_SPA  
            SET	nombre = @nombre
            WHERE  id = @id
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM TRATAMIENTO_SPA  
            WHERE  id = @id  
        END  
  END    

EXEC	CreateUpdateDelete_SpaTreatment @nombre = 'Masaje de cuerpo completo', @StatementType = 'INSERT';

EXEC	CreateUpdateDelete_SpaTreatment @id = 1, @StatementType = 'DELETE';