/**
 * Author: Sanya Singhal
 * Date: 15 December, 2022
 * Course: NETD 3202
 * Description: WorkersController.cs
 *              
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_06.Data;
using Assignment_06.Models;

namespace Assignment_06.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkersContext _context;

        public WorkersController(WorkersContext context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
              return View(await _context.PieceworkWorkerModel.ToListAsync());
        }
        public async Task<IActionResult> Summary()
        {
            return View(await _context.PieceworkWorkerModel.ToListAsync());
        }
        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Message,IsSenior,CreatedDate")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pieceworkWorkerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pieceworkWorkerModel);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel.FindAsync(id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }
            return View(pieceworkWorkerModel);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Message,IsSenior,CreatedDate")] PieceworkWorkerModel pieceworkWorkerModel)
        {
            if (id != pieceworkWorkerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pieceworkWorkerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieceworkWorkerModelExists(pieceworkWorkerModel.Id))
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
            return View(pieceworkWorkerModel);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PieceworkWorkerModel == null)
            {
                return NotFound();
            }

            var pieceworkWorkerModel = await _context.PieceworkWorkerModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pieceworkWorkerModel == null)
            {
                return NotFound();
            }

            return View(pieceworkWorkerModel);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PieceworkWorkerModel == null)
            {
                return Problem("Entity set 'WorkersContext.PieceworkWorkerModel'  is null.");
            }
            var pieceworkWorkerModel = await _context.PieceworkWorkerModel.FindAsync(id);
            if (pieceworkWorkerModel != null)
            {
                _context.PieceworkWorkerModel.Remove(pieceworkWorkerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool PieceworkWorkerModelExists(int id)
        {
          return _context.PieceworkWorkerModel.Any(e => e.Id == id);
        }
    }
}
