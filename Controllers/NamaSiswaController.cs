
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using belajarASPDB.Models;
using belajarASPDB.Data;
using Microsoft.AspNetCore.Authorization;

public class NamaSiswaController : Controller
{
    private readonly ApplicationDbContext _context;

    public NamaSiswaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: NAMASISWAMODELS
    [Authorize]
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NamaSiswaModel.ToListAsync());
    }

    // GET: NAMASISWAMODELS/Details/5
    [Authorize]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var namasiswamodel = await _context.NamaSiswaModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (namasiswamodel == null)
        {
            return NotFound();
        }

        return View(namasiswamodel);
    }

    // GET: NAMASISWAMODELS/Create
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    // POST: NAMASISWAMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nama,Alamat")] NamaSiswaModel namasiswamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(namasiswamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(namasiswamodel);
    }

    // GET: NAMASISWAMODELS/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var namasiswamodel = await _context.NamaSiswaModel.FindAsync(id);
        if (namasiswamodel == null)
        {
            return NotFound();
        }
        return View(namasiswamodel);
    }

    // POST: NAMASISWAMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nama,Alamat")] NamaSiswaModel namasiswamodel)
    {
        if (id != namasiswamodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(namasiswamodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NamaSiswaModelExists(namasiswamodel.Id))
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
        return View(namasiswamodel);
    }

    // GET: NAMASISWAMODELS/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var namasiswamodel = await _context.NamaSiswaModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (namasiswamodel == null)
        {
            return NotFound();
        }

        return View(namasiswamodel);
    }

    // POST: NAMASISWAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var namasiswamodel = await _context.NamaSiswaModel.FindAsync(id);
        if (namasiswamodel != null)
        {
            _context.NamaSiswaModel.Remove(namasiswamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Cari()
    {
        return View();
    }

    public async Task<IActionResult> HasilPencarian(string KataKunci)
    {
        return View("Index", await _context.NamaSiswaModel.Where(j => j.Nama.Contains(KataKunci)).ToListAsync());
    }

    private bool NamaSiswaModelExists(int? id)
    {
        return _context.NamaSiswaModel.Any(e => e.Id == id);
    }
}
