CREATE TABLE [dbo].[BDD_Question] (
    [QuestionID]     INT            NOT NULL,
    [QuestionName]   NVARCHAR (100) NOT NULL,
    [QuestionTypeID] INT            NOT NULL,
    [CreationStatus] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([QuestionID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF)
);

