


/*
select * from LogEventos

EXEC [dbo].[SPInsertarLogEvento]
    @UsuarioID = 11,
    @TablaAfectada = 'Roles',
    @Modulo = 'MantenimientoRoles',
    @Detalles = 'Se insertó un nuevo rol llamado Administrador',
    @accion = '1';
*/

CREATE PROCEDURE [dbo].[SPInsertarLogEvento]
(
    @UsuarioID INT,
    @TablaAfectada VARCHAR(100),
    @Modulo VARCHAR(100),
    @Detalles NVARCHAR(MAX),
	@accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
   IF (@accion = '1') -- Insertar nuevo rol
    BEGIN	
	
	SET NOCOUNT ON;

    INSERT INTO LogEventos 
	(
        UsuarioID,
        TablaAfectada,
        Modulo,
        Detalles
    )
    VALUES (
        @UsuarioID,
        @TablaAfectada,
        @Modulo,
        @Detalles
    );
    END
END