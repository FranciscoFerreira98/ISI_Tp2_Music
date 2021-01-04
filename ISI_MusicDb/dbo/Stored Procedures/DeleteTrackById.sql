CREATE PROCEDURE [dbo].[DeleteTrackById]
	@Id int
AS
	DELETE FROM Track 
	WHERE id_track = @Id
RETURN 0