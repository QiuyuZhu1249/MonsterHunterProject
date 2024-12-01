using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Utilities
{
    public class RandomNumber
    {
        private static readonly Random random = new Random();

        private RandomNumber() { }

        public static int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
