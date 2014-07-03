CREATE TABLE [dbo].[BDD_Activity] (
    [ActivityID]       INT            NOT NULL,
    [ActivityName]     NVARCHAR (100) NOT NULL,
    [ActivityTypeID]   INT            NOT NULL,
    [CreationStatus]   BIT            NOT NULL,
    [SubmissionStatus] BIT            DEFAULT ((0)) NOT NULL
);

