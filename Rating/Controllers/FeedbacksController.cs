using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rating.Data;
using Rating.Models;
using Rating.Services;

namespace Rating.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly RatingContext _context;
        private readonly IRatingService _service;
        public FeedbacksController(IRatingService service, RatingContext context)
        {
            _context = context;
            _service = service;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            ViewBag.AVG = await _service.computeAVG();
            return View(await _context.Feedback.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FirstOrDefaultAsync(m => m.username == id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewBag.AVG = await _service.computeAVG();
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.user_exist = false;
            ViewBag.AVG = await _service.computeAVG();
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("username,rate,description,time")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(feedback);
                ViewBag.AVG = await _service.computeAVG();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SearchContent content)
        {
            if (string.IsNullOrEmpty(content.Search))
            {
                return RedirectToAction(nameof(Index));
            }
            var result = await _service.searchByNameOrDescription(content);
            ViewBag.AVG = await _service.computeAVG();
            if (result.Count > 0)
            {
                return View(nameof(Index), result);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewBag.AVG = await _service.computeAVG();
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("username,rate,description,time")] Feedback feedback)
        {
            if (id != feedback.username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(feedback);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.username))
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
            ViewBag.AVG = await _service.computeAVG();
            return View(feedback);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewBag.AVG = await _service.computeAVG();
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _Delete(string id)
        {
            if (_service.GetAll == null)
            {
                return Problem("Entity set 'RatingContext.Feedback'  is null.");
            }
            var feedback = _service.GetSpecific(id);
            if (feedback != null)
            {
                await _service.Remove(feedback.username);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(string id)
        {
          return (_context.Feedback?.Any(e => e.username == id)).GetValueOrDefault();
        }
    }
}
