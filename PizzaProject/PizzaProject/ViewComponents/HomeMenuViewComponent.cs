using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Data;

namespace PizzaProject.ViewComponents
{
	public class HomeMenuViewComponent : ViewComponent
	{
        private readonly AppDbContext _context;

        public HomeMenuViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Bütün category-ləri və product-ları gətiririk
            var categories = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return View(categories);
        }
    }
}
