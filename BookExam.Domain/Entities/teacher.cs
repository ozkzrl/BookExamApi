public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Öğretmenin birden fazla öğrencisi olabilir
    public List<Student> Students { get; set; }
}
