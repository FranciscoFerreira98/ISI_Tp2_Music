CREATE PROCEDURE [dbo].[InsertTrack]
	@Name varchar(255),
	@Album varchar(255),
	@Artist varchar(255),
	@Image varchar(255),
	@SpotifyId varchar(255),
	@SpotifyUrl varchar(255)
	
AS
	INSERT INTO Track ([name],album,artist,[image],spotify_id,spotify_url)
	VALUES (@Name,@Album,@Artist,@Image,@SpotifyId,@SpotifyUrl)
RETURN 0