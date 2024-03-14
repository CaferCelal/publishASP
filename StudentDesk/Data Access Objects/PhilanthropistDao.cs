using System.Collections;
using System.Data;
using System.Data.SqlClient;
using StudentDesk.Model;

namespace StudentDesk;

public class PhilanthropistDao : BaseDao {
    public PhilanthropistDao(IConfiguration configuration) : base(configuration) {

    }

    public void AddPhilanthropist(Philanthropist philanthropist) {
        ConnectionOpen();

        // Define the SQL query to insert a new philanthropist
        string sqlQuery =
            "INSERT INTO Philanthropists (First_Name, Last_Name, Email, Password, Phone_Number) VALUES (@FirstName, @LastName, @Email, @Password, @PhoneNumber)";

        // Create a SqlCommand object with the SQL query and connection
        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _SqlConnection)) {
            // Add parameters to the SQL query to prevent SQL injection
            sqlCommand.Parameters.AddWithValue("@FirstName", philanthropist.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", philanthropist.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", philanthropist.Email);
            sqlCommand.Parameters.AddWithValue("@Password", philanthropist.Password); // Assuming Password is stored as a string in the database
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", philanthropist.PhoneNumber);

            // Execute the SQL query to insert the new philanthropist
            sqlCommand.ExecuteNonQuery();
            ConnectionClose();
        }
    }

    public List<Philanthropist> GetAll() {
            ConnectionOpen();
            string SqlQuery = "Select * from Philanthropists";

            SqlCommand sqlCommand = new SqlCommand(SqlQuery, _SqlConnection);

            // Execute the query and get the results
            SqlDataReader reader = sqlCommand.ExecuteReader();

            // Create a list to store philanthropist objects
            List<Philanthropist> philanthropists = new List<Philanthropist>();

            // Read through the results and add them to the list
            while (reader.Read()) {
                Philanthropist philanthropist = new Philanthropist {
                    Id = (int)reader["Id"],
                    FirstName = reader["First_Name"].ToString(),
                    LastName = reader["Last_Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    // Password is a byte array, handle accordingly
                    Password = reader["Password"].ToString(),
                    PhoneNumber = reader["Phone_Number"].ToString(),
                };

                philanthropists.Add(philanthropist);
            }

            // Close the reader and return the list
            reader.Close();
            ConnectionClose();
            return philanthropists;
        }


    }
