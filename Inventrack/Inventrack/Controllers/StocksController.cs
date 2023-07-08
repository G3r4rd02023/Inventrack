using Inventrack.Data;
using Inventrack.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Inventrack.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StocksController : Controller
	{
		private readonly DataContext _context;

		public StocksController(DataContext context)
		{
			_context = context;
		}

		// GET: Stocks
		public async Task<IActionResult> Index()
		{
			return View(await _context.Stocks.ToListAsync());
		}

		// GET: Stocks/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Stocks == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks
				.FirstOrDefaultAsync(m => m.Id == id);
			if (stock == null)
			{
				return NotFound();
			}

			return View(stock);
		}

		// GET: Stocks/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Stocks/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description,StockQuantity,Price,AdmissionDate,ExpirationDate,ImageUrl")] Stock stock)
		{
			if (ModelState.IsValid)
			{
				_context.Add(stock);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(stock);
		}

		// GET: Stocks/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Stocks == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks.FindAsync(id);
			if (stock == null)
			{
				return NotFound();
			}
			return View(stock);
		}

		// POST: Stocks/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StockQuantity,Price,AdmissionDate,ExpirationDate,ImageUrl")] Stock stock)
		{
			if (id != stock.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(stock);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StockExists(stock.Id))
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
			return View(stock);
		}

		// GET: Stocks/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Stocks == null)
			{
				return NotFound();
			}

			var stock = await _context.Stocks
				.FirstOrDefaultAsync(m => m.Id == id);
			if (stock == null)
			{
				return NotFound();
			}

			return View(stock);
		}

		// POST: Stocks/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Stocks == null)
			{
				return Problem("Entity set 'DataContext.Stocks'  is null.");
			}
			var stock = await _context.Stocks.FindAsync(id);
			if (stock != null)
			{
				_context.Stocks.Remove(stock);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StockExists(int id)
		{
			return _context.Stocks.Any(e => e.Id == id);
		}
	}
}
