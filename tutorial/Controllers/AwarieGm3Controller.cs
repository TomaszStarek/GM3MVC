using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tutorial.Models;


namespace tutorial.Controllers
{
    public class AwarieGm3Controller : Controller
    {


        private readonly dbContext _context;

        public AwarieGm3Controller(dbContext context)
        {
            _context = context;
        }

        // GET: AwarieGm3       
        public async Task<IActionResult> Index(string id)
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            DateTime now = DateTime.Now;
            var timeToadd = 0;

            timeToadd = -1 * now.Hour %8 - 2;
            if (timeToadd <= -8)
                timeToadd += 8;



            if (!String.IsNullOrEmpty(id))
            {
                awarieGm3 = awarieGm3
                               .Where(s =>
                                           s.CzasStart >= DateTime.Now.AddHours(timeToadd)
                                           || s.CzasStop >= DateTime.Now.AddHours(timeToadd))
                                .Where(s => s.Sekcja.Contains(id));
            }
            else
            {
                awarieGm3 = awarieGm3
                                .Where(s =>
                                           s.CzasStart >= DateTime.Now.AddHours(timeToadd)
                                           || s.CzasStop >= DateTime.Now.AddHours(timeToadd));

            }
            return View(await awarieGm3.ToListAsync());

        }


        public async Task<IActionResult> Display(string id, DateTime start, DateTime stop, string asp)//, DateTime start, DateTime stop
        {
            var awarieGm3 =  from m in _context.AwarieGm3s
                            select m;

            if (start.Year < 2021)
                start = DateTime.Now.AddDays(-1).Date;
            if (stop.Year < 2021)
                stop = DateTime.Now.AddDays(0).Date;

            start = start.AddHours(6);
            stop = stop.AddHours(6);

            if (!String.IsNullOrEmpty(asp) && !id.Contains("WSZYSTKIE") && id.Contains("search"))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= start)
                                .Where(s => s.CzasStart <= stop)
                                .Where(s => s.Sekcja.Contains(asp));
            }
            else if (!String.IsNullOrEmpty(id) && !id.Contains("WSZYSTKIE") && !id.Contains("search"))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= start)
                                .Where(s => s.CzasStart <= stop)
                                .Where(s => s.Sekcja.Contains(id));
            }
            else
            {
                awarieGm3 = awarieGm3
                                .Where(s => s.CzasStart >= start && s.CzasStart <= stop);
            }

            return View(await awarieGm3.ToListAsync());
        }

        // GET: AwarieGm3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awarieGm3 = await _context.AwarieGm3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awarieGm3 == null)
            {
                return NotFound();
            }

            return View(awarieGm3);
        }

        // GET: AwarieGm3/Create
        public IActionResult Create()
        {
            if (!@User.Identity.Name.Contains("2281209"))
            {
                return Unauthorized("Nie masz dostępu");
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
                return RedirectToAction(nameof(Index));
            }
            return View(awarieGm3);
        }

        // GET: AwarieGm3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
                return NotFound();
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
                        return NotFound();
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

            if (!@User.Identity.Name.Contains("2281209"))
            {
                return Unauthorized("Nie masz dostępu");  
            }

            if (id == null)
            {
                return NotFound();
            }

            var awarieGm3 = await _context.AwarieGm3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awarieGm3 == null)
            {
                return NotFound();
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
        public async Task<IActionResult> DisplayTop(string id, DateTime start, DateTime stop, string asp)//, DateTime start, DateTime stop
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            if (start.Year < 2021)
                start = DateTime.Now.AddDays(-1).Date;
            if (stop.Year < 2021)
                stop = DateTime.Now.AddDays(0).Date;

            start = start.AddHours(6);
            stop = stop.AddHours(6);
            if (!String.IsNullOrEmpty(asp) && !id.Contains("WSZYSTKIE") && id.Contains("search"))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= start)
                                .Where(s => s.CzasStart <= stop)
                                .Where(s => s.Sekcja.Contains(asp));
            }
            else if (!String.IsNullOrEmpty(id) && !id.Contains("WSZYSTKIE") && !id.Contains("search"))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= start)
                                .Where(s => s.CzasStart <= stop)
                                .Where(s => s.Sekcja.Contains(id));
            }
            else
            {
                awarieGm3 = awarieGm3
                                .Where(s => s.CzasStart >= start && s.CzasStart <= stop);
            }

            var totalMinutesModel = new List<TopDowntimeModel>();

            var queryByOccurence =
                from query in awarieGm3.AsEnumerable()//_context.AwarieGm3s.AsEnumerable()
                                                      //   where cust.Sekcja.ToUpper().Contains("M0")
                group query by new
                {
                    query.Sekcja,
                    query.Stacja,
                    query.Opis,
                } into g
                let list = g.ToList()
                select new
                {
                    Ids = list.Select(x => x.Id).ToList(),
                    Sekcja = g.Key.Sekcja,
                    Stacja = g.Key.Stacja,
                    Tag = g.Key.Opis,
                    Count = list.Count,
                    TotalMinutes = list.Select(x =>
                    {

                        var minuty = 0;
                        if (Int32.TryParse(x.Min, out minuty))
                            return minuty;
                        else
                            return 0;
                    }).Sum()
                };

            
            foreach (var item in queryByOccurence)
            {
                TopDowntimeModel Model = new TopDowntimeModel();
                Model.Ids = item.Ids.ToList();
                Model.Sekcja = item.Sekcja;
                Model.Stacja = item.Stacja;
                Model.Opis = item.Tag;
                Model.TotalMinutes = item.TotalMinutes;
                Model.LiczbaWystapien = item.Count;

                totalMinutesModel.Add(Model);
            }

            return View(totalMinutesModel);
            // return View(await awarieGm3.ToListAsync());
        }

        public async Task<IActionResult> DetailsTops(string id)
        {
            if (id == null || !id.Contains('q'))
            {
                return NotFound();
            }

            var stringId = id.Split('q');

            List<int?> idList = stringId.Take(stringId.Length-1).Select(x => (int?)int.Parse(x) ).ToList();

            if (idList == null)
            {
                return NotFound();
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
                return NotFound();
            }

            return View(list);
        }


    }
}
