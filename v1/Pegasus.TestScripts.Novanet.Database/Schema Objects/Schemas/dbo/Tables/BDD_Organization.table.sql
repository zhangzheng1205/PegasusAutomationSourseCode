CREATE TABLE [dbo].[BDD_Organization] (
    [OrgID]          INT           NOT NULL,
    [OrgName]        NVARCHAR (50) NOT NULL,
    [LevelTypeID]    INT           NOT NULL,
    [CreationStatus] BIT           NOT NULL,
    [OrgTypeID]      INT           NULL
);

