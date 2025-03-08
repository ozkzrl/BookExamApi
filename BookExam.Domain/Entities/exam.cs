namespace BookExam.Domain.Entities
{
public class Exam
{
    public int Id { get; set; }
    public int StudentId { get; set; }  // Sınavın ait olduğu öğrenci
    public Student Student { get; set; } // Öğrenci ile ilişki
    public int BookId { get; set; }  // Hangi kitapla ilişkilidir
    public Book Book { get; set; }   // Kitap ile ilişki
    public List<Question> Questions { get; set; }  // Sınavda sorular
    public DateTime StartTime { get; set; }  // Sınav başlangıç zamanı
    public DateTime EndTime { get; set; }    // Sınav bitiş zamanı
}
}