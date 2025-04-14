
--EXEC SPMantenimientoRutas null,'Servicentro La Tica en la Lima de Cartago - McDonalds en las Ruinas de Cartago - Trova Servicentros', 1,'1';
--EXEC SPMantenimientoRutas null,'Trova Servicentro Oreamuno - Trova Servicentro Desamparados - Kratos Apertura(Servicentro en Paseo Metropoli)', 1,'1';
--EXEC SPMantenimientoRutas null,'Lemaysa en Barrio Cuba - Promociones Turisticas el Tropico en Tibas', 1,'1';
--EXEC SPMantenimientoRutas null,'Burguer King en Tres Rios - Kratos Apertura(Servicentro en Paseo Metropoli)', 1,'1';
--EXEC SPMantenimientoRutas null,'Burger King de Desamparados frente a la iglesia del barrio - Burger King de Bagaces costado este de la plaza - Starbucks de Coyol contiguo a la estación de servicio', 1,'1';
--EXEC SPMantenimientoRutas null,'KFC de Limón a 100 metros del muelle principal - Pizza Hut de Guápiles sobre la carretera principal - Taco Bell de Florencia frente a la farmacia local', 1,'1';
--EXEC SPMantenimientoRutas null,'McDonald''s de Lima contiguo al centro comercial - Papa John''s de Limón diagonal a la iglesia - Wingstop de Coyol próximo al puente principal', 1,'1';
--EXEC SPMantenimientoRutas null,'Chipotle de Coyol al costado norte de la plaza - Burger King de Florencia costado oeste del colegio - Starbucks de Lima frente al banco estatal', 1,'1';
--EXEC SPMantenimientoRutas null,'McDonald''s de Guápiles 200m norte de la terminal - KFC de Florencia en la zona comercial - Pizza Hut de Coyol a un lado de la estación de bomberos', 1,'1';
--EXEC SPMantenimientoRutas null,'Taco Bell de Desamparados 50m oeste de la biblioteca - Papa John''s de Bagaces junto a la gasolinera - Wingstop de Guápiles sobre carretera principal', 1,'1';
--EXEC SPMantenimientoRutas null,'Starbucks de Lima 150m sur de la municipalidad - Chipotle de Florencia frente al supermercado - Pizza Hut de Limón al costado este del parque central', 1,'1';
--EXEC SPMantenimientoRutas null,'KFC de Coyol contiguo a la terminal de buses - Taco Bell de Guápiles por la estación de tren - McDonald''s de Bagaces 100m sur del hospital', 1,'1';
--EXEC SPMantenimientoRutas null,'Burger King de Lima camino al aeropuerto - Burger King de Limón, 200 m este del parque - Pizza Hut de Lima, costado sur del hospital', 1,'1';
--EXEC SPMantenimientoRutas null,'Starbucks de Coyol, frente al restaurante local - Taco Bell de Guápiles, 100 m oeste de la terminal - KFC de Limón, contiguo a la tienda departamental', 1,'1';
--EXEC SPMantenimientoRutas null,'Chipotle de Florencia, diagonal a la plaza principal - McDonald''s de Lima, 50 m oeste del colegio - Burger King de Guápiles, en el centro comercial', 1,'1';
--EXEC SPMantenimientoRutas null,'Papa John''s de Bagaces, junto a la gasolinera - Wingstop de Florencia, al costado norte del parque - Pizza Hut de Coyol, sobre la calle principal', 1,'1';
--EXEC SPMantenimientoRutas null,'KFC de Lima, contiguo al banco estatal - Taco Bell de Guápiles, 200 m sur de la iglesia - Starbucks de Limón, costado este del museo', 1,'1';
--EXEC SPMantenimientoRutas null,'Chipotle de Bagaces, cerca de la zona comercial - McDonald''s de Coyol, contiguo al parque central - Burger King de Florencia, frente al mercado local', 1,'1';
--EXEC SPMantenimientoRutas null,'Starbucks de Lima, 100 m norte de la catedral - Papa John''s de Guápiles, cerca de la rotonda principal - Wingstop de Florencia, al lado de la terminal de buses', 1,'1';
--EXEC SPMantenimientoRutas null,'McDonald''s de Limón, 50 m sur del hospital - KFC de Lima, cerca de la plaza pública - Chipotle de Bagaces, a 2 cuadras del colegio', 1,'1';
--EXEC SPMantenimientoRutas null,'Papa John''s de Coyol, costado oeste de la estación de tren - Pizza Hut de Guápiles, 150 m este del parque municipal', 1,'1';
--select * from Rutas;

CREATE PROCEDURE [dbo].[SPMantenimientoRutas]
(
	@RutaCode	varchar(5)	,
	@Ruta		varchar(255),
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