



--exec SPMantenimientoTipoCilindro '','143 ml',1,'1';

--select * FROM TipoCilindro

CREATE PROCEDURE [dbo].[SPMantenimientoTipoCilindro]
(
    @TipoCilindroCode VARCHAR(5)	,
    @LoteLitraje VARCHAR(100)		,
	@TipoCilindroStatus	bit			,
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nuevo TipoCilindro
    BEGIN
		
		IF EXISTS (SELECT 1 FROM TipoCilindro WHERE LoteLitraje = @LoteLitraje)
        BEGIN
            SET @accion = 'Ya existe la medida de cilindro: ' + @LoteLitraje;
        END
        ELSE
        BEGIN
			declare @codnuevo varchar(5), @codmax varchar(6)
			
			set @codmax = (select max(TipoCilindroCode) from TipoCilindro)
			set @codmax = isnull(@codmax,'M0000')
			set @codnuevo = 'M'+RIGHT(RIGHT(@codmax,4)+10001,4)

            INSERT INTO TipoCilindro 
            (
                TipoCilindroCode,
                LoteLitraje		,
				TipoCilindroStatus
            )
            VALUES 
            (
                @codnuevo,
                @LoteLitraje,
				@TipoCilindroStatus
            );

			SET @accion = 'Se generó la medida'+ @LoteLitraje+'codigo:' +@codnuevo;
			print @accion
        END

    END
    ELSE IF (@accion = '2') -- Actualizar TipoCilindro existente
    BEGIN
       -- Validar si el registro existe por LoteLitraje
        IF EXISTS (SELECT 1 FROM TipoCilindro WHERE LoteLitraje = @LoteLitraje)
        BEGIN
            UPDATE TipoCilindro
            SET 
                LoteLitraje = @LoteLitraje,
				TipoCilindroStatus=@TipoCilindroStatus
			from 
				TipoCilindro t with(nolock)
            WHERE 
                 TipoCilindroCode =  @TipoCilindroCode;

            SET @accion = 'Se actualizó la: ' + @LoteLitraje;
        END
        ELSE
		IF EXISTS (SELECT 1 FROM TipoCilindro WHERE TipoCilindroCode = @TipoCilindroCode)
        BEGIN
            UPDATE TipoCilindro
            SET 
                LoteLitraje = @LoteLitraje,
				TipoCilindroStatus=@TipoCilindroStatus
			from 
				TipoCilindro t with(nolock)
            WHERE 
                 TipoCilindroCode =  @TipoCilindroCode;

            SET @accion = 'Se actualizó la: ' + @LoteLitraje;
        END
		else
        BEGIN
            SET @accion = 'No se encontró la medida de cilindro"' + @LoteLitraje + '".';
        END
    END
END