using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Models
{
    public class Hunter : Character
    {
        public string Name { get; set; }
        public int Score { get; private set; }

        // Write setting to the hunter HP, ATK, DEF
        public Hunter(int x, int y, string name)
            : base(x, y, 30, 7, 4) 
        {
            Name = name.Length <= 20 ? name : name.Substring(0, 20);
            FreezeTime = 1000; 
            Score = 0;
        }

        public void AddScore(int points) => Score += points;

        public override bool Move(int newX, int newY)
        {
            // Movement
            X = newX;
            Y = newY;
            return true;
        }
    }
}
