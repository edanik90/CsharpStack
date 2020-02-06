using System;
using Phone.Models;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia nokia = new Nokia("N83", 76, "AT&T", "Trolololo-lololo");
            Galaxy samsung = new Galaxy("S10", 45, "Verizon", "Ring ring ring");
            nokia.DisplayInfo();
            Console.WriteLine(nokia.Ring());
            Console.WriteLine(nokia.Unlock());

            samsung.DisplayInfo();
            Console.WriteLine(samsung.Ring());
            Console.WriteLine(samsung.Unlock());
        }
    }
}
