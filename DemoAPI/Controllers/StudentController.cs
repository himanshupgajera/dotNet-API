using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>();

        // GET
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET by Id
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // POST 
        [HttpPost]
        public void Post([FromBody]Student value)
        {
            students.Add(value);
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student value)
        {
            int i = students.FindIndex(s => s.Id == id);
            if (i > 0)
            {
                students[i] = value;
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            students.RemoveAll(s => s.Id == id);
        }
    }
}
