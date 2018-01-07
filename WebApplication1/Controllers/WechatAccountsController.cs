using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class WechatAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WechatAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WechatAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.WechatAccounts.ToListAsync());
        }

        // GET: WechatAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wechatAccounts = await _context.WechatAccounts
                .SingleOrDefaultAsync(m => m.ID == id);
            if (wechatAccounts == null)
            {
                return NotFound();
            }

            return View(wechatAccounts);
        }

        // GET: WechatAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WechatAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,wechatName")] WechatAccounts wechatAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wechatAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wechatAccounts);
        }

        // GET: WechatAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wechatAccounts = await _context.WechatAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (wechatAccounts == null)
            {
                return NotFound();
            }
            return View(wechatAccounts);
        }

        // POST: WechatAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,wechatName")] WechatAccounts wechatAccounts)
        {
            if (id != wechatAccounts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wechatAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WechatAccountsExists(wechatAccounts.ID))
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
            return View(wechatAccounts);
        }

        // GET: WechatAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wechatAccounts = await _context.WechatAccounts
                .SingleOrDefaultAsync(m => m.ID == id);
            if (wechatAccounts == null)
            {
                return NotFound();
            }

            return View(wechatAccounts);
        }

        // POST: WechatAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wechatAccounts = await _context.WechatAccounts.SingleOrDefaultAsync(m => m.ID == id);
            _context.WechatAccounts.Remove(wechatAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WechatAccountsExists(int id)
        {
            return _context.WechatAccounts.Any(e => e.ID == id);
        }
    }
}
