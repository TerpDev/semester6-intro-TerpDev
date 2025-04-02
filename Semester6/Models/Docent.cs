namespace Semester6.Models
{
    public class Docent
    {
        public int DocentId { get; set; }
        public string Naam { get; set; }
        public ICollection<Vak> Vakken { get; set; }

    }
}
