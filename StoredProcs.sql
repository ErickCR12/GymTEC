USE[gymTEC_DB]


-----------------------------------GESTION DE SUCURSALES-----------------------------


GO
CREATE PROCEDURE CreateUpdateDelete_Gym 
(
	@id INT = 0,
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
	@id_admin DECIMAL = -1,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO SUCURSAL
							   (nombre, 
								capacidad,
								provincia, 
								canton, 
								distrito, 
								hora_apertura, 
								hora_cierre, 
								fecha_apertura, 
								estado_spa, 
								estado_tienda)
			VALUES			   (@nombre, 
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
            SET	nombre = @nombre,
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

			UPDATE ADMINISTRADOR_SUCURSAL
			SET id_admin = @id_admin
			WHERE id_sucursal = @id

        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
			DELETE FROM ADMINISTRADOR_SUCURSAL
			WHERE id_sucursal = @id

            DELETE FROM SUCURSAL  
            WHERE  id = @id 
			
			
        END  
  END    
GO

----------------------GESTION DE TRATAMIENTOS DE SPA------------------------------


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
GO


----------------------GESTION DE SERVICIOS------------------------------


GO
CREATE PROCEDURE CreateUpdateDelete_Service
(
	@id INT = 0,
	@nombre VARCHAR(50) = '',
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO SERVICIO(nombre)
			VALUES (@nombre)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE SERVICIO  
            SET	nombre = @nombre
            WHERE  id = @id
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM SERVICIO  
            WHERE  id = @id  
        END  
  END    
GO


--------------------GESTION DE TIPOS DE PLANILLA-----------------------------------------

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
GO

---------------------------------GESTION DE PUESTOS-----------------------------------------

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
GO

-----------------------------------GESTION DE CLASES-----------------------------

GO
CREATE PROCEDURE CreateUpdateDelete_Class
(
	@id INT = 0,
	@id_sucursal INT = 0,
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
							    id_sucursal,
								cedula_instructor,
								capacidad, 
								hora_inicio, 
								hora_fin, 
								fecha, 
								es_grupal)
			VALUES			   (@id_servicio,
								@id_sucursal,
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
GO


--------------------GESTION DE TIPOS DE EQUIPO-----------------------------------------

GO
CREATE PROCEDURE CreateUpdateDelete_EquipmentType
(
	@id INT = 0,
	@nombre VARCHAR(50) = '',
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO TIPO_EQUIPO(nombre)
			VALUES (@nombre)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE TIPO_EQUIPO  
            SET	nombre = @nombre
            WHERE  id = @id
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM TIPO_EQUIPO  
            WHERE  id = @id  
        END  
  END    
GO

-------------------------GESTION DE MAQUINAS----------------------------------

GO
CREATE PROCEDURE CreateUpdateDelete_Machine
(
	@numero_serie DECIMAL = 0,
	@tipo_equipo INT = 0,
	@marca VARCHAR(20) = '',
	@costo DECIMAL = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO MAQUINA(numero_serie, tipo_equipo, marca, costo)
			VALUES (@numero_serie, @tipo_equipo, @marca, @costo)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE MAQUINA  
            SET	tipo_equipo = @tipo_equipo, marca = @marca, costo = @costo
            WHERE  numero_serie = @numero_serie
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM MAQUINA  
            WHERE  numero_serie = @numero_serie  
        END  
  END    
GO

  EXEC CreateUpdateDelete_Machine @numero_serie = 411254, @tipo_equipo = 2, @marca = 'Adidas', @costo = 89000, @StatementType = 'INSERT';


--------------------GESTION DE PRODUCTOS-----------------------------------------

GO
CREATE PROCEDURE CreateUpdateDelete_Product
(
	@codigo_barras DECIMAL = 0,
	@nombre VARCHAR(20) = '',
	@descripcion VARCHAR(50) = '',
	@costo DECIMAL = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO PRODUCTO(codigo_barras, nombre, descripcion, costo)
			VALUES (@codigo_barras, @nombre, @descripcion, @costo)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE PRODUCTO  
            SET	nombre = @nombre, descripcion = @descripcion, costo = @costo
            WHERE  codigo_barras = @codigo_barras
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM PRODUCTO  
            WHERE  codigo_barras = @codigo_barras 
        END  
  END    
GO

EXEC CreateUpdateDelete_Product @codigo_barras = 90992942, @descripcion = 'Barra 300kcal sin azucar', @nombre = 'Barra energetica', @costo = 1300, @StatementType = 'INSERT';




-----------------------------------GESTION DE EMPLEADOS-----------------------------


GO
CREATE PROCEDURE CreateUpdateDelete_Employee
(
	@numero_cedula DECIMAL = 0,
	@id_sucursal	INT = 0,
	@id_puesto	INT = 0,
	@id_planilla	INT = 0,
	@correo VARCHAR(50) = 0,
	@contraseña VARCHAR(30) = 0,
	@nombre VARCHAR(20) = 0,
	@apellido1 VARCHAR(20) = 0,
	@apellido2 VARCHAR(20) = 0,
	@provincia VARCHAR(20) = 0,
	@canton	VARCHAR(20) = 0,
	@distrito VARCHAR(20) = 0,
	@salario DECIMAL = 0,
	@StatementType VARCHAR(20)
)

AS  
  BEGIN  
      IF @StatementType = 'INSERT'  
        BEGIN  
            INSERT INTO EMPLEADO
							   (numero_cedula,
							    id_sucursal,
								id_puesto,
								id_planilla,
								correo, 
								contraseña, 
								nombre, 
								apellido1, 
								apellido2, 
								provincia, 
								canton, 
								distrito, 
								salario)
			VALUES			   (@numero_cedula, 
								@id_sucursal, 
								@id_puesto,
								@id_planilla,
								@correo,
								@contraseña,
								@nombre,
								@apellido1,
								@apellido2,
								@provincia, 
								@canton, 
								@distrito, 
								@salario)
        END  
  
      ELSE IF @StatementType = 'UPDATE'  
        BEGIN  
            UPDATE EMPLEADO  
            SET	id_sucursal = @id_sucursal,
				id_puesto = @id_puesto,
				id_planilla = @id_planilla,
				correo = @correo,
				contraseña = @contraseña,
				nombre = @nombre,
				apellido1 = @apellido1,
				apellido2 = @apellido2,
				provincia = @provincia,
				canton = @canton, 
				distrito = @distrito, 
				salario = @salario
            WHERE  numero_cedula = @numero_cedula  
        END  
      ELSE IF @StatementType = 'DELETE'  
        BEGIN  
            DELETE FROM EMPLEADO  
            WHERE  numero_cedula = @numero_cedula
        END  
  END    
GO


-----------------------------------CONFIG GYM------------------------------------

GO
CREATE PROCEDURE SetSpaTreatmentsToGym
(
	@id_tratamiento	INT,
	@id_sucursal	INT
)

AS  
  BEGIN  
	INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento)
	VALUES (@id_sucursal, @id_tratamiento)
  END    
GO

GO
CREATE PROCEDURE SetProductsToGym
(
	@codigo_producto DECIMAL,
	@id_sucursal	 INT
)

AS  
  BEGIN  
	INSERT INTO SUCURSAL_PRODUCTO(id_sucursal, codigo_producto)
	VALUES (@id_sucursal, @codigo_producto)
  END    
GO

GO
CREATE PROCEDURE SetMachinesToGym
(
	@numero_maquina DECIMAL,
	@id_sucursal	 INT
)

AS  
  BEGIN  
	INSERT INTO SUCURSAL_MAQUINA(id_sucursal, numero_maquina)
	VALUES (@id_sucursal, @numero_maquina)
  END    
GO

GO
CREATE PROCEDURE CopyGym
(
	@idSucursalOriginal INT,
	@idSucursalNueva INT
)

AS
	BEGIN
		INSERT INTO SUCURSAL_TRATAMIENTO(id_sucursal, id_tratamiento)
		SELECT @idSucursalNueva, id_tratamiento
		FROM SUCURSAL_TRATAMIENTO
		WHERE id_sucursal = @idSucursalOriginal AND id_tratamiento > 4

		INSERT INTO SUCURSAL_PRODUCTO(id_sucursal, codigo_producto)
		SELECT @idSucursalNueva, codigo_producto
		FROM SUCURSAL_PRODUCTO
		WHERE id_sucursal = @idSucursalOriginal

		INSERT INTO CLASE(id_sucursal, id_servicio, fecha, hora_inicio, hora_fin, capacidad, es_grupal)
		SELECT @idSucursalNueva, id_servicio, fecha, hora_inicio, hora_fin, capacidad, es_grupal
		FROM CLASE
		WHERE id_sucursal = @idSucursalOriginal
	END
GO

GO
CREATE PROCEDURE CopyGymWeek
(
	@sucursal INT,
	@fechaInicioOriginal DATE,
	@fechaFinalOriginal DATE,
	@fechaInicioNueva DATE,
	@fechaFinalNueva DATE
)

AS
	BEGIN
		INSERT INTO CLASE(id_servicio, id_sucursal, cedula_instructor, fecha, hora_inicio, hora_fin, capacidad, es_grupal)
		SELECT id_servicio, id_sucursal, cedula_instructor, DATEADD(DD, DATEDIFF(DD, @fechaInicioOriginal, @fechaInicioNueva), fecha), hora_inicio, hora_fin, capacidad, es_grupal
		FROM CLASE
		WHERE id_sucursal = @sucursal AND fecha >= @fechaInicioOriginal AND	fecha <= @fechaFinalOriginal
	END
GO

GO
CREATE PROCEDURE RegisterClient
(
	@id_clase	INT,
	@id_cliente	INT
)

AS  
  BEGIN  
	INSERT INTO CLASE_CLIENTE(id_clase, cedula_cliente)
	VALUES (@id_clase, @id_cliente)
  END    
GO