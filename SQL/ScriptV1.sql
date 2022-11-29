USE [ViewNext]
GO

CREATE TABLE [dbo].[Student](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] [varchar](50) NOT NULL,
[Surname] [varchar](100) NOT NULL,
[Address] [varchar](100) NOT NULL,
CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED
(
[Id] ASC
)
) ON [PRIMARY]
GO