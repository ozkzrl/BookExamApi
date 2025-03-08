namespace BookExam.Application.DTOs
{
    public class ExamResultDTO
    {
        public int Id { get; set; }
        public int ExamId { get; set; }  // Sınav kimliği
        public int Score { get; set; }  // Öğrencinin aldığı puan
    }
}
