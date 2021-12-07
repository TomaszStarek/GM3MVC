using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tutorial.Models;

namespace tutorial.Data
{

    public class AppDbContex :DbContext
    {

        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {

        }

   //     public DbSet<Item> Items { get; set; }
        public int Id { get; set; }
        public string Sekcja { get; set; }
        public string Stacja { get; set; }
        public string Opis { get; set; }
        public string Komentarz { get; set; }
        public string Min { get; set; }
        public DateTime? CzasStart { get; set; }
        public DateTime? CzasStop { get; set; }





    }
}
