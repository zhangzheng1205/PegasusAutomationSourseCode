CREATE TABLE [dbo].[BDD_Program] (
    [ProgramID]      INT            NOT NULL,
    [ProgramName]    NVARCHAR (100) NOT NULL,
    [EmptyCourseID]  INT            NULL,
    [CreationStatus] BIT            NOT NULL,
    [ProgramTypeID]  INT            NOT NULL
);

