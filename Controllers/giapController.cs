using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Model;

namespace DemoMVC.Controllers
{
    public class giapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public giapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: giap
        public async Task<IActionResult> Index()
        {
            return View(await _context.giap.ToListAsync());
        }

        // GET: giap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giap = await _context.giap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (giap == null)
            {
                return NotFound();
            }

            return View(giap);
        }

        // GET: giap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: giap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Hoten,MSV")] giap giap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giap);
        }

        // GET: giap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giap = await _context.giap.FindAsync(id);
            if (giap == null)
            {
                return NotFound();
            }
            return View(giap);
        }

        // POST: giap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Hoten,MSV")] giap giap)
        {
            if (id != giap.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!giapExists(giap.ID))
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
            return View(giap);
        }

        // GET: giap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giap = await _context.giap
                .FirstOrDefaultAsync(m => m.ID == id);
            if (giap == null)
            {
                return NotFound();
            }

            return View(giap);
        }

        // POST: giap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var giap = await _context.giap.FindAsync(id);
            if (giap != null)
            {
                _context.giap.Remove(giap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool giapExists(string id)
        {
            return _context.giap.Any(e => e.ID == id);
        }
    }
}
