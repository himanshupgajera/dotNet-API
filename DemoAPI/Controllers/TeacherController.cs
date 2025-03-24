using customer.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase{
        private readonly ApplicationDbContext dbcontext;

        public TeacherController(ApplicationDbContext context){
            this.dbcontext = context;
        }

        // GET
        [HttpGet]
        public IEnumerable<Teacher> Get(){
            var allControllers = dbcontext.teacher.ToList();
            return allControllers;
        }

        // POST 
        [HttpPost]
        public void Post([FromBody] Teacher value){
            dbcontext.teacher.Add(value);
            dbcontext.SaveChanges();
        }

        // PUT
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Teacher value){
            var s = dbcontext.teacher.Find(id);
            if (s != null){
                s.Name = value.Name;
                s.Subject = value.Subject;
                dbcontext.SaveChanges();
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(long id){
            var s = dbcontext.teacher.Find(id);
            if (s != null){
                dbcontext.teacher.Remove(s);
                dbcontext.SaveChanges();
            }
        }
    }
}