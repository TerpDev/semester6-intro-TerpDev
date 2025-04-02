namespace Semester6.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Naam { get; set; }
        public ICollection<ToetsResultaat> ToetsResultaten { get; set; }

    }
}
