﻿using System.Data.SqlClient;
namespace day9;
 public class one
{
    public static void Main(string[] args)
    {
        string connection= "data source=DESKTOP-1UU1KC8\\MSSQLSERVER1;initial catalog=student;trusted_connection=true";
        SqlConnection sqlcon = new SqlConnection(connection);
        sqlcon.Open();
        Console.WriteLine("After open");
        SqlCommand cmd= new SqlCommand("employeesalaryinformation", sqlcon);
        
        Console.WriteLine("employee salary information");
       
      
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        
        
        SqlDataReader dr= cmd.ExecuteReader();
       
        Console.WriteLine("executed successfully");
        while(dr.Read())
        {
            Console.WriteLine(dr[0].ToString()+" "+ dr[1].ToString());    
           
        }
        dr.Close();
        cmd.CommandText = "updatesalaryinformation";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        Console.WriteLine("employee salary increment");
        String incr = Console.ReadLine();
        float increment = float.Parse(incr);
        cmd.Parameters.Add("@increment", System.Data.SqlDbType.Float).Value = increment;

        dr=cmd.ExecuteReader();
        while (dr.Read())
        {
            Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString());

        }
        dr.Close();
      
        sqlcon.Close();

    }
}