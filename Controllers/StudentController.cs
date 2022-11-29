using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ViewNextWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViewNextWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string cadenaConexion;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            cadenaConexion = _configuration.GetConnectionString("ViewnextDatabase");
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using(SqlConnection con = new SqlConnection(cadenaConexion))
            {
                
                con.Open();
                string sql = "SELECT * FROM Student";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return NotFound();
                        }
                        while (reader.Read())
                        {
                            Student student = new Student();
                            student.Id = reader.GetInt32(0);
                            student.Name = reader.GetString(1);
                            student.Surname = reader.GetString(2);
                            student.Address = reader.GetString(3);

                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> Get(int id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string sql = "SELECT * FROM Student WHERE Id = " + id;

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return NotFound();
                        }

                        while (reader.Read())
                        {
                            student.Id = reader.GetInt32(0);
                            student.Name = reader.GetString(1);
                            student.Surname = reader.GetString(2);
                            student.Address = reader.GetString(3);
                        }
                    }
                }
            }
            return student;
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string sql = "INSERT INTO Student(Name, Surname, Address) VALUES('"
                    + student.Name + "','"
                    + student.Surname + "','"
                    + student.Address + "')";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Modify(Student student)
        {
            if(student == null || student.Id == 0)
            {
                return BadRequest();
            }

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string sql = "UPDATE Student SET Name='" + student.Name
                    + "', Surname='" + student.Surname
                    + "', Address='" + student.Address
                    + "' WHERE Id='" + student.Id.ToString() + "'";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string sql = "DELETE Student WHERE Id='" + id.ToString() + "'";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }
    }
}
