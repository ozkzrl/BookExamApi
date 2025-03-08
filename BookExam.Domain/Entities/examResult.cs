public class ExamResult
{
    public int Id { get; set; }
    public int ExamId { get; set; }  // Sınav kimliği
    public Exam Exam { get; set; }  // Sınav ile ilişki
    public int Score { get; set; }  // Öğrencinin aldığı puan
}
