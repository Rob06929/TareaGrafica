using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace Proyecto_OpenTK
{
    class Program
    {
        static void Main(string[] args)
        {
            Game windows = new Game(1024, 720);
            windows.Run(1.0 / 60.0);
        }
    }
}
