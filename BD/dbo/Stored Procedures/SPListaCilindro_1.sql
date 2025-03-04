
Create PROCEDURE [dbo].[SPListaCilindro]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
      TipoCilindroCode		[Codigo Cilindro],
      LoteLitraje		[Cilindro]		,
    case 
	when TipoCilindroStatus=1 then 'Activo'
	else 'Inactivo'	
	end				[Estado]
  FROM
	[dbo].[TipoCilindro] with(nolock)
END