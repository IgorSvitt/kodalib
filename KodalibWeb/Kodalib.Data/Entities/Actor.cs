using System;
using System.Collections.Generic;

namespace Kodalib.Data.Entities
{
    public partial class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
    }
}
