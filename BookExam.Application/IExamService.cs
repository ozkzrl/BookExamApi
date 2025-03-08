namespace BookExam.Application.Interfaces
{
    public interface IExamService
    {
        Task<ExamDto> GetExamByIdAsync(int id);
        Task<IEnumerable<ExamDto>> GetExamsByStudentIdAsync(int studentId);
        Task StartExamAsync(ExamDto examDto);
        Task SubmitExamAsync(int examId);
    }
}
