-- ================================================
CREATE PROCEDURE [dbo].[sp_InsertRule]
	@Header nchar(20),
	@ID int out
AS
	INSERT INTO Rules (Header)
	VALUES (@Header)

	SET @ID=SCOPE_IDENTITY()
GO


