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

GO
CREATE PROCEDURE CreateUpdateDelete_Payroll
(
	@id INT = 0,
	@descripcion VARCHAR(50) = '',
	@pago_horas DECIMAL = 0,
	@pago_mensual DECIMAL = 0,
	@pago_clase DECIMAL = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO TIPO_PLANILLA(descripcion, pago_horas, pago_mensual, pago_clase)
			VALUES (@descripcion, @pago_horas, @pago_mensual, @pago_clase)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE TIPO_PLANILLA  
            SET	descripcion = @descripcion, pago_horas = @pago_horas, pago_mensual = @pago_mensual, pago_clase = @pago_clase
            WHERE  id = @id
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM TIPO_PLANILLA  
            WHERE  id = @id  
        END  
  END    

EXEC	CreateUpdateDelete_Payroll @descripcion = 'Pago para administradores', @pago_mensual = 385000, @pago_horas = 2005, @pago_clase = 8000, @StatementType = 'INSERT';

EXEC	CreateUpdateDelete_Payroll @id = 1, @StatementType = 'DELETE';


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

GO
CREATE PROCEDURE CreateUpdateDelete_Position
(
	@id INT = 0,
	@nombre VARCHAR(50) = '',
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO PUESTO(nombre)
			VALUES (@nombre)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE PUESTO  
            SET	nombre = @nombre
            WHERE  id = @id
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM PUESTO  
            WHERE  id = @id  
        END  
  END  

EXEC	CreateUpdateDelete_Position @nombre = 'Administrador', @StatementType = 'INSERT';

SELECT * FROM dbo.GetAllPositions();

EXEC	CreateUpdateDelete_Position @id = 1, @StatementType = 'DELETE';



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

GO
CREATE PROCEDURE CreateUpdateDelete_Class
(
	@id INT = 0,
	@id_servicio DECIMAL = 0,
	@cedula_instructor DECIMAL = 0,
	@capacidad DECIMAL = 0,
	@hora_inicio TIME = '',
	@hora_fin TIME = '',
	@fecha	DATE = '',
	@es_grupal	INT = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO CLASE
							   (id_servicio, 
								cedula_instructor,
								capacidad, 
								hora_inicio, 
								hora_fin, 
								fecha, 
								es_grupal)
			VALUES			   (@id_servicio, 
								@cedula_instructor,
								@capacidad, 
								@hora_inicio, 
								@hora_fin, 
								@fecha, 
								@es_grupal)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE CLASE  
            SET	id_servicio = @id_servicio,
				cedula_instructor = @cedula_instructor,
				capacidad = @capacidad,
				hora_inicio = @hora_inicio,
				hora_fin = @hora_fin, 
				fecha = @fecha, 
				es_grupal = @es_grupal
            WHERE  id = @id  
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM CLASE  
            WHERE  id = @id  
        END  
  END    

EXEC	CreateUpdateDelete_Class @id_servicio = 2, @cedula_instructor = 305190315, @capacidad = 50, 
							@hora_inicio = '7:00 AM', @hora_fin = '9:00 PM', @fecha = '2020/05/15', 
							@es_grupal = 0, @StatementType = 'INSERT';

SELECT * FROM GetAllClasses();

EXEC	CreateUpdateDelete_Gym @id = 4, @StatementType = 'DELETE';

