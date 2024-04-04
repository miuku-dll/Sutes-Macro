using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpHook;
using CSInputs;
using MacroForSols;
using DeclarativeConsoleMenu;

namespace MacroForSols
{
    internal class Worker
    {

        public static void Starting()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();

            Util.Focus();
            Util.WebhookStart();
            Console.Clear();
            Console.WriteLine("Starting...");
            for (; ; )
            { 
                string Check2Path = File.ReadAllText(@".\Config\Status2.txt");
                string CheckPath = File.ReadAllText(@".\Config\Status1.txt");
                if (CheckPath.Contains("On", StringComparison.OrdinalIgnoreCase))
                {
                    int i = 1;
                    for (; ; )
                    {
                        Util.AutoCollect();
                        i++;
                        if (i > 4)
                            break;
                    }
                }
                else if (Check2Path.Contains("On", StringComparison.OrdinalIgnoreCase))
                {
                    Util.AutoCraft();
                }
                else
                {
                    Console.WriteLine("No features turned on...");
                    Thread.Sleep(500);
                    Console.WriteLine("returning to null status...");
                    Thread.Sleep(500);
                    Console.Clear();
                    menus.ShowMenu(1);
                }
             }
        }
    }
}
