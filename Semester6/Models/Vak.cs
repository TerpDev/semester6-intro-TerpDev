namespace Semester6.Models
{
    public class Vak
    {
        public int VakId { get; set; }
        public string Naam { get; set; }
        public int DocentId { get; set; }
        public Docent Docent { get; set; }
        public ICollection<Toets> Toetsen { get; set; }

    }
}
