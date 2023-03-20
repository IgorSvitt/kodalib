using System;
using System.Collections.Generic;

namespace Kodalib.Data.Entities
{
    public partial class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; } = null!;
        public int? DurationMinutes { get; set; }
        public short? Year { get; set; }
        public int? CashSuccess { get; set; }
        public DateTime DateCreation { get; set; }
        public string? Plot { get; set; }
    }
}
