CREATE TABLE [dbo].[User] (
    [id_user]  INT           IDENTITY (1, 1) NOT NULL,
    [name]     VARCHAR (255) NOT NULL,
    [email]    VARCHAR (255) NOT NULL,
    [password] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [User_id_user]
    ON [dbo].[User]([id_user] ASC);

