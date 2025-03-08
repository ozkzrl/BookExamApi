using BookExam.Application.Interfaces;
using BookExam.Domain.Entities;
using BookExam.Infrastructure;

namespace BookExam.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly BookExamDbContext _context;

        public StudentService(BookExamDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                City = student.City,
                School = student.School
            };
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            return await _context.Students
                                 .Select(student => new StudentDto
                                 {
                                     Id = student.Id,
                                     Name = student.Name,
                                     City = student.City,
                                     School = student.School
                                 })
                                 .ToListAsync();
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                City = studentDto.City,
                School = studentDto.School
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
