using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial.Models;
using Microsoft.Extensions.Logging;

namespace tutorial.Services
{
    public class FilteringDataService : IFilteringDataServices
    {
        private readonly ILogger<FilteringDataService> _logger;
        public FilteringDataService(ILogger<FilteringDataService> logger)
        {
            _logger = logger;
        }
        public IQueryable<AwarieGm3> FilterData(DateTime start, DateTime stop, string id, string sekcja, IQueryable<AwarieGm3> awarieGm3)
        {

            if (start.Year < 2021)
                start = DateTime.Now.AddDays(-1).Date;
            if (stop.Year < 2021)
                stop = DateTime.Now.AddDays(0).Date;

            start = start.AddHours(6);
            stop = stop.AddHours(6);
            if (!String.IsNullOrEmpty(sekcja) && !id.Contains("WSZYSTKIE") && id.Contains("search"))
            {
                awarieGm3 = awarieGm3
                               .Where(s => s.CzasStart >= start)
                                .Where(s => s.CzasStart <= stop)
                                .Where(s => s.Sekcja.Contains(sekcja));
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

            return awarieGm3;
        }


        public List<TopDowntimeModel> FilterToTopDowntime(IQueryable<AwarieGm3> awarieGm3)
        {
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

            return totalMinutesModel;
        }

        public IQueryable<AwarieGm3> FilterDataForCurrentDowntime(string id, IQueryable<AwarieGm3> awarieGm3)
        {
            DateTime now = DateTime.Now;
            var timeToadd = 0;

            timeToadd = -1 * now.Hour % 8 - 2;
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
            return awarieGm3;
        }
    }
}
