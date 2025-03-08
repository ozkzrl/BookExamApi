namespace BookExam.Domain.Entities
{
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    // Kitap birden fazla soru içerebilir
    public List<Question> Questions { get; set; }
}

}