CREATE TYPE [dbo].[Hierarchy] AS TABLE (
    [ElementId]   INT            NOT NULL,
    [SequenceNo]  INT            NULL,
    [ParentId]    INT            NULL,
    [ObjectId]    INT            NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [StringValue] NVARCHAR (MAX) NOT NULL,
    [ValueType]   VARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([ElementId] ASC));

