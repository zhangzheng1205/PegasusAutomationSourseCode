CREATE TABLE [dbo].[BDD_Product] (
    [ProductID]       INT            NOT NULL,
    [ProductName]     NVARCHAR (100) NOT NULL,
    [CreationStatus]  BIT            NOT NULL,
    [ProgramCourseID] INT            NOT NULL,
    [ProductTypeID]   INT            NOT NULL,
    [LicenseStatus]   BIT            NULL,
    [RumbaResourceID] VARCHAR (100)  NULL,
    [RumbaProductID]  VARCHAR (100)  NULL,
    [MCAssStatus]     BIT            DEFAULT ((0)) NULL
);

