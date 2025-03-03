CREATE PROCEDURE [dbo].[sp_GenerarClaseCSharp]
    @NombreTabla NVARCHAR(128)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX) = ''
    DECLARE @NombreColumna NVARCHAR(128)
    DECLARE @TipoColumna NVARCHAR(128)
    DECLARE @EsNullable BIT
    DECLARE @IsPrimaryKey BIT

    -- Iniciar la clase pública
    SET @sql = 'public class ' + @NombreTabla + ' {' + CHAR(13) + CHAR(10)

    -- Cursor para obtener las columnas, tipos de datos y si son claves primarias
    DECLARE columnCursor CURSOR FOR
    SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, 
           CASE 
               WHEN COLUMN_NAME = 'Id_Correo' THEN 1 
               ELSE 0 
           END AS IsPrimaryKey  -- Suponiendo que 'Id_Correo' es la clave primaria (ajustar si es necesario)
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = @NombreTabla

    OPEN columnCursor
    FETCH NEXT FROM columnCursor INTO @NombreColumna, @TipoColumna, @EsNullable, @IsPrimaryKey

    -- Procesar cada columna
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Convertir el valor de 'IS_NULLABLE' de 'YES'/'NO' a 1/0 para el tipo BIT
        SET @EsNullable = CASE WHEN @EsNullable = 'YES' THEN 1 ELSE 0 END

        -- Generar la propiedad C# para cada columna
        SET @sql = @sql + '    ' + 
                   CASE WHEN @IsPrimaryKey = 1 THEN '[Key]' ELSE '' END + CHAR(13) + CHAR(10) + 
                   '    public ' + 
                   CASE 
                        WHEN @TipoColumna='int' THEN 'int'
                        WHEN @TipoColumna='bigint' THEN 'long'
                        WHEN @TipoColumna='smallint' THEN 'short'
                        WHEN @TipoColumna='tinyint' THEN 'byte'
                        WHEN @TipoColumna='bit' THEN 'bool'
                        WHEN @TipoColumna='float' THEN 'double'
                        WHEN @TipoColumna='real' THEN 'float'
                        WHEN @TipoColumna='decimal' THEN 'decimal'
                        WHEN @TipoColumna='numeric' THEN 'decimal'
                        WHEN @TipoColumna='money' THEN 'decimal'
                        WHEN @TipoColumna='smallmoney' THEN 'decimal'
                        WHEN @TipoColumna='datetime' THEN 'DateTime'
                        WHEN @TipoColumna='smalldatetime' THEN 'DateTime'
                        WHEN @TipoColumna='date' THEN 'DateTime'
                        WHEN @TipoColumna='time' THEN 'TimeSpan'
                        WHEN @TipoColumna='char' THEN 'string'
                        WHEN @TipoColumna='varchar' THEN 'string'
                        WHEN @TipoColumna='text' THEN 'string'
                        WHEN @TipoColumna='nchar' THEN 'string'
                        WHEN @TipoColumna='nvarchar' THEN 'string'
                        WHEN @TipoColumna='ntext' THEN 'string'
                        WHEN @TipoColumna='binary' THEN 'byte[]'
                        WHEN @TipoColumna='varbinary' THEN 'byte[]'
                        WHEN @TipoColumna='image' THEN 'byte[]'
                        WHEN @TipoColumna='uniqueidentifier' THEN 'Guid'
                        ELSE 'string' -- Default case for other types
                   END + 
                   ' ' + @NombreColumna + 
                   CASE WHEN @EsNullable = 1 THEN '?' ELSE '' END + ' { get; set; }' + CHAR(13) + CHAR(10)
        
        -- Si es una columna con clave foránea, agregar el comentario de relación
        IF @NombreColumna = 'EmpleadoId'  -- Aquí identificamos las relaciones, por ejemplo, si 'EmpleadoId' es una clave foránea
        BEGIN
            SET @sql = @sql + '    // Relación con Empleado' + CHAR(13) + CHAR(10)
            SET @sql = @sql + '    public Empleado Empleado { get; set; }' + CHAR(13) + CHAR(10)
        END

        FETCH NEXT FROM columnCursor INTO @NombreColumna, @TipoColumna, @EsNullable, @IsPrimaryKey
    END

    CLOSE columnCursor
    DEALLOCATE columnCursor

    -- Cerrar la clase
    SET @sql = @sql + '}'

    -- Devolver la clase generada
    SELECT @sql AS ClaseCSharp

    PRINT @sql
END