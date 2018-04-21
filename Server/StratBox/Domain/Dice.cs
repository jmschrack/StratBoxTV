using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Dice
    {
        public virtual int Sides { get; set; }
        public virtual int Value { get; set; }
    }
}
