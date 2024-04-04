using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DiscordRPC;
using DiscordRPC.Logging;
using MacroForSols;


namespace main
{
    class Program // Handles main functions
    {
        private static bool _isExecutedFirst = false;
        private static bool skip = false;
        private static bool running = false;

        public static DiscordRpcClient client;

        public void Initialize()
        {

            client = new DiscordRpcClient("1153674562437914634");

            client.Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            client.Initialize();

        }

        public static void GoodMorning(String[] options)
        {
            try
            {
                var PrivateServerFile = "./config/PrivateServer.txt";
                var WebhookLocation = "./config/Webhook.txt";
                var CollectStatus = "./config/Status1.txt";
                var CraftStatus = "./config/Status2.txt";

                if (!Directory.Exists("./config/"))
                {
                    // Try to create the Path.
                    DirectoryInfo di = Directory.CreateDirectory("./config");
                    Console.WriteLine("Path Created...");

                    var Path = "off"; // Too lazy to find out myself for now
                    using (FileStream fs = File.Create(@".\Config\Status1.txt"))
                    {
                        char[] value = Path.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                }
                else { }

                if (File.Exists(PrivateServerFile))
                {
                    goto Address;
                }
                else
                {
                    Console.WriteLine("Adding Files...");
                    using (FileStream fs = File.Create(PrivateServerFile))
                    {
                        char[] value = "".ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                    using (FileStream fs = File.Create(WebhookLocation))
                    {
                        char[] value = "".ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                    using (FileStream fs = File.Create(CollectStatus))
                    {
                        char[] value = "".ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                    using (FileStream fs = File.Create(CraftStatus))
                    {
                        char[] value = "".ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                }


                Console.WriteLine("Done Checking Folder...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            catch { }

        Address:
            Console.WriteLine(
                "  /$$$$$$              /$$              /$$              /$$      /$$                                        "
            );
            Console.WriteLine(
                " /$$__  $$            | $$             | $/             | $$$    /$$$                                        "
            );
            Console.WriteLine(
                "| $$  \\__/ /$$   /$$ /$$$$$$    /$$$$$$|_//$$$$$$$      | $$$$  /$$$$  /$$$$$$   /$$$$$$$  /$$$$$$   /$$$$$$ "
            );
            Console.WriteLine(
                "|  $$$$$$ | $$  | $$|_  $$_/   /$$__  $$ /$$_____/      | $$ $$/$$ $$ |____  $$ /$$_____/ /$$__  $$ /$$__  $$"
            );
            Console.WriteLine(
                " \\____  $$| $$  | $$  | $$    | $$$$$$$$|  $$$$$$       | $$  $$$| $$  /$$$$$$$| $$      | $$  \\__/| $$  \\ $$"
            );
            Console.WriteLine(
                " /$$  \\ $$| $$  | $$  | $$ /$$| $$_____/ \\____  $$      | $$\\  $ | $$ /$$__  $$| $$      | $$      | $$  | $$"
            );
            Console.WriteLine(
                "|  $$$$$$/|  $$$$$$/  |  $$$$/|  $$$$$$$ /$$$$$$$/      | $$ \\/  | $$|  $$$$$$$|  $$$$$$$| $$      |  $$$$$$/"
            );
            Console.WriteLine(
                " \\______/  \\______/    \\___/   \\_______/|_______/       |__/     |__/ \\_______/ \\_______/|__/       \\______/ "
            );

            Thread.Sleep(2500);
            Console.Clear();

        SetLink:
            string CheckPath = File.ReadAllText(@".\Config\PrivateServer.txt");
            if (CheckPath.Contains("roblox.com/share", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Existing link found (Link can be changed in settings)");
                Thread.Sleep(1000);
                goto CorrectAddress;
            }
            else
            {
                Console.Write("Private Server Address: ");
                var Path = Console.ReadLine(); // Too lazy to find out myself for now
                Console.Clear();

                try
                {
                    using (FileStream fs = File.Create(@".\Config\PrivateServer.txt"))
                    {
                        char[] value = Path.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                    }
                }
                catch { }

                if (CheckPath.Contains("roblox.com/share", StringComparison.OrdinalIgnoreCase))
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto SetLink;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Restarting Process...");
                    Thread.Sleep(250);
                    Console.Clear();
                    goto SetLink;
                }
            }

        CorrectAddress:

            Console.WriteLine("Attempting to Launch");

            var robloxRunning = Process.GetProcessesByName("RobloxPlayerBeta").Any();
            if (robloxRunning)
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
            else
            {
                Console.WriteLine("Launching roblox");
                
            }

            string RobloxPath1 = File.ReadAllText(@".\Config\PrivateServer.txt");

            try
            {
                try
                {
                    Process.Start(
                        new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = "vivaldi",
                            Arguments = RobloxPath1
                        }
                    );
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("vivaldi Not Found");
                    Thread.Sleep(1000);
                    try
                    {
                        Process.Start(
                            new ProcessStartInfo()
                            {
                                UseShellExecute = true,
                                FileName = "chrome",
                                Arguments = RobloxPath1
                            }
                        );
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("chrome Not Found");
                        Thread.Sleep(1000);
                        try
                        {
                            Process.Start(
                                new ProcessStartInfo()
                                {
                                    UseShellExecute = true,
                                    FileName = "edge",
                                    Arguments = RobloxPath1
                                }
                            );
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Edge Not Found");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine(
                                "Please open a browser! Compatibility can be seen on our Github page."
                            );
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
                    Console.WriteLine(" /////");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" //////////");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" ///////////////");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" ////////////////////");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" /////////////////////////");
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
            static void Update()
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "Sute's Macro",
                    State = "Running...",
                    Assets = new Assets()
                    {
                        LargeImageKey = "output-onlinepngtools_6_",
                        LargeImageText = "Sute's Macro - Sol's RNG",
                        SmallImageKey = "output-onlinepngtools_6_"
                    }
                });
            }
            
            try
            {
                Util.WebhookLaunch();
            }
            catch { }
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            if (skip)
            {
                skip = false;
                goto Skipped;
            }
            else { }

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
        
    }
}
