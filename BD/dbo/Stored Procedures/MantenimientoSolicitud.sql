CREATE PROCEDURE MantenimientoSolicitud
    @Cedula INT,
    @SolicitudCode VARCHAR(5),
    @Name VARCHAR(100),
    @Apellidos VARCHAR(100),
    @SolcitudAceptada DATETIME,
    @SolcitudRechaza DATETIME,
    @SolcitudEstado BIT,
    @UsuarioID INT,
    @Resultado INT OUTPUT -- 0 si no se insertó, 1 si se insertó correctamente, 2 si ya existe
AS
BEGIN
    -- Inicializamos la variable @Resultado en 0 (No insertado)
    SET @Resultado = 0

    -- Validamos si ya existe un registro con la misma cédula y código de solicitud
    IF EXISTS (SELECT 1 FROM dbo.UsuariosSolcitud
               WHERE Cedula = @Cedula AND SolicitudCode = @SolicitudCode)
    BEGIN
        -- Si existe, asignamos 2 a @Resultado (Ya existe)
        SET @Resultado = 2
    END
    ELSE
    BEGIN
        -- Si no existe, realizamos la inserción
        INSERT INTO dbo.UsuariosSolcitud 
		(
			Cedula			,
			SolicitudCode	,
			Name			, 
			Apellidos		, 
			SolcitudAceptada, 
			SolcitudRechaza	, 
			SolcitudEstado	,
			UsuarioID
		)
        VALUES 
        (
			@Cedula			,	
			@SolicitudCode	, 
			@Name			,	
			@Apellidos		,
			null			,
			null			,
			null			,
			null
		)
        
        -- Si la inserción es exitosa, asignamos 1 a @Resultado (Insertado correctamente)
        SET @Resultado = 1
    END
END