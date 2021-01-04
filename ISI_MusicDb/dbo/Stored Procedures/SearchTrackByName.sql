CREATE PROCEDURE [dbo].[SearchTrackByName]
	@Name varchar(255)
AS
	SELECT album,apple_url,spotify_url,artist,[image],[name]
	FROM Track 
	WHERE [name] LIKE '%' + @Name + '%'
RETURN 0