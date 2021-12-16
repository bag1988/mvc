using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Areas.Admin.Models;
using mvc.Data;
using mvc.Models.Base;

namespace mvc.areas.admin.Controllers
{
    [Area("admin")]
    public class pageController : Controller
    {
        private readonly MvcContext _context;

        public pageController(MvcContext context)
        {
            _context = context;
        }

        // GET: page
        public async Task<IActionResult> Index()
        {
            return View(await _context.pages.ToListAsync());
        }

        // GET: page/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages
                .FirstOrDefaultAsync(m => m.idPage == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: page/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: page/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPage,roles,namePage,urlPage,keyword,meta")] page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: page/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: page/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPage,roles,namePage,urlPage,keyword,meta")] page page)
        {
            if (id != page.idPage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pageExists(page.idPage))
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
            return View(page);
        }

        // GET: page/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.pages
                .FirstOrDefaultAsync(m => m.idPage == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.pages.FindAsync(id);
            _context.pages.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult changePage([FromBody] newPageHtmlModel p)
        {
            if (!System.IO.File.Exists("views/"+p.actionName + ".cshtml"))
                return Json("<font style='color:red'>Файл с именем <b>" + p.actionName + ".cshtml</b> не существует!</font>");
            using (StreamWriter sw = new StreamWriter("views/"+p.actionName + ".cshtml", false, System.Text.Encoding.UTF8))
            {
                foreach (newValueModulePage t in p.newPageHtml)
                {
                    string id = "";
                    string css = "";
                    string data = " data-content='div'";

                    if (t.id != "")
                        id = "id='" + t.id + "' ";
                    if (t.css != "")
                        css = "class='" + t.css + "' ";
                    if (t.data != "")
                        data = " data-content='" + t.data + "' ";

                    sw.WriteLine("<div" + data + id + css + ">");
                    sw.WriteLine(t.html);
                    sw.WriteLine("</div>");
                }
            }

            return Json("<font style='color:green'>Изменения сохранены!</font>");
        }
        private bool pageExists(int id)
        {
            return _context.pages.Any(e => e.idPage == id);
        }
    }
}
