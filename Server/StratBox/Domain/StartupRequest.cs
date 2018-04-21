using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class StartupRequest
    {
        public virtual string SessionKey { get; set; }
        public virtual Startup Startup { get; set; }
    }
}
