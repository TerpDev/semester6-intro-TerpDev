namespace Semester6.Models;
public class CijferWijziging
{
    public int Id { get; set; }
    public int ToetsResultaatId { get; set; }
    public decimal OudCijfer { get; set; }
    public decimal NieuwCijfer { get; set; }
    public DateTime WijzigingsDatum { get; set; }
}
