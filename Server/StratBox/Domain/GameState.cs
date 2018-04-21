using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratBox.Domain
{
    public class GameState
    {
        public virtual int Id { get; set; }
        public virtual string RoomKey { get; set; }
        public virtual int CurrentRound { get; set; }
        public virtual int PlayerTotal { get; set; }
        public virtual int MaxUnits { get; set; }
        public virtual int MinUnits { get; set; }
        public virtual int? CurrentPlayer { get; set; }
        public virtual int? CurrentUnit { get; set; }
        public virtual List<BasePlayer>Players{ get; set; }

}
}
