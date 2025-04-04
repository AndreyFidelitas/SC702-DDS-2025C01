

CREATE PROCEDURE [dbo].[sp_ManageUsuariosSolicitud]
    @SolicitudCode VARCHAR(5) = NULL,
    @Cedula INT = NULL,
    @Name VARCHAR(100) = NULL,
    @Apellidos VARCHAR(100) = NULL,
    @SolcitudAceptada DATETIME = NULL,
    @SolcitudRechaza DATETIME = NULL,
    @SolcitudEstado BIT = NULL,
    @UsuarioCedula INT = NULL,
	@accion VARCHAR(50) OUTPUT 
AS
BEGIN
    SET NOCOUNT ON;
    
	DECLARE @UsuarioID int;

	IF (@accion = '1')
    BEGIN
        
		declare @codnuevo varchar(5), @codmax varchar(5)
		set @codmax = (select max(ClientesCode) from Clientes)
		set @codmax = isnull(@codmax,'S0000')
		set @codnuevo = 'S'+RIGHT(RIGHT(@codmax,4)+10001,4)

		


		INSERT INTO [dbo].[UsuariosSolcitud] 
		(
			SolicitudCode	, 
			Cedula			, 
			Name			,
			Apellidos		,
			SolcitudAceptada,
			SolcitudRechaza	, 
			SolcitudEstado	, 
			UsuarioID
		)
        VALUES 
		(
			@codnuevo			,	 
			@Cedula				,
			@Name				,
			@Apellidos			,
			null				, 
			null				,
			null				,
			0
		);
    
	END
    ELSE IF (@accion = '2')
    BEGIN

		-- consulta para obtener el ID de la tabla de usuarios
		SET @UsuarioID =( 
							select top 1 u.UsuarioID  
							from Usuarios u with(nolock)
							where u.Cedula= @UsuarioCedula
						)


        UPDATE [dbo].[UsuariosSolcitud]
        SET 
            Cedula				=	@Cedula				,
            Name				=	@Name				,
            Apellidos			=	@Apellidos			,
            SolcitudAceptada	=	@SolcitudAceptada	,
            SolcitudRechaza		=	@SolcitudRechaza	,
            UsuarioID			=	@UsuarioID
        WHERE
			SolicitudCode		=	@SolicitudCode	
    END
END