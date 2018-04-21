using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Player:BasePlayer
    {
        public virtual List<Unit> Units { get; set; }
        public virtual List<Flag> Flags { get; set; }

    }
}
