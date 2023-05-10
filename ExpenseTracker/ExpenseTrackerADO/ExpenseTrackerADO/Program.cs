using System.Data.SqlClient;
using System.Transactions;
using System.Xml.Linq;

namespace ExpenseTrackerADO
{
    class Transaction
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {

                    SqlConnection con = new SqlConnection("Server=IN-2HRQ8S3; database=ExpenseTracker; Integrated Security=true");
                    con.Open();
                    Console.WriteLine("Welcome to Expense Tracker App");
                    Console.WriteLine("1.Add Transaction");
                    Console.WriteLine("2.View Transaction");
                    Console.WriteLine("3.View Income");
                    Console.WriteLine("4.Check Available Balance");
                    Console.WriteLine("Enter your choice");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {
                                SqlCommand cmd = new SqlCommand($"insert into Transactions values(@Title, @Descriptions, @Amount, @Date)", con);
                                Console.WriteLine("Enter Title: ");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter Description: ");
                                string description = Console.ReadLine();
                                Console.WriteLine("Enter Amount: ");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Date: ");
                                DateTime date = Convert.ToDateTime(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@Title", title);
                                cmd.Parameters.AddWithValue("@Descriptions", description);
                                cmd.Parameters.AddWithValue("@Amount", amount);
                                cmd.Parameters.AddWithValue("@Date", date);
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Inserted Successfully");
                                break;
                            }
                        case 2:
                            {
                                SqlCommand cmd = new SqlCommand($"select * from Transactions where Amount < 0", con);
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        Console.WriteLine(dr[i]);
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                SqlCommand cmd = new SqlCommand($"select * from Transactions where amount > 0", con);
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        Console.WriteLine(dr[i]);
                                    }
                                }
                                break;
                            }
                        case 4:
                            {

                                SqlCommand cmd = new SqlCommand($"select sum(Amount) as CheckBalance from Transactions ", con);
                                var dr = cmd.ExecuteScalar();
                                Console.WriteLine($"Available balance is {dr}");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong choice");
                                break;
                            }

                    }
                    con.Close();

                }          
                    
            }
        }
    }

}




    
   