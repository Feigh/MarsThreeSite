using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarsThreeSite.Data;
using MarsThreeSite.Models;

namespace MarsThreeSite.Controllers
{
    public class PageController : Controller
    {
        private readonly SiteDb _context;

        public PageController(SiteDb context)
        {
            _context = context;
        }

        // GET: Page
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pages.ToListAsync());
        }

        // GET: Page/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (pageModel == null)
            {
                return NotFound();
            }

            return View(pageModel);
        }

        // GET: Page/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageNumber,PageName,PageAddress,Published,isDeleted")] PageModel pageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageModel);
        }

        // GET: Page/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages.FindAsync(id);
            if (pageModel == null)
            {
                return NotFound();
            }
            return View(pageModel);
        }

        // POST: Page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageNumber,PageName,PageAddress,Published,isDeleted")] PageModel pageModel)
        {
            if (id != pageModel.PageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageModelExists(pageModel.PageId))
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
            return View(pageModel);
        }

        // GET: Page/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageModel = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (pageModel == null)
            {
                return NotFound();
            }

            return View(pageModel);
        }

        // POST: Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageModel = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(pageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageModelExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}
