namespace BookExam.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task AddStudentAsync(StudentDto studentDto);
    }
}
