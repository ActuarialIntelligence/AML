using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProcRunEXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullNameOfStoredProc = args[0];
            Console.WriteLine("About to execute: {0}", fullNameOfStoredProc);
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            con.Open();
            var  cmd = new SqlCommand(fullNameOfStoredProc, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 360000;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Executed Successfully!!");
            con.Close();
        }
    }
}
