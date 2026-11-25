# Personal Expense Tracker (WinForms + SQL Server)

A short hands-on C# Windows Forms and Microsoft SQL Server project focused on understanding WinForms' event-driven model and basic CRUD operations using ADO.NET (`Microsoft.Data.SqlClient`).

## Learning Objectives
- Handle core WinForms events (`Load`, `Click`, `CellClick`, `TextChanged`).
- Work with typed input controls (`TextBox`, `ComboBox`, `NumericUpDown`, `DateTimePicker`, `CheckBox`) and `DataGridView`.
- Execute parameterized SQL queries (`INSERT`, `SELECT`, `UPDATE`, `DELETE`) to prevent SQL injection.

## Tech Stack
- C# / .NET (Windows Forms)
- Microsoft SQL Server / LocalDB
- `Microsoft.Data.SqlClient`

## Database Setup
Run the following script in SQL Server Management Studio (SSMS) or Azure Data Studio before launching the app:

```sql
CREATE DATABASE PracticeDB;
GO

USE PracticeDB;
GO

CREATE TABLE Expenses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(120) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    ExpenseDate DATE NOT NULL,
    IsPaid BIT NOT NULL DEFAULT 1
);
