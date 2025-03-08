namespace BookExam.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(BookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
