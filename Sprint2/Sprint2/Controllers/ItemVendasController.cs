using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint2.Data;
using Sprint2.Models;

namespace Sprint2.Controllers
{
    public class ItemVendasController : Controller
    {

        private readonly MeuAppContext _context;

        public ItemVendasController(MeuAppContext context)
        {
            _context = context;
        }

        // GET: ItemVendas
        public async Task<IActionResult> Index(string? id)
        {
            if (id != null)
            {
                ViewData["ItemVendaId"] = id;
            }

            var meuAppContext = _context.ItemVendas.Where(i => i.VendaId.ToString() == id).Include(i => i.Produtos).Include(i => i.Vendas);
            return View(await meuAppContext.ToListAsync());
        }

        // GET: ItemVendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas
                .Include(i => i.Produtos)
                .Include(i => i.Vendas)
                .FirstOrDefaultAsync(m => m.ItemVendaId == id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            return View(itemVenda);
        }

        // GET: ItemVendas/Create
        public IActionResult Create(string? id)
        {
            ViewData["ItemVendaId"] = id;
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId");
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId");
            return View();
        }

        // POST: ItemVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemVendaId,VendaId,ProdutoId,Quantidade")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                itemVenda.ItemVendaId = Guid.NewGuid();
                _context.Add(itemVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Vendas", new { id = itemVenda.VendaId });
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // GET: ItemVendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas.FindAsync(id);
            if (itemVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // POST: ItemVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemVendaId,VendaId,ProdutoId,Quantidade")] ItemVenda itemVenda)
        {
            if (id != itemVenda.ItemVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemVendaExists(itemVenda.ItemVendaId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "VendaId", itemVenda.VendaId);
            return View(itemVenda);
        }

        // GET: ItemVendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVenda = await _context.ItemVendas
                .Include(i => i.Produtos)
                .Include(i => i.Vendas)
                .FirstOrDefaultAsync(m => m.ItemVendaId == id);
            if (itemVenda == null)
            {
                return NotFound();
            }

            return View(itemVenda);
        }

        // POST: ItemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ItemVendas == null)
            {
                return Problem("Entity set 'MeuAppContext.ItemVendas'  is null.");
            }
            var itemVenda = await _context.ItemVendas.FindAsync(id);
            if (itemVenda != null)
            {
                _context.ItemVendas.Remove(itemVenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemVendaExists(Guid id)
        {
          return (_context.ItemVendas?.Any(e => e.ItemVendaId == id)).GetValueOrDefault();
        }
    }
}
