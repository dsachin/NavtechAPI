CREATE TABLE [dbo].[PaymentType] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Type]     VARCHAR (20) NOT NULL,
    [StatusId] INT          CONSTRAINT [DF_PaymentType_StatusId] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

