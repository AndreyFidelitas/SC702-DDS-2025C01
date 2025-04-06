CREATE PROCEDURE [dbo].[sp_ValidarUsuarioSolicitud]
    @Cedula INT,
    @SolicitudCode VARCHAR(5) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @ExisteRegistro BIT = 0;
    
    -- Verificar si ya existe un registro con la misma cédula o código de solicitud
    IF EXISTS (
        SELECT 1 
        FROM [dbo].[UsuariosSolcitud] 
        WHERE [Cedula] = @Cedula
        OR (@SolicitudCode IS NOT NULL AND [SolicitudCode] = @SolicitudCode)
    )
    BEGIN
        SET @ExisteRegistro = 1;
    END
    
    -- Retornar el resultado de la validación
    SELECT @ExisteRegistro AS ExisteRegistro;
    
    -- Opcional: Retornar los datos del registro existente si se necesita
    SELECT 
        [SolicitudID],
        [SolicitudCode],
        [Cedula],
        [Name],
        [Apellidos],
        [SolcitudAceptada],
        [SolcitudRechaza],
        [SolcitudEstado],
        [UsuarioID]
    FROM [dbo].[UsuariosSolcitud] 
    WHERE [Cedula] = @Cedula
END