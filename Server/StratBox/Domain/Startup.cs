using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Startup
    {
        public virtual int PlayerId { get; set; }
        public virtual List<Unit> Unit { get; set; }
    }
}
