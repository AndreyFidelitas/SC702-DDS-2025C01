CREATE PROCEDURE [dbo].[SPActualizarToken]
(
    @UsuarioCode VARCHAR(5),
    @token VARCHAR(255),
    @Mensaje NVARCHAR(255) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuarios
    SET token = @token
    WHERE UsuarioCode = @UsuarioCode;

    IF (@@ROWCOUNT > 0)
        SET @Mensaje = 'Token actualizado correctamente.'
    ELSE
        SET @Mensaje = 'No se encontró el usuario o el token no se actualizó.'
END