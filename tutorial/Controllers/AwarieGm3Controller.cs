using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tutorial.Exceptions;
using tutorial.Models;
using tutorial.Services;

namespace tutorial.Controllers
{

    public class AwarieGm3Controller : Controller
    {


        private readonly dbContext _context;
        private readonly IFilteringDataServices _filteringServices;
        private readonly ILogger<AwarieGm3Controller> _logger;

        public AwarieGm3Controller(dbContext context, IFilteringDataServices filteringDataService, ILogger<AwarieGm3Controller> logger)
        {
            _context = context;
            _filteringServices = filteringDataService;
            _logger = logger;
        }

        // GET: AwarieGm3            
        public async Task<IActionResult> Index(string id)
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            awarieGm3 = _filteringServices.FilterDataForCurrentDowntime(id, awarieGm3);

            return View(await awarieGm3.ToListAsync());
        }

        public async Task<IActionResult> Display(string id, DateTime start, DateTime stop, string sekcja)//, DateTime start, DateTime stop
        {
            var awarieGm3 =  from m in _context.AwarieGm3s
                            select m;

            awarieGm3 = _filteringServices.FilterData(start, stop, id, sekcja, awarieGm3);

            return View(await awarieGm3.ToListAsync());
        }

        // GET: AwarieGm3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                throw new NotFoundException("Downtime not found (id == null)");
            }

            var awarieGm3 = await _context.AwarieGm3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awarieGm3 == null)
            {
                throw new NotFoundException($"Downtime with id: {id} not found");
            }

            return View(awarieGm3);
        }

        // GET: AwarieGm3/Create
        public IActionResult Create()
        {
            _logger.LogWarning($"Restaurant CREATE action invoked by: {@User.Identity.Name}");

            if (!@User.Identity.Name.Contains("12281209"))
            {
                throw new UnauthorizedException($"{@User.Identity.Name}Nie masz dostepu do tworzenia nowych awarii!");
            }

            return View();
        }

        // POST: AwarieGm3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sekcja,Stacja,Opis,Komentarz,Min,CzasStart,CzasStop")] AwarieGm3 awarieGm3)
        {
            if (ModelState.IsValid)
            {
                awarieGm3.Komentarz += "###Stworzono przez: " + User.Identity.Name;
                _context.Add(awarieGm3);               
                await _context.SaveChangesAsync();
                _logger.LogWarning($"Restaurant with Id:{awarieGm3.Id} is created by: {@User.Identity.Name}");
                return RedirectToAction(nameof(Index));
            }
            return View(awarieGm3);
        }

        // GET: AwarieGm3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogWarning($"Restaurant with Id: {id} EDIT action invoked by: {@User.Identity.Name}");
            if (id == null)
            {
                return NotFound();
            }

            var awarieGm3 = await _context.AwarieGm3s.FindAsync(id);
            if (awarieGm3 == null)
            {
                return NotFound();
            }
            DateTime? dt = DateTime.Now;
            TimeSpan? interval = (dt - awarieGm3.CzasStop);

            if (interval.Value.TotalHours > 24)
            {
                return NotFound("Nie możesz edytować awarii, która była powyżej 24h temu!");
            }

            return View(awarieGm3);
        }

        // POST: AwarieGm3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sekcja,Stacja,Opis,Komentarz,Min,CzasStart,CzasStop")] AwarieGm3 awarieGm3)
        {
            if (id != awarieGm3.Id)
            {
                throw new NotFoundException("Id not found (id != awarieGm3.Id)");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    awarieGm3.Komentarz += "###Edytowano przez: " + User.Identity.Name;
                    _context.Update(awarieGm3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwarieGm3Exists(awarieGm3.Id))
                    {
                        throw new NotFoundException("Id not found (id != awarieGm3.Id)");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(awarieGm3);
        }



        // GET: AwarieGm3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _logger.LogWarning($"Restaurant with Id: {id} DELETE action invoked by: {@User.Identity.Name}");

            if (!@User.Identity.Name.Contains("12281209"))
            {               
                throw new UnauthorizedException($"{@User.Identity.Name}Nie masz dostepu do usuwania awarii!");
            }

            if (id == null)
            {
                throw new NotFoundException("Id not found (id == null");
            }

            var awarieGm3 = await _context.AwarieGm3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awarieGm3 == null)
            {
                throw new NotFoundException("Downtime not found (db record is null");
            }
            DateTime? dt = DateTime.Now;
            TimeSpan? interval = (dt - awarieGm3.CzasStop);

            if (interval.Value.TotalHours > 24)
            {
                throw new NotFoundException("Nie możesz usuwać awarii, która była powyżej 24h temu!");
            }

            return View(awarieGm3);
        }

        // POST: AwarieGm3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awarieGm3 = await _context.AwarieGm3s.FindAsync(id);
            _context.AwarieGm3s.Remove(awarieGm3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwarieGm3Exists(int id)
        {
            return _context.AwarieGm3s.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Szukaj(string id)
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                awarieGm3 = awarieGm3.Where(s => s.CzasStart.ToString().Contains(id));
            }

            return View(await awarieGm3.ToListAsync());
        }


        //  [ChildActionOnly]
        public async Task<IActionResult> DisplayTop(string id, DateTime start, DateTime stop, string sekcja)//, DateTime start, DateTime stop
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            awarieGm3 = _filteringServices.FilterData(start, stop, id, sekcja, awarieGm3);

            var totalMinutesModel = _filteringServices.FilterToTopDowntime(awarieGm3);

            return View(totalMinutesModel);
            // return View(await awarieGm3.ToListAsync());
        }

        public async Task<IActionResult> DetailsTops(string id)
        {
            if (id == null || !id.Contains('q'))
            {
                throw new NotFoundException("Id is null or no separator 'q' in request");
            }

            var stringId = id.Split('q');

            List<int?> idList = stringId.Take(stringId.Length-1).Select(x => (int?)int.Parse(x) ).ToList();

            if (idList == null)
            {
                throw new NotFoundException("No Ids found");
            }

            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            var list = new List<AwarieGm3>();

            foreach (var item in idList)
            {
                AwarieGm3 Model = new AwarieGm3();
                Model = awarieGm3
                    .FirstOrDefault(m => m.Id == item.Value);
                list.Add(Model);
            }


            if (list == null)
            {
                throw new NotFoundException("No valid downtimes found");
            }

            return View(list);
        }


    }

}
