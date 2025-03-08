namespace BookExam.Application.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; }  // Soru seçenekleri
        public string CorrectAnswer { get; set; }   // Doğru cevap
        public int BookId { get; set; }             // Hangi kitaba ait olduğu
    }
}
