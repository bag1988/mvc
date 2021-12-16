using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Base;

namespace mvc.Areas.admin.Controllers
{
    [Area("admin")]
    public class exensionsController : Controller
    {
        private readonly MvcContext _context;

        public exensionsController(MvcContext context)
        {
            _context = context;
        }

        // GET: exensions
        public async Task<IActionResult> Index()
        {
            return View(await _context.modules.ToListAsync());
        }

        [HttpPost]
        public async Task<JsonResult> viewModule()
        {
            return Json(await _context.modules.ToListAsync());
        }
        // GET: exensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.modules
                .FirstOrDefaultAsync(m => m.idModule == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // GET: exensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: exensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idModule,nameModule,defaultHtml,defaultCss,urlModule")] module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: exensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: exensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idModule,nameModule,defaultHtml,defaultCss,urlModule")] module @module)
        {
            if (id != @module.idModule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!moduleExists(@module.idModule))
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
            return View(@module);
        }

        // GET: exensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.modules
                .FirstOrDefaultAsync(m => m.idModule == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: exensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @module = await _context.modules.FindAsync(id);
            _context.modules.Remove(@module);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool moduleExists(int id)
        {
            return _context.modules.Any(e => e.idModule == id);
        }
    }
}
