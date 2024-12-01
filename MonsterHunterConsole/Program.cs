using MonsterHunterConsole.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.Start();
        }
    }
}
