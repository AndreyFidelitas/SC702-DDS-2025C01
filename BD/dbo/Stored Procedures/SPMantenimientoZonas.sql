
-- Crear el procedimiento almacenado

--exec SPMantenimientoZonas 1,Z0001,'Planta TEST1',1,1;
--exec SPMantenimientoZonas 1,Z0001,'Planta TEST',0,2;

--select * from Zonas

CREATE PROCEDURE [dbo].[SPMantenimientoZonas]
(
    @ProvinciaID INT ,
    @ZonasCode VARCHAR(5) = NULL,
    @ZonasName VARCHAR(100) = NULL,
	@ZonasStatus bit, 
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nueva zona
    BEGIN
		IF EXISTS (SELECT 1 FROM Zonas WHERE ZonasName = @ZonasName)
        BEGIN
            SET @accion = 'La zona "' + @ZonasName + '" ya existe.';
			print @accion
        END
		else 
		begin
			DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
			SET @codmax = (SELECT MAX(ZonasCode) FROM Zonas);
			SET @codmax = ISNULL(@codmax, 'Z0000');
			SET @codnuevo = 'Z' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

			INSERT INTO Zonas 
			(
				ProvinciaID		,
				ZonasCode		,	
				ZonasName		, 
				ZonasCreacion	, 
				ZonasEstado
			)
			VALUES 
			(
				@ProvinciaID	, 
				@codnuevo		, 
				@ZonasName		, 
				GETDATE()		,
				@ZonasStatus	
			);

			SET @accion = 'Se generó el código de zona: ' + @codnuevo;
			print @accion
		end
		--*******************************************************************
    END
    ELSE IF (@accion = '2') -- Actualizar zona existente
    BEGIN
		--*******************************************************************
		-- Validacion para verificar si existe la Zona
        IF EXISTS (SELECT 1 FROM Zonas WHERE ZonasCode = @ZonasCode)
        BEGIN
            	UPDATE z
				SET 
					z.ProvinciaID	= @ProvinciaID	,
					z.ZonasName		= @ZonasName	,
					z.ZonasEstado	= @ZonasStatus	,
					z.ZonasUpdate	= GETDATE()
				from 
					Zonas z with(nolock)
				WHERE 
					z.ZonasCode = @ZonasCode;

				SET @accion = 'Se modificó la zona : ' + @ZonasName;
				print @accion
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró la zona: ' + @ZonasName +', codigo:'+@ZonasCode;
			print @accion
        END
		--*******************************************************************
    END
    ELSE IF (@accion = '3') -- Eliminar zona
    BEGIN
		--*******************************************************************
		-- Validacion para verificar si existe la Zona
		IF EXISTS (SELECT 1 FROM Zonas WHERE ZonasCode = @ZonasCode)
        BEGIN
			UPDATE z
			SET 
			    z.ProvinciaID	= @ProvinciaID	,
				z.ZonasEstado	= 0	,
			    z.ZonasDelete	= GETDATE()
			from 
				Zonas z with(nolock)
			WHERE 
				z.ZonasCode = @ZonasCode;

			SET @accion = 'Se eliminó la zona : ' + @ZonasName;
			print @accion
		END
        ELSE
         BEGIN
            SET @accion = 'No se encontró la zona: ' + @ZonasName +', codigo:'+@ZonasCode;
			print @accion
        END
		--*******************************************************************
	END
END