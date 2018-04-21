using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public abstract class MappableObject
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
        public virtual int InitPoints { get; set; }
        public virtual int CurrentPoints { get; set; }
        public virtual int InitDefense { get; set; }
        public virtual int CurrentDefense { get; set; }
        public virtual int PlayerId { get; set; }
    }
}
