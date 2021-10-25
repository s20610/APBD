CREATE TABLE [Album]
(
 [IdAlbum]      int NOT NULL ,
 [AlbumName]    nvarchar(30) NOT NULL ,
 [PublishDate]  datetime NOT NULL ,
 [IdMusicLabel] int NOT NULL ,


 CONSTRAINT [PK_album] PRIMARY KEY CLUSTERED ([IdAlbum] ASC),
 CONSTRAINT [FK_63] FOREIGN KEY ([IdMusicLabel])  REFERENCES [MusicLabel]([IdMusicLabel])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_64] ON [Album] 
 (
  [IdMusicLabel] ASC
 )

GO
CREATE TABLE [Musician]
(
 [IdMusician_1] int NOT NULL ,
 [FirstName]    nvarchar(30) NOT NULL ,
 [LastName]     nvarchar(50) NOT NULL ,
 [Nickname]     nvarchar(20) NULL ,


 CONSTRAINT [PK_musician] PRIMARY KEY CLUSTERED ([IdMusician_1] ASC)
);
GO
CREATE TABLE [Musician_Track]
(
 [IdMusician_1] int NOT NULL ,
 [IdTrack]      int NOT NULL ,


 CONSTRAINT [FK_53] FOREIGN KEY ([IdMusician_1])  REFERENCES [Musician]([IdMusician_1]),
 CONSTRAINT [FK_56] FOREIGN KEY ([IdTrack])  REFERENCES [Track]([IdTrack])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_54] ON [Musician_Track] 
 (
  [IdMusician_1] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_57] ON [Musician_Track] 
 (
  [IdTrack] ASC
 )

GO
CREATE TABLE [MusicLabel]
(
 [IdMusicLabel] int NOT NULL ,
 [Name]         nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_musiclabel] PRIMARY KEY CLUSTERED ([IdMusicLabel] ASC)
);
GO
CREATE TABLE [Track]
(
 [IdTrack]      int NOT NULL ,
 [TrackName]    nvarchar(20) NOT NULL ,
 [Duration]     float NOT NULL ,
 [IdMusicAlbum] int NULL ,


 CONSTRAINT [PK_track] PRIMARY KEY CLUSTERED ([IdTrack] ASC),
 CONSTRAINT [FK_60] FOREIGN KEY ([IdMusicAlbum])  REFERENCES [Album]([IdAlbum])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_61] ON [Track] 
 (
  [IdMusicAlbum] ASC
 )

GO
