using System.Data.SqlClient;
using StudentDesk.Model;

namespace StudentDesk;

public class StudentDao:BaseDao {
    public StudentDao(IConfiguration configuration) : base(configuration) {
        
    }

    public void AddStudent(Student student) {
        ConnectionOpen();
        string sqlQuery =
            "INSERT INTO Students(First_Name,Last_Name,School,Email,Password,Phone_Number,Birth_Date) VALUES (@FirstName,@LastName,@School,@Email,@Password,@PhoneNumber,@BirthDate)";
        
        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery,_SqlConnection)) {
            sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
            sqlCommand.Parameters.AddWithValue("@School", student.School);
            sqlCommand.Parameters.AddWithValue("@Email", student.Email);
            sqlCommand.Parameters.AddWithValue("@Password", student.Password);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@BirthDate", student.BirthDate);
            sqlCommand.ExecuteNonQuery();
            
        }
        ConnectionClose();
    }
    
}