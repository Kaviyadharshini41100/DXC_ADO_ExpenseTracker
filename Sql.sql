Create Database ExpenseTracker
use ExpenseTracker
create Table Transactions(
Title varchar(30),
Descriptions varchar(80),
Amount int,
Dates DateTime
)
select * from Transactions