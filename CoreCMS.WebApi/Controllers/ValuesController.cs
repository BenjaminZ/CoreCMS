using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoreCMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var studentList = new List<Student>();
            studentList.Add(new Student
            {
                Name = "Ben Zhang",
                Id = 1,
                NickName = "Superman"
            });
            studentList.Add(new Student
            {
                Name = "Ying Zhou",
                Id = 2,
                NickName = "Iris"
            });
            studentList.Add(new Student
            {
                Name = "Siwan Yu",
                Id = 3,
                NickName = "Alex my wife"
            });
            return studentList;
        }

        public class Student
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string NickName { get; set; }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}