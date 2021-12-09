using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial.Models;

namespace tutorial.Services
{
    public interface IFilteringDataServices
    {
        public IQueryable<AwarieGm3> FilterData(DateTime start, DateTime stop, string id, string sekcja, IQueryable<AwarieGm3> awarieGm3);

        public List<TopDowntimeModel> FilterToTopDowntime(IQueryable<AwarieGm3> awarieGm3);

        public IQueryable<AwarieGm3> FilterDataForCurrentDowntime(string id, IQueryable<AwarieGm3> awarieGm3);
    }
}
