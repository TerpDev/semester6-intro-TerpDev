namespace Semester6.Models
{
    public class ToetsResultaat
    {
        public int ToetsResultaatId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ToetsId { get; set; }
        public Toets Toets { get; set; }
        public bool IsHerkansing { get; set; }
        public decimal Cijfer { get; set; }

    }
}
