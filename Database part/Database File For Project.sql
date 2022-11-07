--Bus 
We Have Created Bus_Table_By Code First Approach
--Admin

create table adminlogin(Admin_Id varchar (30),Password varchar(30))
insert into adminlogin values('testadmin','123')

--Employee   databasefirst

create table employee(Id int primary key,Employee_id Nvarchar (100),Password Nvarchar(100),Emp_name Nvarchar (100),Age int,Salary decimal,Gender Nvarchar (100))

--Registration  / customer login

create table cust_login(Name Varchar(50),Admin_Id nvarchar (30),Password Nvarchar(30),Age Int,City Varchar(20),Gender Varchar(20),Mobile_No varchar(50),Security_question varchar(50),answer varchar(50))

--Booked Tickets

create table reservation(Name Varchar(50),Email nvarchar(30),Mailsub Nvarchar(30),Age Int,City Varchar(20),Mailbody Varchar(100),Mobile_No varchar(50),Modeofpayment varchar(50),Amount_Received float,BusId int,TicketId int identity(111,2))

--Cancel Request

create table cancelreq(Name varchar(30),Email Varchar(30),Mobile_No Varchar(20),Busid int,Seatno int)

--Seats Table

create table seats(busid varchar (100),seats varchar (100), status varchar (100))

--This Is done manually currently we are working to automate this Entries once its done it will be available for you also

insert into seats(busid,seats,status) values('1','1','Available')
insert into seats(busid,seats,status) values('1','2','Available')
insert into seats(busid,seats,status) values('1','3','Available')
insert into seats(busid,seats,status) values('1','4','Available')
insert into seats(busid,seats,status) values('1','5','Available')
insert into seats(busid,seats,status) values('1','6','Available')
insert into seats(busid,seats,status) values('1','7','Available')
insert into seats(busid,seats,status) values('1','8','Available')
insert into seats(busid,seats,status) values('1','9','Available')
insert into seats(busid,seats,status) values('1','10','Available')
insert into seats(busid,seats,status) values('1','11','Available')
insert into seats(busid,seats,status) values('1','12','Available')
insert into seats(busid,seats,status) values('1','13','Available')
insert into seats(busid,seats,status) values('1','14','Available')
insert into seats(busid,seats,status) values('1','15','Available')
insert into seats(busid,seats,status) values('1','16','Available')
insert into seats(busid,seats,status) values('1','17','Available')
insert into seats(busid,seats,status) values('1','18','Available')
insert into seats(busid,seats,status) values('1','19','Available')
