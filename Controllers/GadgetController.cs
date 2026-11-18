using Microsoft.AspNetCore.Mvc;
using GadgetInventory.Models;

namespace GadgetInventory.Controllers;

public class GadgetController : Controller
{
    private static List<Gadget> gadgets = new()
    {
        new Gadget { Id = 1, Brand = "Apple", ModelName = "iPhone 15", Price = 799m },
        new Gadget { Id = 2, Brand = "Samsung", ModelName = "Galaxy S24", Price = 849m }
    };

    public IActionResult Index()
    {
        return View(gadgets);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Gadget gadget)
    {
        if (ModelState.IsValid)
        {
            gadget.Id = gadgets.Count + 1;
            gadgets.Add(gadget);

            return RedirectToAction("Index");
        }

        return View(gadget);
    }
}