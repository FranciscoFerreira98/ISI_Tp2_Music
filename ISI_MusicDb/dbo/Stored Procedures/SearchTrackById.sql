CREATE PROCEDURE [dbo].[SearchTrackById]
	@Id int
AS
	SELECT *
	FROM Track 
	WHERE id_track LIKE  @Id 
RETURN 0