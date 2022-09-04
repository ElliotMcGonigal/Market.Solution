using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Market.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Market.Controllers
{
  [Authorize]
  public class SweetsController : Controller
  {
    private readonly MarketContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public SweetsController(UserManager<ApplicationUser> userManager, MarketContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userSweets = _db.Sweets.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userSweets);
    }

    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Sweet sweet, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      sweet.User = currentUser;
      _db.Sweets.Add(sweet);
      _db.SaveChanges();
      if (FlavorId != 0)
      {
          _db.FlavorSweet.Add(new FlavorSweet() { FlavorId = FlavorId, SweetId = sweet.SweetId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSweet = _db.Sweets
          .Include(sweet => sweet.JoinEntities)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(sweet => sweet.SweetId == id);
      return View(thisSweet);
    }

    public ActionResult Edit(int id)
    {
      var thisSweet = _db.Sweets.FirstOrDefault(sweet => sweet.SweetId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisSweet);
    }

    [HttpPost]
    public ActionResult Edit(Sweet sweet, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.FlavorSweet.Add(new FlavorSweet() { FlavorId = FlavorId, SweetId = sweet.SweetId });
      }
      _db.Entry(sweet).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisSweet = _db.Sweets.FirstOrDefault(sweet => sweet.SweetId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisSweet);
    }

    [HttpPost]
    public ActionResult AddFlavor(Sweet sweet, int FlavorId)
    {
      if (FlavorId != 0)
      {
      _db.FlavorSweet.Add(new FlavorSweet() { FlavorId = FlavorId, SweetId = sweet.SweetId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSweet = _db.Sweets.FirstOrDefault(sweet => sweet.SweetId == id);
      return View(thisSweet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSweet = _db.Sweets.FirstOrDefault(sweet => sweet.SweetId == id);
      _db.Sweets.Remove(thisSweet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.FlavorSweet.FirstOrDefault(entry => entry.FlavorSweetId == joinId);
      _db.FlavorSweet.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}