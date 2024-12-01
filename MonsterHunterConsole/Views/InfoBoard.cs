using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterConsole.Views
{
    public static class InfoBoard
    {
        public static void DisplayInfo(string message)
        {
            Console.WriteLine($"[信息] {message}");
        }
    }
}
