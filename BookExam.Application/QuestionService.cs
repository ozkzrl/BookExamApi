using BookExam.Application.Interfaces;
using BookExam.Domain.Entities;
using BookExam.Infrastructure;

namespace BookExam.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly BookExamDbContext _context;

        public QuestionService(BookExamDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(int id)
        {
            var question = await _context.Sorular.FindAsync(id);
            if (question == null) return null;

            return new QuestionDto
            {
                Id = question.Id,
                Text = question.Text,
                Options = question.Options,
                CorrectAnswer = question.CorrectAnswer,
                BookId = question.BookId
            };
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsByBookIdAsync(int bookId)
        {
            return await _context.Sorular
                                 .Where(q => q.BookId == bookId)
                                 .Select(q => new QuestionDto
                                 {
                                     Id = q.Id,
                                     Text = q.Text,
                                     Options = q.Options,
                                     CorrectAnswer = q.CorrectAnswer,
                                     BookId = q.BookId
                                 })
                                 .ToListAsync();
        }

        public async Task AddQuestionAsync(QuestionDto questionDto)
        {
            var question = new Question
            {
                Text = questionDto.Text,
                Options = questionDto.Options,
                CorrectAnswer = questionDto.CorrectAnswer,
                BookId = questionDto.BookId
            };

            await _context.Sorular.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(QuestionDto questionDto)
        {
            var question = await _context.Sorular.FindAsync(questionDto.Id);
            if (question == null) return;

            question.Text = questionDto.Text;
            question.Options = questionDto.Options;
            question.CorrectAnswer = questionDto.CorrectAnswer;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = await _context.Sorular.FindAsync(id);
            if (question == null) return;

            _context.Sorular.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
