CREATE PROCEDURE [dbo].[Procedure1]
	@param1 int = 0,
	@param2 int
AS
	Declare @IDTransazioneISBets int = 0
	create table XX(T1 int)

	SELECT * FROM XX
	RAISERROR('Cannot find transaction %i. Operation not allowed', 16, 1, @IDTransazioneISBets)
RETURN 0
