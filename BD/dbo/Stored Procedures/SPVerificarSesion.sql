CREATE PROCEDURE [dbo].[SPVerificarSesion]
    @UsuarioCode VARCHAR(50),
    @token VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 
        FROM Usuarios 
        WHERE UsuarioCode = @UsuarioCode 
        AND token = @token
        AND UsuarioEstado = 1
    )
    BEGIN
        SELECT 1 AS SesionValida
    END
    ELSE
    BEGIN
        SELECT 0 AS SesionValida
    END
END 