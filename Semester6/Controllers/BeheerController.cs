// Controllers/BeheerController.cs
using Microsoft.AspNetCore.Mvc;

public class BeheerController : Controller
{
    private readonly ToetsContext _context;

    public BeheerController(ToetsContext context)
    {
        _context = context;
    }

    public IActionResult CijferWijzigingen()
    {
        var wijzigingen = _context.CijferWijzigingen.ToList();
        return View(wijzigingen);
    }
}
