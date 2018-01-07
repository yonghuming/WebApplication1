using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Authorize]
    public class Urls1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Urls1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Urls1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Urls.ToListAsync());
        }

        // GET: Urls1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urls = await _context.Urls
                .SingleOrDefaultAsync(m => m.ID == id);
            if (urls == null)
            {
                return NotFound();
            }

            return View(urls);
        }

        // GET: Urls1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Urls1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,href,text,status,sortId,catalog")] Urls urls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urls);
        }

        // GET: Urls1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urls = await _context.Urls.SingleOrDefaultAsync(m => m.ID == id);
            if (urls == null)
            {
                return NotFound();
            }
            return View(urls);
        }

        // POST: Urls1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,href,text,status,sortId,catalog")] Urls urls)
        {
            if (id != urls.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrlsExists(urls.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(urls);
        }

        // GET: Urls1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urls = await _context.Urls
                .SingleOrDefaultAsync(m => m.ID == id);
            if (urls == null)
            {
                return NotFound();
            }

            return View(urls);
        }

        // POST: Urls1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urls = await _context.Urls.SingleOrDefaultAsync(m => m.ID == id);
            _context.Urls.Remove(urls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrlsExists(int id)
        {
            return _context.Urls.Any(e => e.ID == id);
        }
    }
}
