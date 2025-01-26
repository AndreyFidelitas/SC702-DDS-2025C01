
CREATE PROCEDURE SPListaProvincias 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		p.ProvinciaID	 [Provincia ID],
      	p.ProvinciaCode	 [Provincia  Code],
      	p.ProvinciaName	 [Provincia]
	FROM	
		Provincia p with(nolock)

END