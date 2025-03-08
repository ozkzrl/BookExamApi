using Microsoft.EntityFrameworkCore;
using BookExam.Domain.Entities;

namespace BookExam.Infrastructure
{
    public class BookExamDbContext : DbContext
    {
        public BookExamDbContext(DbContextOptions<BookExamDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
