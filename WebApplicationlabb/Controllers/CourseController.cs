using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationlabb.DAL;
using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        
        public CourseController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _unitOfWork.CourseRepository.GetAllCourses();

            if (courses.Count <= 0) return NotFound();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _unitOfWork.CourseRepository.GetCourse(id);

            return course is null ? NotFound() : Ok(course);
        }

        [HttpGet("{number}")]
        public IActionResult GetCourseByNumber(int number)
        {
            var course = _unitOfWork.CourseRepository.GetCourseByNumber(number);

            return course is null ? NotFound() : Ok(course);
        }

        [HttpGet("/Course/{id}/users")]
        public IActionResult GetUserCourses(int id)
        {
            var userCourse = _unitOfWork.CourseRepository.GetUserCourses(id);

            return userCourse is null ? NotFound() : Ok(userCourse);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course? course)
        {
            if (course is null) return BadRequest();

            return _unitOfWork.CourseRepository.CreateCourse(course) ? Ok() : Conflict("Course already exists");
        }

        [HttpPost("/Course/{id}")]
        public IActionResult PostUser([FromBody] User user, int id)
        {
            if (user is null) return BadRequest();

            return _unitOfWork.CourseRepository.ListUserForCourse(user, id) ? Ok(id) : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Course course)
        {
            if (string.IsNullOrEmpty(course.Name.Trim())) return BadRequest();

            return _unitOfWork.CourseRepository.UpdateCourse(id, course) ? Ok() : NotFound();
        }

        [HttpPatch("/Course/{id}/name")]
        public IActionResult PatchName(int id, string name)
        {
            if (string.IsNullOrEmpty(name.Trim())) return BadRequest();

            return _unitOfWork.CourseRepository.UpdateCourseName(id, name) ? Ok(_unitOfWork.CourseRepository.GetCourse(id)) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _unitOfWork.CourseRepository.DeleteCourse(id) ? Ok() : NotFound();
        }
    }
}
