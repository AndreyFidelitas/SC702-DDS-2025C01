
--exec SPMantenimientoCilindros '','Transportista2',1,'1'
--select * from TipoCilindro



CREATE PROCEDURE [dbo].[SPMantenimientoCilindros]
(
	@TipoCilindroCode varchar(5) NULL,
	@LoteLitraje varchar(10) NULL,
	@TipoCilindroStatus bit NULL,           
    @accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo cilindro
    BEGIN
        IF EXISTS (SELECT 1 FROM TipoCilindro WHERE TipoCilindroCode = @TipoCilindroCode)
        BEGIN
            SET @accion = 'El cilindro con código "' + @TipoCilindroCode + '" o nombre "' + @LoteLitraje + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
			
			declare @codnuevo varchar(5), @codmax varchar(5)
			set @codmax = (select max(TipoCilindroCode) from TipoCilindro)
			set @codmax = isnull(@codmax,'T0000')
			set @codnuevo = 'T'+RIGHT(RIGHT(@codmax,4)+10001,4)


            INSERT INTO TipoCilindro
            (
                TipoCilindroCode,
                LoteLitraje,
                TipoCilindroStatus
            )
            VALUES
            (
               @codnuevo,
                @LoteLitraje,
                @TipoCilindroStatus
            );

            SET @accion = 'Se creó el cilindro con código: ' +@codnuevo;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar cilindro existente
    BEGIN
        IF EXISTS (SELECT 1 FROM  TipoCilindro WHERE TipoCilindroCode = @TipoCilindroCode)
        BEGIN
            UPDATE TipoCilindro
            SET 
                TipoCilindroCode = @TipoCilindroCode,
                TipoCilindroStatus = @TipoCilindroStatus
            WHERE 
                TipoCilindroCode = @TipoCilindroCode;

            SET @accion = 'Se actualizó el cilindro con ID: ' + CAST(@TipoCilindroCode AS VARCHAR);
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el cilindro con ID: ' + CAST(@TipoCilindroCode AS VARCHAR);
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar cilindro (lógico)
    BEGIN
        IF EXISTS (SELECT 1 FROM TipoCilindro WHERE @TipoCilindroCode = @TipoCilindroCode)
        BEGIN

                UPDATE TipoCilindro
                SET 
                    @TipoCilindroStatus = 0
                WHERE 
                    TipoCilindroCode = @TipoCilindroCode;

                SET @accion = 'Se eliminó el cilindro con ID: ' + CAST(@TipoCilindroCode AS VARCHAR);
                PRINT @accion;
   --         END
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el cilindro con ID: ' + CAST(@TipoCilindroCode AS VARCHAR);
            PRINT @accion;
        END
    END
END