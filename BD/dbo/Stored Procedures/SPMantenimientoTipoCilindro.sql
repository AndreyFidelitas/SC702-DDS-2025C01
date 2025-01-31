


--exec SPMantenimientoTipoCilindro 'M0001','100 ml',1,'2';

--SELECT * from TipoCilindro

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
            SET @accion = 'Ya existe la mediada de cilindro: ' + @LoteLitraje;
        END
        ELSE
        BEGIN
            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
            SET @codmax = (SELECT MAX(TipoCilindroCode) FROM TipoCilindro with(nolock));
            SET @codmax = ISNULL(@codmax, 'M0000');
            SET @codnuevo = 'M' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

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

            SET @accion = 'Se generó el código de la medida de cilindro: ' + @codnuevo;
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