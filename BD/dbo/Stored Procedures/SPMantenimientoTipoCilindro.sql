--exec SPMantenimientoTipoCilindro '','100 ml','1';

--SELECT * from TipoCilindro

CREATE PROCEDURE [dbo].[SPMantenimientoTipoCilindro]
(
    @TipoCilindroCode VARCHAR(5)	,
    @TipoCilindroName VARCHAR(100)	,
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nuevo TipoCilindro
    BEGIN
		
		IF EXISTS (SELECT 1 FROM TipoCilindro WHERE TipoCilindroName = @TipoCilindroName)
        BEGIN
            SET @accion = 'Ya existe la mediada de cilindro: ' + @TipoCilindroName;
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
                TipoCilindroName
            )
            VALUES 
            (
                @codnuevo,
                @TipoCilindroName
            );

            SET @accion = 'Se generó el código de la medida de cilindro: ' + @codnuevo;
        END

    END
    ELSE IF (@accion = '2') -- Actualizar TipoCilindro existente
    BEGIN
       -- Validar si el registro existe por TipoCilindroName
        IF EXISTS (SELECT 1 FROM TipoCilindro WHERE TipoCilindroName = @TipoCilindroName)
        BEGIN
            UPDATE TipoCilindro
            SET 
                TipoCilindroName = @TipoCilindroName
			from TipoCilindro t with(nolock)
            WHERE 
                 @TipoCilindroCode =  @TipoCilindroCode;

            SET @accion = 'Se actualizó la: ' + @TipoCilindroName;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró la medida de cilindro"' + @TipoCilindroName + '".';
        END
    END
END