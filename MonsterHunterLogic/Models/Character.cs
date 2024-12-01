using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterLogic.Models
{
    public abstract class Character
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int Strength { get; private set; }
        public int Armor { get; private set; }
        public int FreezeTime { get; protected set; }

        protected Character(int x, int y, int maxHP, int strength, int armor)
        {
            X = x;
            Y = y;
            MaxHP = maxHP;
            CurrentHP = maxHP;
            Strength = strength;
            Armor = armor;
        }

        public abstract bool Move(int newX, int newY); 

        public bool IsDead() => CurrentHP <= 0;

        public void TakeDamage(int damage)
        {
            CurrentHP = Math.Max(0, CurrentHP - damage);
        }
    }
}
