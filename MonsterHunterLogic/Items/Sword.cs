using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterHunterLogic.Utilities;

namespace MonsterHunterLogic.Items
{
    public class Sword
    {
        public int Strength { get; private set; }

        public Sword()
        {
            // get random ATK 4-9
            Strength = RandomNumber.Next(4, 10); 
        }

        public bool Use()
        {
            //get random percentage break the sword
            return RandomNumber.Next(1, 6) != 1;
        }
    }
}
