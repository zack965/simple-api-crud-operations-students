using api_student_vs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_student_vs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //api/Student
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext app;

        public StudentController(AppDbContext _app)
        {
            app = _app;
        }
        [HttpGet]
        public ActionResult <IEnumerable<Student>> GetAllStudents()
        {
            return app.students.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var find = app.students.SingleOrDefault(x => x.Student_Id == id);
            return find;
        }
        //[Route("/add")]
        [HttpPost]
        public ActionResult AddStudent(Student std)
        {
            app.students.Add(std);
            app.SaveChanges();
            //return CreatedAtAction(nameof(GetStudent), new { id = std.Student_Id }, std);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult EditStudent(Student std,int id)
        {
            if (id != std.Student_Id)
            {
                return BadRequest();
            }

            app.Entry(std).State = EntityState.Modified;
            app.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var StudentRemoved = app.students.Find(id);

            if (StudentRemoved == null)
            {
                return NotFound();
            }

            app.students.Remove(StudentRemoved);
            app.SaveChanges();

            return NoContent();

        }
    }
}
