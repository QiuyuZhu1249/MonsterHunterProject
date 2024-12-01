using MonsterHunterLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Items
{
    public class Potion
    {
        public PotionType Type { get; private set; }

        public Potion()
        {
            //get random numbers to confirm the type of potions
            int roll = RandomNumber.Next(1, 7);
            switch (roll)
            {
                case 1:
                    Type = PotionType.Poisoned;
                    break;
                case 2:
                case 3:
                    Type = PotionType.Speed;
                    break;
                case 4:
                case 5:
                    Type = PotionType.Invisibility;
                    break;
                case 6:
                    Type = PotionType.Strength;
                    break;
                default:
                    Type = PotionType.Strength;
                    break;
            }
        }
    }
}
