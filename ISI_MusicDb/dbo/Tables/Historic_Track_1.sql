CREATE TABLE [dbo].[Historic_Track] (
    [historic_id]    INT IDENTITY (1, 1) NOT NULL,
    [date]           INT NOT NULL,
    [Userid_user]    INT NOT NULL,
    [Trackid_track2] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([historic_id] ASC),
    CONSTRAINT [FKHistoric_T301733] FOREIGN KEY ([Userid_user]) REFERENCES [dbo].[User] ([id_user]),
    CONSTRAINT [FKHistoric_T30421] FOREIGN KEY ([Trackid_track2]) REFERENCES [dbo].[Track] ([id_track])
);

