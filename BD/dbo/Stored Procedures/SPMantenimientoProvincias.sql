

--EXEC SPMantenimientoProvincias null,null,'San José','1';
--EXEC SPMantenimientoProvincias null,null,'Cartago','1';
--EXEC SPMantenimientoProvincias null,null,'Heredia','1';
--EXEC SPMantenimientoProvincias null,null,'Guanacaste','1';
--EXEC SPMantenimientoProvincias null,null,'Limón','1';
--EXEC SPMantenimientoProvincias null,null,'Puntarenas','1';
--EXEC SPMantenimientoProvincias null,null,'Alajuela','1';



--select * from  Provincia

CREATE PROCEDURE [dbo].[SPMantenimientoProvincias]
(
    @ProvinciaID		INT			,
    @ProvinciaCode		VARCHAR(5)			,
    @ProvinciaName		VARCHAR(100),
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nueva provincia
    BEGIN
	
		declare @codnuevo varchar(5), @codmax varchar(5)
		set @codmax = (select max(ProvinciaCode) from Provincia)
		set @codmax = isnull(@codmax,'P0000')
		set @codnuevo = 'P'+RIGHT(RIGHT(@codmax,4)+10001,4)

        INSERT INTO Provincia 
		( 
		 ProvinciaCode	, 
		 ProvinciaName
		)
        VALUES 
		(
			@codnuevo		,  
			@ProvinciaName
		);

        SET @accion = 'Se generó la provincia '+@ProvinciaName;
		print @accion;
    END
END;