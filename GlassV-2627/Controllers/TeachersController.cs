using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassV_2627.Data;
using GlassV_2627.Models;
using GlassV_2627.DTOs;

namespace GlassV_2627.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherResponseDto>>> GetTeachers()
        {
            var teachers = await _context.Teachers
                .Select(t => new TeacherResponseDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Subject = t.Subject
                })
                .ToListAsync();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherResponseDto>> CreateTeacher([FromBody] CreateTeacherDto dto)
        {
            var teacher = new Teacher
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Subject = dto.Subject
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            var response = new TeacherResponseDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Subject = teacher.Subject
            };

            return Ok(response);
        }

        [HttpPatch("update-subject")]
        public async Task<IActionResult> UpdateTeacherSubject([FromBody] UpdateTeacherDto dto)
        {
            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.Id == dto.TeacherId);

            if (teacher == null)
            {
                return NotFound();
            }

            teacher.Subject = dto.NewSubject;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}