
--exec SPMantenimientoClientes null,3101396094,'Arcos Dorados','McDonalds','',1,'1';
--exec SPMantenimientoClientes null,3101706562,'ALIMENTOS EXCLUSIVOS BK CR, SOCIEDAD ANÓNIMA (BKCR)','Burguer King','',1,'1';
--exec SPMantenimientoClientes null,3101027122,'Servicentro La Tica Sociedad Anonima','Servicentro La Tica','',1,'1';
--exec SPMantenimientoClientes null,3101825962,'3-101-825962 S.A','TrovaServicentros','',1,'1';
--exec SPMantenimientoClientes null,3101030349,'LEMAYSA SOCIEDAD ANONIMA','Soles Barrio Cuba','',1,'1';
--exec SPMantenimientoClientes null,3102109834,'PROMOCIONES TURISTICAS EL TROPICO LIMITADA','PROMOCIONES TURISTICAS EL TROPICO LIMITADA','',1,'1';
--exec SPMantenimientoClientes null,3101487195,'KRATOS APERTURA S.A','SERVICENTRO METROPOLI','',1,'1';
--select * from Clientes


CREATE PROCEDURE [dbo].[SPMantenimientoClientes]
(
	@ClientesCode	varchar(5)			,
	@Cedula			bigint				,
	@RazonSocial	varchar(100) 		,
	@Empresa		varchar(100) 		,
	@ClientesRol	varchar(100) 		,
	@ClientesStatus bit					,
    @accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
    SET NOCOUNT ON;

	declare @RoleID as int;

    IF (@accion = '1') -- Insertar nuevo rol
    BEGIN
        IF EXISTS (SELECT 1 FROM Clientes WHERE ClientesCode = @ClientesCode OR RazonSocial = @RazonSocial)
        BEGIN
            SET @accion = 'El cliente con código "' + @ClientesCode + '" o razón social "' + @RazonSocial + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
			
			declare @codnuevo varchar(5), @codmax varchar(5)
			set @codmax = (select max(ClientesCode) from Clientes)
			set @codmax = isnull(@codmax,'C0000')
			set @codnuevo = 'R'+RIGHT(RIGHT(@codmax,4)+10001,4)


            INSERT INTO Clientes
            (
				ClientesCode		,
				Cedula				,
				RazonSocial			,
				Empresa				,
				ClientesRol			,
				ClientesCreacion	,
				ClientesUpdate		,
				ClientesDelete		,
				ClientesStatus
            )
            VALUES
            (
				@codnuevo			,
				@Cedula				,
				@RazonSocial		,
				@Empresa			,
				@ClientesRol		,
				GETDATE()			,
				null				,
				null				,
				@ClientesStatus
            );

            SET @accion = 'Se creó el cliente con código: ' +@codnuevo;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar rol existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Clientes WHERE ClientesCode = @ClientesCode)
        BEGIN


            UPDATE Clientes
            SET 
                RazonSocial		= @RazonSocial	,
                Empresa			= @Empresa		,
				ClientesRol		= @ClientesRol	,
				ClientesUpdate	= GETDATE()
            WHERE 
                ClientesCode	=	@ClientesCode or 
				Cedula			=	@Cedula	;

            SET @accion = 'Se actualizó el cliente con ID: ' + CAST(@ClientesCode AS VARCHAR);
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el cliente con ID: ' + CAST(@ClientesCode AS VARCHAR);
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar rol (lógico)
    BEGIN
        IF EXISTS (SELECT 1 FROM Clientes WHERE ClientesCode = @ClientesCode)
        BEGIN
                UPDATE Clientes
                SET 
                    ClientesStatus	= 0,
					ClientesDelete	=GETDATE()
                WHERE 
                    ClientesCode	=	@ClientesCode or 
					Cedula			=	@Cedula	;

                SET @accion = 'Se eliminó el cliente con ID: ' + CAST(@ClientesCode AS VARCHAR);
                PRINT @accion;
   --         END
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el cliente con ID: ' + CAST(@ClientesCode AS VARCHAR);
            PRINT @accion;
        END
    END
END