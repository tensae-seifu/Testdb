using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instatnsiate new connection
            SqlConnection conn = new SqlConnection();
            {
                //connect to the data base iusing db connection string

                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDatabas;Integrated Security=True";
                conn.Open(); //opens the current connection

               //selectin alll the contents in the customer table 
                SqlCommand cmd = new SqlCommand("SELECT CUSTOMER.CustomerID,  CUSTOMER.CustomerName,ORDERS.Item,ORDERS.OrderDate FROM CUSTOMER JOIN ORDERS ON CUSTOMER.CustomerID = ORDERS.OrderID ", conn);

                //sql internal objet that reads data from a table is called 
                SqlDataReader reader =cmd.ExecuteReader(); 
                
                if(reader.HasRows) // 
                
                {
                    Console.WriteLine("{0}\t{1}\t{2 }\t{3}", "Customer ID", "Customer Name", "Ordered Item", "Ordered Date");

                    while (reader.Read()) 
                    {
                     Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));

                    }
                }
                else
                {
                    Console.WriteLine("No rows");
                }

                reader.Close(); 
            }
        }
    }

}