using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvWeb_VN.Data.EF;

namespace AdvWeb_VN.WebApp.ViewComponents
{
  public class NaviViewComponent : ViewComponent
  {
    private readonly AdvWebDbContext db;

    public NaviViewComponent(AdvWebDbContext context)
    {
      db = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var cats = await db.Categories.Include(c => c.Posts).ToListAsync();
      return View(cats);
    }
  }
}