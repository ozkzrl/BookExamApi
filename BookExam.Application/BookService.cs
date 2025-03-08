using BookExam.Application.Interfaces;
using BookExam.Domain.Entities;
using BookExam.Infrastructure;

namespace BookExam.Application.Services
{
    public class BookService : IBookService
    {
        private readonly BookExamDbContext _context;

        public BookService(BookExamDbContext context)
        {
            _context = context;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Kitaplar.FindAsync(id);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title
            };
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            return await _context.Kitaplar
                                 .Select(book => new BookDto
                                 {
                                     Id = book.Id,
                                     Title = book.Title
                                 })
                                 .ToListAsync();
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title
            };

            await _context.Kitaplar.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = await _context.Kitaplar.FindAsync(bookDto.Id);
            if (book == null) return;

            book.Title = bookDto.Title;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Kitaplar.FindAsync(id);
            if (book == null) return;

            _context.Kitaplar.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
