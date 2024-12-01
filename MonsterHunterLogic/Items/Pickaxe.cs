using MonsterHunterLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Items
{
    public class Pickaxe
    {
        public Pickaxe() { }

        public bool Use()
        {
            //get random percentage break the pickaxe
            return RandomNumber.Next(1, 4) != 1;
        }
    }
}
