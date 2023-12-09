using StudentRecordManagementSystem.Utility;
using System.Data;
using System.Data.SqlClient;

namespace StudentRecordManagementSystem.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        //GetAllStudent
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lstStudent = new List<Student>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();    
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["ID"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();

                    lstStudent.Add(student);

                }
                conn.Close();
            }
            return lstStudent;
        }

        //AddStudent
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
