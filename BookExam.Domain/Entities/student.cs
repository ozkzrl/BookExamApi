namespace BookExam.Domain.Entities
{
   public class Student
    {
        public int Id { get; set; }
         public string Name { get; set; }
        public string City { get; set; }
        public string School { get; set; }
        public string LiteratureTeacher { get; set; }

        // Öğrencinin sınav sonuçları
         public List<ExamResult> ExamResults { get; set; }
    }
}
