# payc

Create a Databse called mukundir_db On SQL SEVRER 

and run the Query Below 

USE [mukundir_db]
GO

/****** Object: Table [dbo].[TaxCalculations] Script Date: 2023/06/22 20:25:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaxCalculations] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [PostalCode]      VARCHAR (20)    NOT NULL,
    [AnnualIncome]    DECIMAL (18, 2) NOT NULL,
    [TaxAmount]       DECIMAL (18, 2) NOT NULL,
    [CalculationDate] DATETIME        NOT NULL
);


