using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using CSInputs.ReadInput;
using MacroForSols;
using System.Windows.Input;
using SharpHook;
using SharpHook.Testing;
using SharpHook.Native;


namespace main
{
class Program
{
    
    static private bool _isExecutedFirst = false;
    static private bool skip = false;
    static private bool running = false;



        public static void GoodMorning(String[] options)
        {

            Console.WriteLine("  /$$$$$$              /$$              /$$              /$$      /$$                                        ");
            Console.WriteLine(" /$$__  $$            | $$             | $/             | $$$    /$$$                                        ");
            Console.WriteLine("| $$  \\__/ /$$   /$$ /$$$$$$    /$$$$$$|_//$$$$$$$      | $$$$  /$$$$  /$$$$$$   /$$$$$$$  /$$$$$$   /$$$$$$ ");
            Console.WriteLine("|  $$$$$$ | $$  | $$|_  $$_/   /$$__  $$ /$$_____/      | $$ $$/$$ $$ |____  $$ /$$_____/ /$$__  $$ /$$__  $$");
            Console.WriteLine(" \\____  $$| $$  | $$  | $$    | $$$$$$$$|  $$$$$$       | $$  $$$| $$  /$$$$$$$| $$      | $$  \\__/| $$  \\ $$");
            Console.WriteLine(" /$$  \\ $$| $$  | $$  | $$ /$$| $$_____/ \\____  $$      | $$\\  $ | $$ /$$__  $$| $$      | $$      | $$  | $$");
            Console.WriteLine("|  $$$$$$/|  $$$$$$/  |  $$$$/|  $$$$$$$ /$$$$$$$/      | $$ \\/  | $$|  $$$$$$$|  $$$$$$$| $$      |  $$$$$$/");
            Console.WriteLine(" \\______/  \\______/    \\___/   \\_______/|_______/       |__/     |__/ \\_______/ \\_______/|__/       \\______/ ");


            Thread.Sleep(4000);
            Console.Clear();

        Address:

            SetLink:
                string CheckPath = File.ReadAllText(@"C:\temp\PrivateServer.txt");
                if (CheckPath.Contains("roblox.com/share", StringComparison.OrdinalIgnoreCase))
                {
                Console.Clear();
                Console.WriteLine("Existing link found (Link can be changed in settings)");
                Thread.Sleep(2000);
                goto CorrectAddress;
                }
                else
                {
                    Console.Write("Private Server Address: ");
                    var Path = Console.ReadLine(); // Too lazy to find out myself for now
                    Console.Clear();

                    using (StreamWriter writer = new StreamWriter(@"C:\temp\PrivateServer.txt"))
                    {
                        writer.WriteLine(Path);
                    }
                    Console.Clear();

                    string RobloxPath = File.ReadAllText(@"C:\temp\PrivateServer.txt");
                    Thread.Sleep(200);
                    Console.WriteLine("Private Server Address: " + RobloxPath);
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto SetLink;
                }
            
            


    CorrectAddress:



        Console.WriteLine("Attempting to Launch");

        var robloxRunning = Process.GetProcessesByName("roblox").Any();
        if (robloxRunning)
        {
            Console.WriteLine("Launching roblox");

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Roblox Already Running!");
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Would you like to launch Roblox again? Y/N");

            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key.ToString() == "y")
            {
                Console.WriteLine("Launching roblox...");
            }
            else
            {
                Console.Clear();
                return;
            }



        }


            string RobloxPath1 = File.ReadAllText(@"C:\temp\PrivateServer.txt");

        try
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {

                    UseShellExecute = true,
                    FileName = "vivaldi",
                    Arguments = RobloxPath1
                });

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("vivaldi Not Found");
                Thread.Sleep(1000);
                try
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = "chrome",
                        Arguments = RobloxPath1
                    });
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("chrome Not Found");
                    Thread.Sleep(1000);
                    try
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = "edge",
                            Arguments = RobloxPath1
                        });

                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Edge Not Found");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Please open a browser! Compatibility can be seen on our Github page.");
                        goto Address;
                    }
                }
            }


            int i = 1;
            for (; ; )
            {
                Console.WriteLine(" Launching Private Server.");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(" Launching Private Server..");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(" Launching Private Server...");
                Thread.Sleep(1000);
                Console.Clear();
                i++;
                if (i > 4)
                    break;
            }

            for (; ; )
            {
                Console.WriteLine(" Loading.");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(" Loading..");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(" Loading...");
                Thread.Sleep(500);
                Console.Clear();
                i++;
                if (i > 6)
                    break;
            }
            Console.WriteLine(" We're all set!");
            Thread.Sleep(1000);
            Console.Clear();

        }
        catch
        {

            Console.Clear();
            goto Address;
        }
    }







    public static void Main(string[] args)
    {
        MenuCollection menus = MenuGenerator.CreateMenuCollection();
        if (skip)
        {
            skip = false;
                goto Skipped;
        }

        else
        {

        }

        if (!_isExecutedFirst)
        {
            _isExecutedFirst = true;

            GoodMorning(args);

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Failed to launch.");
        }

       Skipped:
        menus.ShowMenu(1);
        Console.ReadKey();

    }

 

        public static void option2()
    {
        running = true;
        Console.WriteLine(running);
        Console.Clear();

        Program.Focus();
        Thread.Sleep(1000);

        Util.GildedCraft();
        Console.Clear();
        running = false;
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void Focus()
    {
        Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
        SetForegroundWindow(processes[0].MainWindowHandle);
    }

        public static void option1()
    {
        running = true;
        Console.WriteLine(running);
        Console.Clear();

        Program.Focus();
        Thread.Sleep(1000);

        try
        {
                Util.AutoCollect();


                Console.WriteLine("Loop ended");
        }
        catch
        {
            Console.WriteLine("Something went wrong...");
            Thread.Sleep(1000);
            Console.Clear();
        }
        running = false;
    }


    

    }

}

