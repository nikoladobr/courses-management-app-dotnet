using Domain;
using System.Data.SqlClient;

namespace BrokerDB
{
    public class Broker
    {
        SqlConnection conn;

        public Broker()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoursesManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void OpenConn()
        {
            conn.Open();
        }

        public void CloseConn()
        {
            conn?.Close();
        }

        public List<ExamPeriod> ReturnExamPeriods()
        {
            List<ExamPeriod> result = new();

            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from ExamPeriod";
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExamPeriod ep = new();
                        ep.Id = (int)reader["id"];
                        ep.Name = (string)reader["name"];
                        ep.StartDate = DateTime.Parse(reader["startDate"].ToString());
                        ep.EndDate = DateTime.Parse(reader["endDate"].ToString());
                        result.Add(ep);
                    }
                    return result;
                }
            }

        }

        public List<ExamPeriodCourse> ReturnCourses(int id)
        {
            List<ExamPeriodCourse> result = new();
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select c.id as id, c.name as course, c.ects as ects, epc.date from ExamPeriodCourse epc join Course c on(epc.id_course=c.id) join ExamPeriod ep on(epc.id_examperiod=ep.id) where id_examperiod = @id";
                cmd.Parameters.AddWithValue("@id", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExamPeriodCourse epc = new();
                        epc.Course = new Course();
                        epc.Date = DateTime.Parse(reader["date"].ToString());
                        epc.Course.Id = (int)reader["id"];
                        epc.Course.Name = (string)reader["course"];
                        epc.Course.Ects = (int)reader["ects"];

                        result.Add(epc);
                    }
                    return result;
                }
            }
        }

        

        public void AddCourseToExamPeriod(Course c, ExamPeriod ep, DateTime date)
        {
            
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "INSERT INTO Course (name, ects) OUTPUT INSERTED.id VALUES (@name, @ects)";
            cmd1.Parameters.AddWithValue("@name", c.Name);
            cmd1.Parameters.AddWithValue("@ects", c.Ects);
            int courseId = (int)cmd1.ExecuteScalar();

          
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "INSERT INTO ExamPeriodCourse (id_examperiod, id_course, date) VALUES (@idExamPeriod, @idCourse, @date)";
            cmd2.Parameters.AddWithValue("@idExamPeriod", ep.Id);
            cmd2.Parameters.AddWithValue("@idCourse", courseId);
            cmd2.Parameters.AddWithValue("@date", date);
            cmd2.ExecuteNonQuery();
        }
    }
}