

--exec SPMantenimientoCamiones 'C0001','test camion1','234595',,,1,1,'2';


CREATE PROCEDURE [dbo].[SPMantenimientoCamiones]
(
    @CamionCode VARCHAR(5)			,
    @CamionName VARCHAR(100)		,
	@CamionPlaca varchar(10)		,
	@CamionPesaje varchar(50)		,
    @CamionStatus BIT				,
	@CamionActivty bit				,
    @accion VARCHAR(50) OUTPUT
)
AS
BEGIN
    IF (@accion = '1') -- Insertar nuevo camión
    BEGIN
        IF EXISTS (SELECT 1 FROM Camiones WHERE CamionPlaca = @CamionPlaca)
        BEGIN
            SET @accion = 'El camión "' + @CamionName + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
            SET @codmax = (SELECT MAX(CamionCode) FROM Camiones);
            SET @codmax = ISNULL(@codmax, 'C0000');
            SET @codnuevo = 'C' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

            INSERT INTO Camiones
            (
                CamionCode,
                CamionName,
				CamionPlaca,
				CamionPesaje,
                CamionCreacion,
                CamionStatus,
				CamionActivty 
            )
            VALUES
            (
                @codnuevo,
                @CamionName,
				@CamionPlaca,
				@CamionPesaje,
                GETDATE(),
                @CamionStatus,
				@CamionActivty 
            );

            SET @accion = 'Se generó el código del camión: ' + @codnuevo;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar camión existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Camiones WHERE CamionPlaca = @CamionPlaca)
        BEGIN
            UPDATE c
            SET 
                c.CamionName	=	@CamionName		,
				c.CamionPlaca	=	@CamionPlaca	,
				c.CamionPesaje	=	@CamionPesaje	,
                c.CamionStatus	=	@CamionStatus	,
				c.CamionActivty =	@CamionActivty	,
                c.CamionUpdate	=	GETDATE()
            FROM 
                Camiones c
            WHERE 
                c.CamionCode = @CamionCode;

            SET @accion = 'Se modificó el camión: ' + @CamionName;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el camión: ' + @CamionName + ', código: ' + @CamionCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar camión
    BEGIN
        IF EXISTS (SELECT 1 FROM Camiones WHERE CamionPlaca = @CamionPlaca)
        BEGIN
            UPDATE c
            SET 
                c.CamionStatus = 0,
                c.CamionDelete = GETDATE()
            FROM 
                Camiones c
            WHERE 
                c.CamionCode = @CamionCode;

            SET @accion = 'Se eliminó el camión: ' + @CamionName;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el camión: ' + @CamionName + ', código: ' + @CamionCode;
            PRINT @accion;
        END
    END
END