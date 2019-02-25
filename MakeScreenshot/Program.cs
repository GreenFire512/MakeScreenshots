using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeScreenshot
{
    class Program
    {
        static void Main(string[] args)
        {
            Screenshot scr = new Screenshot();
            if (args[0] == "-a")
            {
                scr.TakeActiveScreen();
            }
            else
            {
                scr.TakeFullScreen();
            }
            
        }
    }
}
