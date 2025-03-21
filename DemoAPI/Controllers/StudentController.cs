using customer.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext dbcontext;

        public StudentController(ApplicationDbContext context)
        {
            this.dbcontext = context;
        }

        // GET
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var allControllers = dbcontext.student.ToList();
            return allControllers;
        }

        // POST 
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            dbcontext.student.Add(value);
            dbcontext.SaveChanges();
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Student value)
        {
            var s = dbcontext.student.Find(id);
            if (s != null)
            {
                s.Name = value.Name;
                s.RollNumber = value.RollNumber;
                s.Standard = value.Standard;
                dbcontext.SaveChanges();
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var s = dbcontext.student.Find(id);
            if (s != null)
            {
                dbcontext.student.Remove(s);
                dbcontext.SaveChanges();
            }
        }
    }
}
