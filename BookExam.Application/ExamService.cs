using BookExam.Application.Interfaces;
using BookExam.Domain.Entities;
using BookExam.Infrastructure;

namespace BookExam.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly BookExamDbContext _context;

        public ExamService(BookExamDbContext context)
        {
            _context = context;
        }

        public async Task<ExamDto> GetExamByIdAsync(int id)
        {
            var exam = await _context.Sinavlar
                                      .Include(e => e.Student)
                                      .Include(e => e.Book)
                                      .Include(e => e.Questions)
                                      .FirstOrDefaultAsync(e => e.Id == id);

            if (exam == null) return null;

            return new ExamDto
            {
                Id = exam.Id,
                StudentId = exam.StudentId,
                BookId = exam.BookId,
                StartTime = exam.StartTime,
                EndTime = exam.EndTime,
                Questions = exam.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    Options = q.Options,
                    CorrectAnswer = q.CorrectAnswer,
                    BookId = q.BookId
                }).ToList()
            };
        }

        public async Task<IEnumerable<ExamDto>> GetExamsByStudentIdAsync(int studentId)
        {
            return await _context.Sinavlar
                                 .Where(e => e.StudentId == studentId)
                                 .Select(e => new ExamDto
                                 {
                                     Id = e.Id,
                                     StudentId = e.StudentId,
                                     BookId = e.BookId,
                                     StartTime = e.StartTime,
                                     EndTime = e.EndTime
                                 })
                                 .ToListAsync();
        }

        public async Task StartExamAsync(ExamDto examDto)
        {
            var exam = new Exam
            {
                StudentId = examDto.StudentId,
                BookId = examDto.BookId,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(10)  // 10 dakika süre
            };

            await _context.Sinavlar.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitExamAsync(int examId)
        {
            var exam = await _context.Sinavlar.FindAsync(examId);
            if (exam == null) return;

            // Sınavı tamamla ve sonucu kaydet
            var examResult = new ExamResult
            {
                ExamId = examId,
                Score = CalculateScore(examId)  // Score hesaplama metodunu burada çağırabilirsiniz.
            };

            await _context.SinavSonuclar.AddAsync(examResult);
            await _context.SaveChangesAsync();
        }

        private int CalculateScore(int examId)
        {
            // Burada sınav sonucunu hesaplayabilirsiniz.
            return 100; // Örnek: 100 üzerinden tam puan
        }
    }
}
