using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using MacroForSols;

class Program
{


    static private bool _isExecutedFirst = false;
    static private bool skip = false;
    static private bool running = false;



    public static void error101() // Easier Re-using
    {
        Console.WriteLine("Error, Restarting...");
        Thread.Sleep(3000);
        Console.Clear();
    }

    public static void printMenu(String[] options)
    {
        foreach (String option in options)
        {
            Console.WriteLine(option);
        }
        Console.Write("Choose your option : ");
    }


    public static void GoodMorning(String[] options)
    {


        Console.WriteLine("Good Morning Baby!");
        Thread.Sleep(2000);
        Console.Clear();
    Address:
        Console.Write("Private Server Address: ");
        var Path = Console.ReadLine(); // Too lazy to find out myself for now

        if (Path.Contains("roblox.com/share", StringComparison.OrdinalIgnoreCase))
        {
            goto CorrectAddress;
        }
        else
        {
            Error.E102();
            Console.WriteLine("Check your entered address: " + Path);
            Console.WriteLine(" ");
            goto Address;
        }

        Thread.Sleep(1000);
        Console.Clear();

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




        try
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {

                    UseShellExecute = true,
                    FileName = "vivaldi",
                    Arguments = Path
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
                        Arguments = Path
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
                            Arguments = Path
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

        if (skip)
        {
            skip = false;
            goto SKIPPED;
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


    SKIPPED:
        Console.WriteLine("Select a option");
        String[] options = {" 1- Option 1",
                            " 2- Option 2",
                            " 3- Option 3",
                            " 4- Option 4",
                            " 5- Exit",
                                };

        int option = 0;
        while (true)
        {
            printMenu(options);
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an integer value between 1 and " + options.Length);
                continue;
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                //Console.WriteLine(ex);
                continue;
            }
            switch (option)
            {
                case 1:
                    option1();
                    break;
                case 2:
                    option2();
                    break;
                case 3:
                    option3();
                    break;
                case 4:
                    option4();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter an integer value between 1 and " + options.Length);
                    break;
            }

        }
    }


    private static void option4()
    {
        Console.WriteLine("Executing option 4");
        Thread.Sleep(1000);
        Console.Clear();
    }

    private static void option3()
    {
        Console.WriteLine("Executing option 3");
        Thread.Sleep(1000);
        Console.Clear();
    }

    private static void option2()
    {
        Console.WriteLine("Executing option 2");
        Thread.Sleep(1000);
        Console.Clear();
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    private static void Focus()
    {
        Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
        SetForegroundWindow(processes[0].MainWindowHandle);
    }

    private static void option1()
    {
        running = true;
        Console.WriteLine(running);
        Console.Clear();

        Program.Focus();
        Thread.Sleep(1000);

        try
        {
            Console.WriteLine("Resetting...");
            MacroForSols.Util.ResetPos();
            Console.WriteLine("Done...");
            Console.WriteLine("Starting Collecting 1...");
            MacroForSols.Util.Collect1();
            Console.WriteLine("Done...");
            Console.WriteLine("Starting Collecting 2...");
            MacroForSols.Util.Collect2();
            Console.WriteLine("Done...");
            Thread.Sleep(2000);
            Console.Clear();
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


