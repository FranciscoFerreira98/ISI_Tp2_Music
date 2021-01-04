CREATE PROCEDURE [dbo].[UpdateTrackById]
	@Id int,
	@Name varchar(255),
	@Album varchar(255),
	@Artist varchar(255),
	@Image varchar(255),
	@SpotifyId varchar(255),
	@SpotifyUrl varchar(255)
AS
	UPDATE Track 
	SET  
	[name] = @Name,
	album = @Album,
	artist = @Artist,
	[image] = @Image,
	spotify_id = spotify_id,
	spotify_url = spotify_url
	WHERE id_track = @Id
RETURN 0