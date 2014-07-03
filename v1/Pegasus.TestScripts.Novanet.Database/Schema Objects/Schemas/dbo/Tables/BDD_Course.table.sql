CREATE TABLE [dbo].[BDD_Course] (
    [CourseID]         INT            NOT NULL,
    [Name]             NVARCHAR (100) NOT NULL,
    [CourseTypeID]     INT            NOT NULL,
    [CreationStatus]   BIT            NOT NULL,
    [PreferenceStatus] BIT            NULL,
    [PublishStatus]    BIT            NULL,
    [ApproveStatus]    BIT            NULL,
    [EnrolCourseID]    VARCHAR (100)  NULL,
    [TemplateName]     VARCHAR (100)  NULL,
    [SectionName]      VARCHAR (100)  NULL
);

