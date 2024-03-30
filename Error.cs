using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroForSols;

namespace MacroForSols
{
    internal class Error
    {

        public static void E101() // Easier Re-using
        {
            Console.Clear();
            Console.WriteLine("You dont have chrome installed, Restarting...");
            Thread.Sleep(3000);
            Console.Clear();
        }

        public static void E102() // Easier Re-using
        {
            Console.Clear();
            Console.WriteLine("Your address was not valid...");
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("Please make sure you entered a private server Invite...");
            Thread.Sleep(3000);
            Console.Clear();
            
        }

        public static void E103() // Easier Re-using
        {
            Console.WriteLine("Roblox Is already running, please close it and try again.");
            Thread.Sleep(5000);
            Console.Clear();

        }
    }
}
