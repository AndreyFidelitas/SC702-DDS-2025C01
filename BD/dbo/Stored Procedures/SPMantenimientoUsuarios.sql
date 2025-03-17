
-- Ejemplo de ejecución:
 --EXEC SPMantenimientoUsuarios null,305100255, 'Daniel', 'Rojas', 'Drojas', 'password123', 'token123', 1, 1, '1';
 --EXEC SPMantenimientoUsuarios null,305160774, 'Andrey', 'Sanchez', 'Asanchez', 'password123', 'token123', 1, 1, '1';
 --EXEC SPMantenimientoUsuarios null,118240183, 'Clifford', 'Garos', 'Cgaros', 'password123', 'token123', 1, 1, '1';
 --EXEC SPMantenimientoUsuarios null,202850639, 'Pedro', 'Perez', 'Pperez', 'password123', 'token123', 1, 2, '1';
 --EXEC SPMantenimientoUsuarios null,102650551, 'Ramiro', 'Ramirez', 'Rramirez', 'password123', 'token123', 1, 3, '1';
 --EXEC SPMantenimientoUsuarios null,119170739, 'Pablo', 'Mendez', 'Pmendez', 'password123', 'token123', 1, 3, '1';
 --EXEC SPMantenimientoUsuarios null,101781004, 'Juan', 'Guzman', 'Jguzman', 'password123', 'token123', 1, 3, '1';
 --EXEC SPMantenimientoUsuarios null,102060452, 'Jorge', 'Navarro', 'Jnavarro', 'password123', 'token123', 1, 3, '1';
 --EXEC SPMantenimientoUsuarios null,206190454, 'Bryan', 'Mata', 'Bmata', 'password123', 'token123', 1, 3, '1';
 --EXEC SPMantenimientoUsuarios null,501140240, 'Jesus', 'Arce', 'Jarce', 'password123', 'token123', 1, 3, '1';

--Select * from Usuarios

--ALTER TABLE Usuarios 
--ALTER COLUMN Cedula BIGINT;

CREATE PROCEDURE [dbo].[SPMantenimientoUsuarios]
(
    @UsuarioCode VARCHAR(5),        -- Código del usuario
    @Cedula	int,					-- Cedula del Empleado
	@UsuarioName VARCHAR(100),      -- Nombre del usuario
    @UsuarioApellidos VARCHAR(100), -- Apellidos del usuario
    @UsuarioUserName VARCHAR(100),  -- Nombre de usuario
    @Password VARCHAR(100),         -- Contraseña
    @token VARCHAR(255),            -- Token
    @RoleID INT,                    -- ID del rol
    @UsuarioEstado BIT,             -- Estado del usuario (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nuevo usuario
    BEGIN
        IF EXISTS (SELECT 1 FROM Usuarios WHERE UsuarioUserName = @UsuarioUserName)
        BEGIN
            SET @accion = 'El usuario "' + @UsuarioUserName + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
            SET @codmax = (SELECT MAX(UsuarioCode) FROM Usuarios);
            SET @codmax = ISNULL(@codmax, 'U0000');
            SET @codnuevo = 'U' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

            INSERT INTO Usuarios
            (
                UsuarioCode,
                Cedula,
				UsuarioName,
                UsuarioApellidos,
                UsuarioUserName,
                Password,
                token,
                RoleID,
                UsuarioCreacion,
                UsuarioEstado
            )
            VALUES
            (
                @codnuevo,
				@Cedula,
                @UsuarioName,
                @UsuarioApellidos,
                @UsuarioUserName,
                @Password,
                null,
                @RoleID,
                GETDATE(),
                @UsuarioEstado
            );

            SET @accion = 'Se generó el código del usuario: ' + @codnuevo;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar usuario existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Usuarios WHERE UsuarioCode = @UsuarioCode)
        BEGIN
            UPDATE u
            SET 
                u.UsuarioName = @UsuarioName,
                u.UsuarioApellidos	= @UsuarioApellidos,
                u.UsuarioUserName	= @UsuarioUserName,
                u.Password			= @Password,
                u.token				= @token,
                u.RoleID			= @RoleID,
                u.UsuarioEstado		= @UsuarioEstado,
                u.UsuarioUpdate		= GETDATE()
            FROM 
                Usuarios u
            WHERE 
                u.UsuarioCode	=	@UsuarioCode or 
				u.Cedula		=	@Cedula;

            SET @accion = 'Se modificó el usuario: ' + @UsuarioName + ' ' + @UsuarioApellidos;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el usuario: ' + @UsuarioName + ' ' + @UsuarioApellidos + ', código: ' + @UsuarioCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar usuario (marcar como inactivo)
    BEGIN
        IF EXISTS (SELECT 1 FROM Usuarios WHERE UsuarioCode = @UsuarioCode)
        BEGIN
            UPDATE u
            SET 
                u.UsuarioEstado = 0,
                u.UsuarioDelete = GETDATE()
            FROM 
                Usuarios u
            WHERE 
                u.UsuarioCode	=	@UsuarioCode or 
				u.Cedula		=	@Cedula;

            SET @accion = 'Se eliminó el usuario: ' + @UsuarioName + ' ' + @UsuarioApellidos;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el usuario: ' + @UsuarioName + ' ' + @UsuarioApellidos + ', código: ' + @UsuarioCode;
            PRINT @accion;
        END
    END
END