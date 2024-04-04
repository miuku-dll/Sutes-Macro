using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using CSInputs.Enums;
using SharpHook;
using SharpHook.Native;

namespace MacroForSols
{
    internal class Util // This class handles almost everything from Movement to Webhooks
    {

        
        string PrivateServer = File.ReadAllText(@"./Config/PrivateServer.txt");

        public static void RobloxRunning()
        {
            var robloxRunning = Process.GetProcessesByName("RobloxPlayerBeta").Any();
            if (robloxRunning)
            {
                Console.Clear();
                Console.WriteLine("Roblox is still running...");
            }
            else
            {
                Console.WriteLine("Reconnecting to your server...");
                ReconnectingRoblox();
                StartPrivateServer();

            }
        }

        // Focusing on RobloxPlayerBeta process
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void Focus()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            try
            {
                Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
                SetForegroundWindow(processes[0].MainWindowHandle);
            }
            catch
            {
                Console.WriteLine("Roblox is not running");
                Thread.Sleep(1000);
                Console.WriteLine("Returning to Idle...");
                Thread.Sleep(1000);
                Console.Clear();
                menus.ShowMenu(2);
                Console.ReadKey();
            }
        }

        public static void sendDiscordWebhook(string URL, string escapedjson)
        {
            try
            {
                var wr = WebRequest.Create(URL);
                wr.ContentType = "application/json";
                wr.Method = "POST";
                using (var sw = new StreamWriter(wr.GetRequestStream()))
                    sw.Write(escapedjson);
                wr.GetResponse();
            }
            catch
            {
                Console.WriteLine("No webhook url set...");
            }
        }

        

        public static void Reset()
        {
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Escape);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.R);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return);
            Thread.Sleep(1000);
        }

        public static void ResetPos()
        {
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Escape);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.R);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return);
            Console.WriteLine("Reset Character");
            WebhookReset();
            Thread.Sleep(3000);
            Console.WriteLine("Moving to lava to reset position");
            WebhookResetCharacter();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(4500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(500);
        }



        




        

        public static void SetWebhook()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            Console.Write("Webhook: ");
            var webhooklink = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(@"./config/Webhook.txt"))
            {
                writer.WriteLine(webhooklink);
            }
            Console.Clear();
            string Webhook1 = File.ReadAllText(@"./Config/Webhook.txt");
            Thread.Sleep(1000);
            Console.WriteLine("Your webhook: " + Webhook1);
            Thread.Sleep(1000);
            Console.Clear();
            menus.ShowMenu(3);
            Console.ReadKey();
        }

        public static void SetPrivateServer()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            Console.Write("Private Server Address: ");
            var webhooklink = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(@"./config/PrivateServer.txt"))
            {
                writer.WriteLine(webhooklink);
            }
            Console.Clear();
            string Webhook1 = File.ReadAllText(@"./Config/PrivateServer.txt");
            Thread.Sleep(1000);
            Console.WriteLine("Your Private Server: " + Webhook1);
            Thread.Sleep(1000);
            Console.Clear();
            menus.ShowMenu(3);
            Console.ReadKey();
        }

        public static void Keybind()
        {
            Console.Write("Abort Keybind: (Currently Not Working) ");
            var KeybindKey = Console.ReadLine();
        }

        public static void AutoCollect()
        {
           Focus();
               
           Movement.CollectAll();
           Console.WriteLine("Loop Done");
           RobloxRunning();
        
            
        }

        public static void AutoCraft()
        {
            Focus();
            Movement.GildedCraft();
            Console.WriteLine("Loop Done");
            RobloxRunning();

        }
        private static bool Heav = false;

        public static void StartPrivateServer()
        {
            string PrivateServer = File.ReadAllText(@"./Config/PrivateServer.txt");

            try
            {
                try
                {
                    Process.Start(
                        new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = "vivaldi",
                            Arguments = PrivateServer
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
                                Arguments = PrivateServer
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
                                    Arguments = PrivateServer
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
                        }
                    }
                }

                int i = 1;
                for (; ; )
                {
                    Console.WriteLine(" Launching Private Server.");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" Launching Private Server..");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" Launching Private Server...");
                    Thread.Sleep(500);
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
                    if (i > 4)
                        break;
                }
                Console.WriteLine(" We're all set!");
                Thread.Sleep(1000);
                Console.Clear();
            }
            catch
            {
                Console.Clear();
            }
        }



        public static void KillingProcessHook()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Killing roblox to reconnect...\", \"title\":\"\", \"color\":25424691}]  }"
            );
        }

        public static void ReconnectingRoblox()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Reconnecting to private server...\", \"title\":\"\", \"color\":7221041}]  }"
            );
        }

        public static void WebhookReset()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Reset Character\", \"title\":\"\", \"color\":16723502}]  }"
            );
        }

        public static void WebhookCollecting()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Collecting Items\", \"title\":\"\", \"color\":1184274}]  }"
            );
        }

        public static void WebhookResetCharacter()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Resetting Character Position\", \"title\":\"\", \"color\":2039583}]  }"
            );
        }

        public static void WebhookMovingToArea()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Moving to next area\", \"title\":\"\", \"color\":6284940}]  }"
            );
        }

        public static void WebhookJack()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Moving to Jake's Workshop\", \"title\":\"\", \"color\":16774912}]  }"
            );
        }

        public static void WebhookStart()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Starting macro...\", \"title\":\"\", \"color\":6618908}]  }"
            );
        }
        public static void WebhookLaunch()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"./config/Webhook.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Launching software...\", \"title\":\"\", \"color\":6618908}]  }"
            );
        }
        public static void ResetKeys()
        {
            var simulator = new EventSimulator(); // For mouse hooks
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            simulator.SimulateMouseRelease(MouseButton.Button1);
        }

        public static void SetStatus1()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            Console.Clear();
            Console.WriteLine("Enable Auto Collect?");

            Console.Write("Y/N: ");
            var Result = Console.ReadLine();

            if (Result.ToString() == "y")
            {
                Console.WriteLine("Turning On...");

                var Path = "on";
                using (FileStream fs = File.Create(@".\Config\Status1.txt"))
                {
                    char[] value = Path.ToCharArray();
                    fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                }
                Console.Clear();
                menus.ShowMenu(2);
            }
            else if (Result.ToString() == "n")
            {
                ;
                var Path = "off";
                using (FileStream fs = File.Create(@".\Config\Status1.txt"))
                {
                    char[] value = Path.ToCharArray();
                    fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                }
                Console.Clear();
                menus.ShowMenu(2);
            }
            else
            {
                Console.WriteLine("Type either Y or N, state remains...");
            }
        }

        public static void SetStatus2()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();
            Console.Clear();
            Console.WriteLine("Enable Auto Craft?");

            Console.Write("Y/N: ");
            var Result = Console.ReadLine();

            if (Result.ToString() == "y")
            {
                Console.WriteLine("Turning On...");

                var Path = "on";
                using (FileStream fs = File.Create(@".\Config\Status2.txt"))
                {
                    char[] value = Path.ToCharArray();
                    fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                }
                Console.Clear();
                menus.ShowMenu(2);
            }
            else if (Result.ToString() == "n")
            {
                ;
                var Path = "off";
                using (FileStream fs = File.Create(@".\Config\Status2.txt"))
                {
                    char[] value = Path.ToCharArray();
                    fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                }
                Console.Clear();
                menus.ShowMenu(2);
            }
            else
            {
                Console.WriteLine("Type either Y or N, state remains...");
            }
        }
    }
}
