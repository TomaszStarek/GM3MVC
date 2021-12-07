using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace tutorial.Models
{
    public partial class AwarieGm3
    {

        public int Id { get; set; }

        [StringLength(10)]
        [Required]
        public string Sekcja { get; set; }

        [StringLength(50)]
        [Required]
        public string Stacja { get; set; }

        [Required]
        public string Opis { get; set; }
        public string Komentarz { get; set; }

        [RegularExpression(@"^[Z0-9 ]*$")]
        [StringLength(10)]
        [Required]
        public string Min { get; set; }

        [Required]
        public DateTime? CzasStart { get; set; }

        [Required]
        public DateTime? CzasStop { get; set; }


    }
}
