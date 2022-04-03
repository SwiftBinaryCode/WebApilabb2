﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationlabb.DAL;
using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public UserController([FromServices] UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAllUsers();

            if (users.Count <= 0) return NotFound();

            return Ok(users);
        }

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);

            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet("{id}/Courses")]
        public IActionResult GetUserCourses(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserCourses(id);

            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User? user)
        {
            if (user is null) return BadRequest();

            return _unitOfWork.UserRepository.CreateUser(user) ? Ok() : Conflict("User already exists");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (string.IsNullOrEmpty(user.Name.Trim()) ||
                string.IsNullOrEmpty(user.Email.Trim()))
                return BadRequest();

            return _unitOfWork.UserRepository.UpdateUser(id, user) ? Ok() : NotFound();
        }

        [HttpPatch("{id}/name")]
        public IActionResult PatchName(int id, string name)
        {
            if (string.IsNullOrEmpty(name.Trim())) return BadRequest();

            return _unitOfWork.UserRepository.UpdateUserName(id, name) ? Ok(_unitOfWork.UserRepository.GetUser(id)) : NotFound();
        }

        [HttpPatch("{id}/email")]
        public IActionResult PatchEmail(int id, string email)
        {
            if (string.IsNullOrEmpty(email.Trim())) return BadRequest();

            return _unitOfWork.UserRepository.UpdateUserEmail(id, email) ? Ok(_unitOfWork.UserRepository.GetUser(id)) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _unitOfWork.UserRepository.DeleteUser(id) ? Ok() : NotFound();
        }
    }
}
