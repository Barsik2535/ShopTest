using Microsoft.AspNetCore.Mvc;
using study_3.Models;
using System.Diagnostics;
namespace study_3.Controllers;
using Microsoft.EntityFrameworkCore;
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    

    public async Task<IActionResult> Edit(int? id)
    {
        if (id != null)
        {
        User? user = await db.Users.FirstOrDefaultAsync(parameter => parameter.Id == id);
            if (user != null)  return View(user);
        }
    return NotFound();
}
   [HttpPost]
   public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return NotFound();
    }
[HttpPost]
public async Task<IActionResult> Edit(User user)
{
    db.Users.Update(user);
    await db.SaveChangesAsync();
    return RedirectToAction("Index");
}
    public IActionResult Privacy()
        {
            return View();
        }
    }