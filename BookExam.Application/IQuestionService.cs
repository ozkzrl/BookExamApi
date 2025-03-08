namespace BookExam.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDto> GetQuestionByIdAsync(int id);
        Task<IEnumerable<QuestionDto>> GetQuestionsByBookIdAsync(int bookId);
        Task AddQuestionAsync(QuestionDto questionDto);
        Task UpdateQuestionAsync(QuestionDto questionDto);
        Task DeleteQuestionAsync(int id);
    }
}
