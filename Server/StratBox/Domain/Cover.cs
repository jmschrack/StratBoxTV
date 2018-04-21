using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class Cover:MappableObject
    {
        public virtual int InitDefense { get; set; }
        public virtual int CurrentDefense { get; set; }


    }
}
