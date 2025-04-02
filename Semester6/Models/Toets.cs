namespace Semester6.Models
{
    public class Toets
    {
        public int ToetsId { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public ICollection<ToetsResultaat> ToetsResultaten { get; set; }

    }
}
