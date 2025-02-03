
-- Ejemplo de ejecución:
-- EXEC SPMantenimientoUsuarios 'U0001', 'Juan', 'Perez', 'jperez', 'password123', 'token123', 1, 1, @accion OUTPUT;

CREATE PROCEDURE [dbo].[SPMantenimientoUsuarios]
(
    @UsuarioCode VARCHAR(5),        -- Código del usuario
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
                @UsuarioName,
                @UsuarioApellidos,
                @UsuarioUserName,
                @Password,
                @token,
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
                u.UsuarioApellidos = @UsuarioApellidos,
                u.UsuarioUserName = @UsuarioUserName,
                u.Password = @Password,
                u.token = @token,
                u.RoleID = @RoleID,
                u.UsuarioEstado = @UsuarioEstado,
                u.UsuarioUpdate = GETDATE()
            FROM 
                Usuarios u
            WHERE 
                u.UsuarioCode = @UsuarioCode;

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
                u.UsuarioCode = @UsuarioCode;

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