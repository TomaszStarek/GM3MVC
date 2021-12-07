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

            if (!String.IsNullOrEmpty(id))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= DateTime.Now.AddHours(-8))
                                .Where(s => s.Sekcja.Contains(id));
            }
            else
            {
                awarieGm3 = awarieGm3
                                .Where(s => s.CzasStart >= DateTime.Now.AddHours(-8));

            }
            return View(await awarieGm3.ToListAsync());

        }


        public async Task<IActionResult> Display(string id, DateTime start, DateTime stop, string asp)//, DateTime start, DateTime stop
        {
            var awarieGm3 = from m in _context.AwarieGm3s
                            select m;

            if ((start == stop) && (start.Year < 2021))
            {
                ViewBag.Message = "Podaj poprawny przedział czasu!";
                start = DateTime.Now.AddDays(-1).Date;
                stop = DateTime.Now.AddDays(1).Date;
            }             

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

            if (interval.Value.TotalHours > 8)
            {
                return NotFound("Nie możesz edytować awarii, która była powyżej 8h temu!");
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

            if ((start == stop) && (start.Year < 2021))
            {
                ViewBag.Message = "Podaj poprawny przedział czasu!";
                start = DateTime.Now.AddDays(-1).Date;
                stop = DateTime.Now.AddDays(1).Date;
            }

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

            

            var totalMinutesModel = new List<TopDowntimeModel>( 1000 );
            //{
            //    //Tag = queryCustomersByCity.Select(x => x.Tag).ToList(),
            //    //Count = queryCustomersByCity.Select(x => x.Count).ToList(),
            //    //MinutesList = queryCustomersByCity.Select(x => x.TotalMinutes).ToList(),
            //};

            //var awarieGm3 = from m in _context.AwarieGm3s
            //                select m;

            var queryCustomersByCity =
                from cust in awarieGm3.AsEnumerable()//_context.AwarieGm3s.AsEnumerable()
                where cust.Sekcja.ToUpper().Contains("M0")
                group cust by cust.Opis into g
                let list = g.ToList()
                select new
                {
                    Sekcja = list.Select(x => x.Sekcja),
                    Stacja = list.Select(x => x.Stacja),
                    Tag = g.Key,
                    Count = list.Count,
                    TotalMinutes = list.Select(x => {

                        var minuty = 0;
                        if (Int32.TryParse(x.Min, out minuty))
                            return minuty;
                        else
                            return 0;
                    }).Sum()                   
                 //   ChargeSum = list.AsEnumerable().Sum(g => Convert.ToInt32(g.Min))   // Int32.Parse(x.Min))
                };


            foreach (var item in queryCustomersByCity)
            {
                TopDowntimeModel Model = new TopDowntimeModel();

                Model.Sekcja = item.Sekcja.FirstOrDefault();
                Model.Stacja = item.Stacja.FirstOrDefault();
                Model.Tag = item.Tag; 
                Model.TotalMinutes = item.TotalMinutes;
                Model.Count = item.Count;

                totalMinutesModel.Add(Model);

                //totalMinutesModel[i].Tag = item.Tag;
                //totalMinutesModel[i].TotalMinutes = item.TotalMinutes;
                //totalMinutesModel[i].Count = item.Count;
                //i++;
            }

            // totalMinutesModel = queryCustomersByCity.ToList();

            //  statsModel.TotalAmount = _context.AwarieGm3s.//.Sum(o => o.Amount);  where m.Stacja != "bob" 
            return View(totalMinutesModel);
           // return View(await awarieGm3.ToListAsync());
        }


    }
}
