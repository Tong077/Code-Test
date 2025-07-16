# C# DevExpress Product Sales Report Tool

## Connection String
Uses `(localdb)\MSSQLLocalDB` by default. Change in `DataContext Floder/DataConnection.cs` if needed.

## Setup Instructions
1. Clone this repository https://github.com/Tong077/Code-Test.git
2. Open `Coding_Test.sln` in Visual Studio
3. Make sure DevExpress is installed (v23.2+)
4. Run `Create database Assignment` to create and seed the database

5. 
## Features
- Design The Report Tool Using DesExpress in The Reports Folder(The Design Report does not look friendly)
- Filter by date range
- Search By Product Name
- Group by ProductCode In The Report
- Export to PDF Specefic Start and end Date
## Script Crate The Table
-   CREATE TABLE PRODUCTSALES (
    SALEID INT IDENTITY,
    PRODUCTCODE NVARCHAR(20),
    PRODUCTNAME NVARCHAR(100),
    QUANTITY INT,
    UNITPRICE DECIMAL(18,2),
    SALEDATE DATE
   
)
 ## Seed data
- INSERT INTO PRODUCTSALES (PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE) VALUES
('P001', 'Coffee Beans', 5, 10.00, '2025-07-01'),
('P002', 'Milk', 3, 1.50, '2025-07-02'),
('P003', 'Sugar', 2, 0.75, '2025-07-03'),
('P001', 'Coffee Beans', 4, 10.00, '2025-07-04'),
('P002', 'Milk', 6, 1.50, '2025-07-05');
 ##
 - The UI Design Report does look friendly.
 
