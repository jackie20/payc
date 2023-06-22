CREATE TABLE TaxCalculations (
    Id INT PRIMARY KEY IDENTITY,
    PostalCode VARCHAR(20) NOT NULL,
    AnnualIncome DECIMAL(18, 2) NOT NULL,
    TaxAmount DECIMAL(18, 2) NOT NULL,
    CalculationDate DATETIME NOT NULL
);
