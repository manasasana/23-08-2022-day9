use demo;
go
use student;
go
select STUFF('manasa',1,4,'tina');
select log(76);
select sin(-9);
select CURRENT_TIMESTAMP
select cast(DOB as datetime) from EmpInfo;
select CURRENT_USER
select USER_NAME()
select iif(purch_amt>500,'yes','no') from orders;
select ISNULL('2022-08-22','22/08/2022')
select ISNUMERIC(EmpId) from EmpInfo;
select Name,Designation,ISNUMERIC(Designation) from EmpInfo;
insert into EmpInfo values(18,'tina','2001-8-2','pune',9876542567,78, '2022-8-1');

select    'data source=' + @@servername +    ';initial catalog=' + db_name() +    case type_desc        when 'WINDOWS_LOGIN'             then ';trusted_connection=true'        else            ';user id=' + suser_name() + ';password=<<YourPassword>>'    end    as ConnectionStringfrom sys.server_principalswhere name = suser_name()

--data source=DESKTOP-1UU1KC8\MSSQLSERVER1;initial catalog=student;trusted_connection=true

create or alter procedure empdetails as
select * from EmpInfo;

exec empdetails

select * from AccInfo

create or alter procedure accountdetails @id int as
delete from AccInfo where custId=@id;

create or alter procedure employeeinformation @baseoffice varchar(10) as 
select EmpId,Name,BaseOffice from EmpInfo where BaseOffice=@baseoffice;

exec employeeinformation banglore
select * from EmpInfo;

create or alter procedure employeesalaryinformation  as 
select e.Name, s.salary from EmpInfo e inner join EmpSalary s on e.EmpId=s.EmpId;

exec employeesalaryinformation 45000

select * from EmpSalary;

create or alter procedure updatesalaryinformation @increment float as 
update EmpSalary set Salary=Salary+@increment;
select e.Name, s.salary from EmpInfo e inner join EmpSalary s on e.EmpId=s.EmpId;
