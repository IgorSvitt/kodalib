using System;
using System.Collections.Generic;

namespace Kodalib.Data.Entities
{
    public partial class FilmsActor
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
    }
}
