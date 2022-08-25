//Write a C# program to get a list of values from the user. (Passport information: passport number, candidate name, passport expiry date, years of validity, applied through channel (Normal, Priority),etc) for atleast 10 candidates. Create a table and upload this information to the table using a Stored Procedure.

using System.Data.SqlClient;

namespace day9;
public class two
{
    public static void Main(string[] args)
    {
        string connection = "data source=DESKTOP-1UU1KC8\\MSSQLSERVER1;initial catalog=student;trusted_connection=true";
        SqlConnection sqlcon = new SqlConnection(connection);
        sqlcon.Open();
       
        SqlCommand cmd = new SqlCommand("passportinformation", sqlcon);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        Console.WriteLine("enter passport details");
        for (int i = 1; i <= 10; i++)
        {
        cmd.Parameters.Clear();
            int pn = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.Add("@passportnumber", System.Data.SqlDbType.Int).Value = pn;
            string name = Console.ReadLine();
            cmd.Parameters.Add("@candidatename", System.Data.SqlDbType.VarChar).Value = name;
            DateTime vdate = Convert.ToDateTime(Console.ReadLine());

            cmd.Parameters.Add("@passportexpirydate", System.Data.SqlDbType.Date).Value = vdate;
            int val = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.Add("@yearsofvalidity", System.Data.SqlDbType.Int).Value = val;
            string applied = Console.ReadLine();
            cmd.Parameters.Add("@appliedthroughchannel", System.Data.SqlDbType.VarChar).Value = applied;
        cmd.ExecuteNonQuery();
        }
        sqlcon.Close();

    }
}

   **SQL CODE**
use student;
go
create procedure passportinformation @passportnumber int, @candidatename varchar(10),
@passportexpirydate date, @yearsofvalidity int, @appliedthroughchannel varchar(10) as
create table passport(
passport_number int,
candidate_name varchar(10), 
passport_expiry_date date,
years_of_validity int, 
applied_through_channel varchar(10));
insert into passport values(@passportnumber, @candidatename,
@passportexpirydate, @yearsofvalidity, @appliedthroughchannel);
select* from passport;*/


Write a C# program to display students information (Name, Age, Sex, Course, Year of Study, etc). Ask the Year of study from the user and display only those students (If the user enters 1, only show first year students.)
Use Stored Procedure for:
Creating a table with all the information,
Displaying all the information,
Showing the year of study students according to the user input.


namespace day9;
public class two
{
    public static void Main(string[] args)
    {
        string connection = "data source=DESKTOP-1UU1KC8\\MSSQLSERVER1;initial catalog=student;trusted_connection=true";
        SqlConnection sqlcon = new SqlConnection(connection);
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand("informationofstudent", sqlcon);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        
        Console.WriteLine("student details");
        int age = Convert.ToInt32(Console.ReadLine());
        
            cmd.Parameters.Add("@age", System.Data.SqlDbType.Int).Value = age;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString()+
                dr[2].ToString() + " " + dr[3].ToString()+ " " + dr[4].ToString());

        }
        dr.Close();

        sqlcon.Close();

    }
}


**SQL CODE**
    create table info(
Name varchar(10), 
Age int, 
Sex varchar(10), 
Course varchar(10), 
Year_of_Study int);

create or alter procedure informationofstudent @year int as
select Name, Age, Sex, Course, Year_of_Study from info where Year_of_Study = @year and @year = 1;
insert into info values('sana',23,'female','CSE',4);
insert into info values('tina',23,'female','CSE',1);
insert into info values('tara',23,'female','CSE',1);

exec informationofstudent 1


