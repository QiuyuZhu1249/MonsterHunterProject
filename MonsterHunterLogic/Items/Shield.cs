using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterLogic.Utilities;

namespace MonsterHunterLogic.Items
{
    public class Shield
    {
        public int Defense { get; private set; }

        public Shield()
        {
            //get random DEF
            Defense = RandomNumber.Next(3, 7); 
        }

        public bool Use()
        {
            //get random percentage break the shield 
            return RandomNumber.Next(1, 5) != 1;
        }
    }
}
