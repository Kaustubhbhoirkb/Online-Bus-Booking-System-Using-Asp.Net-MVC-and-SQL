--Procedure For Customer Login

create procedure cust_login1    
@Email Nvarchar (100),    
@Password Nvarchar (100),    
@Isvalid BIT OUT    
AS    
BEGIN    
SET @Isvalid =(select Count(1) from cust_login WHERE Email=@Email and Password=@Password)    
end

--Procedure For Admin Login

create procedure adminprocedure  
@Admin_Id varchar (100),  
@Password varchar (100),  
@Isvalid BIT OUT  
AS  
BEGIN  
SET @Isvalid =(select Count(1) from adminlogin WHERE Admin_Id=@Admin_Id and Password=@Password)  
end

--Procedure For Employee Login

create procedure employeelogin  
@Employee_id Nvarchar (100),  
@Password Nvarchar (100),  
@Isvalid BIT OUT  
AS  
BEGIN  
SET @Isvalid =(select Count(1) from employee WHERE Employee_id=@Employee_id and Password=@Password)  
end

--Procedure to Check Availability Of Seats

create procedure seatsprocedure  
@Busid varchar (100),  
@Seats varchar (100),  
@Isvalid BIT OUT  
AS  
BEGIN  
SET @Isvalid =(select Count(1) from seats WHERE busid=@Busid and seats=@Seats and status='Available')  
end

--Procedure For Customer Forget Password

CREATE PROCEDURE fpass    
(    
@Mno Varchar(50),    
@Email Varchar(20),    
@password nvarchar(100),    
@sque nvarchar(100),    
@ans nvarchar(30)    
)    
AS    
BEGIN    
Update cust_login Set Password=@password     
WHERE Mobile_No=@Mno and Email=@Email and Security_Question=@sque and Answer=@ans    
END

--Procedure For Ewallet

create procedure ewallet  
@Mno Varchar(20),  
@Pass varchar(20),  
@amount float  
as  
begin  
UPDATE cust_login SET Ewallet=CASE WHEN Ewallet IS NULL OR Ewallet='' THEN @amount    
ELSE Ewallet+ @amount END WHERE Mobile_No=@Mno and Password=@Pass  
end

--Procedure For Payment

create procedure finalpay    
@mno Varchar(20),    
@amount float  
as    
begin    
Update cust_login set Ewallet=Ewallet-@amount Where Mobile_No=@mno and Ewallet>@amount     
end

--Procedure For Updating Seats After Booking in Bus 

create proc updateseat  
@a int,  
@id int  
as  
begin  
Update Addbus set NumberOfSeats=NumberOfSeats-@a Where Id=@id  
end

--Procedure For Cancelling Tickets

create procedure Canceltickets    
@name varchar(30),  
@Mno varchar(20),  
@mail varchar(30),  
@Busid varchar (100),    
@Seats varchar (100),    
@Isvalid BIT OUT    
AS    
BEGIN    
SET @Isvalid =(select Count(1) from seats WHERE busid=@Busid and seats=@Seats and status='Booked')    
Insert into cancelreq values(@name,@mail,@Mno,@Busid,@Seats) 
Update Addbus set NumberOfSeats=NumberOfSeats+1 Where Id=@Busid  
end 

--Procedure For initiating refund

create procedure refund  
@mno varchar(20),  
@email varchar(30),  
@amount float  ,
@tno int
as  
begin  
Update cust_login Set Ewallet=Ewallet+@amount Where Mobile_No=@mno And Email=@email  
Delete From Reservation Where TicketId=@tno
end
