CREATE TABLE [dbo].[NLog](
    [id] [int] IDENTITY(1,1) NOT NULL Primary key,
    [timestamp] [datetime] NOT NULL,
    [level] [varchar](100) NOT NULL,
    [logger] [varchar](1000) NOT NULL,
    [message] [varchar](3600) NOT NULL,
    [Callsite] [varchar](3600) NULL,
    [exception] [varchar](3600) NULL
) 