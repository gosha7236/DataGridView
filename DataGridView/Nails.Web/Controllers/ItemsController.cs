using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Nails.Web.Controllers;

public class ItemsController : Controller
{
    private readonly IStorageManager _storage;

    public ItemsController(IStorageManager storage)
    {
        _storage = storage;
    }

    // GET: /Items
    public async Task<IActionResult> Index()
    {
        var items = await _storage.GetAllAsync();
        return View(items);
    }

    // GET: /Items/Create
    public IActionResult Create()
    {
        return View(new Item());
    }

    // POST: /Items/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Item item)
    {
        if (!ModelState.IsValid)
            return View(item);

        item.Id = Guid.NewGuid();
        await _storage.AddItemAsync(item);

        return RedirectToAction(nameof(Index));
    }

    // GET: /Items/Edit/{id}
    public async Task<IActionResult> Edit(Guid id)
    {
        var item = (await _storage.GetAllAsync())
            .FirstOrDefault(x => x.Id == id);

        if (item == null)
            return NotFound();

        return View(item);
    }

    // POST: /Items/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Item item)
    {
        if (!ModelState.IsValid)
            return View(item);

        await _storage.UpdateItemAsync(item);
        return RedirectToAction(nameof(Index));
    }

    // GET: /Items/Delete/{id}
    public async Task<IActionResult> Delete(Guid id)
    {
        await _storage.RemoveItemAsync(id);
        return RedirectToAction(nameof(Index));
    }
}