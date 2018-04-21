using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Inventory
    {
        public virtual int Id { get; set; }
        public virtual List<Unit> Units { get; set; }
    }
}
