
--EXEC SPMantenimientoRutas null,'Servicentro La Tica en la Lima de Cartago - McDonalds en las Ruinas de Cartago - Trova Servicentros', 1,'1';
--EXEC SPMantenimientoRutas null,'Trova Servicentro Oreamuno - Trova Servicentro Desamparados - Kratos Apertura(Servicentro en Paseo Metropoli)', 1,'1';
--EXEC SPMantenimientoRutas null,'Lemaysa en Barrio Cuba - Promociones Turisticas el Tropico en Tibas', 1,'1';
--EXEC SPMantenimientoRutas null,'Burguer King en Tres Rios - Kratos Apertura(Servicentro en Paseo Metropoli)', 1,'1';

--select * from  Rutas
--select * from  Clientes

CREATE PROCEDURE [dbo].[SPMantenimientoRutas]
(
	@RutaCode	varchar(5)	,
	@Ruta		varchar(100),
	@RutaStatus bit			,
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nueva provincia
    BEGIN
		IF EXISTS (SELECT 1 FROM Rutas WHERE Ruta = @Ruta)
        BEGIN
            SET @accion = 'La zona "' + @Ruta + '" ya existe.';
			print @accion
        END
		else 
		begin

			declare @codnuevo varchar(5), @codmax varchar(5)
			set @codmax = (select max(RutaCode) from Rutas)
			set @codmax = isnull(@codmax,'C0000')
			set @codnuevo = 'C'+RIGHT(RIGHT(@codmax,4)+10001,4)

			INSERT INTO Rutas 
			( 
			 RutaCode	, 
			 Ruta		,
			 RutaStatus
			)
			VALUES 
			(
			@codnuevo	,  
			@Ruta		,
			@RutaStatus	
			);
	
			SET @accion = 'Se generó la ruta '+@Ruta;
			print @accion;
		end
    END
END;