using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedLevelHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString; ;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "create table [Group](Id int primary key, Name nvarchar(256) not null check(len(Name)>0))";

                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                transaction.Commit();
                command.ExecuteReader();
            }
        }
    }
}
