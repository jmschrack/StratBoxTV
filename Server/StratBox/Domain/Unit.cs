using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Unit:MappableObject
    {
        public virtual int Chassis { get; set; }
        public virtual int Armor { get; set; }
        public virtual int Weapon { get; set; }
        public virtual int Sensor { get; set; }
        public virtual int Range { get; set; }
        public virtual int Attack { get; set; }
        public virtual int Speed { get; set; }
        public virtual int IsActive { get; set; }
        public virtual List<Dice> Dice { get; set; }
    }
}
