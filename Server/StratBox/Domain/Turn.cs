using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Turn
    {
        public virtual int PlayerId { get; set; }
        public virtual int Action { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual string TargetLocation { get; set; }
    }
}
