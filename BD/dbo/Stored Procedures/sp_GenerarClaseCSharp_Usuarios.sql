
CREATE PROCEDURE [dbo].[sp_GenerarClaseCSharp_Usuarios]
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX) = ''
    DECLARE @NombreColumna NVARCHAR(128)
    DECLARE @TipoColumna NVARCHAR(128)

    SET @sql = 'public class Usuarios {' + CHAR(13) + CHAR(10)

    -- Cursor para recorrer las columnas de la tabla Usuarios
    DECLARE columnCursor CURSOR FOR
    SELECT COLUMN_NAME, DATA_TYPE
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'Usuarios'

    OPEN columnCursor
    FETCH NEXT FROM columnCursor INTO @NombreColumna, @TipoColumna

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @sql = @sql + '    public ' + 
                   CASE 
                       WHEN @TipoColumna = 'int' THEN 'int'
                       WHEN @TipoColumna = 'bigint' THEN 'long'
                       WHEN @TipoColumna = 'smallint' THEN 'short'
                       WHEN @TipoColumna = 'tinyint' THEN 'byte'
                       WHEN @TipoColumna = 'bit' THEN 'bool'
                       WHEN @TipoColumna = 'float' THEN 'double'
                       WHEN @TipoColumna = 'real' THEN 'float'
                       WHEN @TipoColumna = 'decimal' THEN 'decimal'
                       WHEN @TipoColumna = 'numeric' THEN 'decimal'
                       WHEN @TipoColumna = 'money' THEN 'decimal'
                       WHEN @TipoColumna = 'smallmoney' THEN 'decimal'
                       WHEN @TipoColumna = 'datetime' THEN 'DateTime'
                       WHEN @TipoColumna = 'smalldatetime' THEN 'DateTime'
                       WHEN @TipoColumna = 'date' THEN 'DateTime'
                       WHEN @TipoColumna = 'time' THEN 'TimeSpan'
                       WHEN @TipoColumna = 'char' THEN 'string'
                       WHEN @TipoColumna = 'varchar' THEN 'string'
                       WHEN @TipoColumna = 'text' THEN 'string'
                       WHEN @TipoColumna = 'nchar' THEN 'string'
                       WHEN @TipoColumna = 'nvarchar' THEN 'string'
                       WHEN @TipoColumna = 'ntext' THEN 'string'
                       WHEN @TipoColumna = 'binary' THEN 'byte[]'
                       WHEN @TipoColumna = 'varbinary' THEN 'byte[]'
                       WHEN @TipoColumna = 'image' THEN 'byte[]'
                       WHEN @TipoColumna = 'uniqueidentifier' THEN 'Guid'
                       ELSE 'string' -- Caso por defecto para otros tipos
                   END + 
                   ' ' + @NombreColumna + ' { get; set; }' + CHAR(13) + CHAR(10)
        FETCH NEXT FROM columnCursor INTO @NombreColumna, @TipoColumna
    END

    CLOSE columnCursor
    DEALLOCATE columnCursor

    SET @sql = @sql + '}'

    SELECT @sql AS ClaseCSharp

    PRINT @sql
END