CREATE TABLE [dbo].[Track] (
    [id_track]    INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (255) NOT NULL,
    [image]       VARCHAR (255) NOT NULL,
    [artist]      VARCHAR (255) NOT NULL,
    [album]       VARCHAR (255) NOT NULL,
    [spotify_id]  VARCHAR (255) NULL,
    [spotify_url] VARCHAR (255) NULL,
    [apple_id]    VARCHAR (255) NULL,
    [apple_url]   VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([id_track] ASC)
);

