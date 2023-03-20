using System;
using System.Collections.Generic;

namespace Kodalib.Data.Entities
{
    public partial class FilmsCountry
    {
        public int CountryId { get; set; }
        public int FilmId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
    }
}
