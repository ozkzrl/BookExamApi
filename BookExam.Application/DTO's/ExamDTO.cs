namespace BookExam.Application.DTOs
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }  // Sınavın ait olduğu öğrenci
        public int BookId { get; set; }  // Hangi kitapla ilişkilidir
        public DateTime StartTime { get; set; }  // Sınav başlangıç zamanı
        public DateTime EndTime { get; set; }    // Sınav bitiş zamanı
        public List<QuestionDTO> Questions { get; set; }  // Sınavda sorular
    }
}
