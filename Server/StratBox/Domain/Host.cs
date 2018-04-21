using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Host:BasePlayer
    {
        public virtual List<Cover> Cover { get; set; }
        public virtual List<Flag> Flags { get; set; }

    }
}
