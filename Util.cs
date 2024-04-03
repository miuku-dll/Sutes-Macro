using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSInputs;
using CSInputs.Enums;
using DiscordRPC;
using DiscordRPC.Logging;
using main;
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

        private static bool crafting = false;

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

        

        public static void MoveToStella()
        {
            Console.WriteLine("Focusing on Roblox process...");
            Focus();
            Thread.Sleep(1000);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);

            ResetPos();
            Console.WriteLine("Resetting X axis...");
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(5000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            Console.WriteLine("Moving to stellas dungeon...");
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(9000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1450);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(3700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(3500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(2000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(2000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);

            Console.WriteLine("Entering crafting menu...");

            var simulator = new EventSimulator();

            int i = 1;
            for (; ; )
            {
                simulator.SimulateMouseWheel(
                    rotation: 420,
                    direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                    type: MouseWheelScrollType.UnitScroll
                ); // UnitScroll by default
                Thread.Sleep(10);
                i++;
                if (i > 30)
                    break;
            }

            simulator.SimulateMouseWheel(
                        rotation: -420,
                        direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                        type: MouseWheelScrollType.UnitScroll
                    ); // UnitScroll by default
            Thread.Sleep(200);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Arrived at Stellas crafting menu...");
        }




        public static void GildedCraft()
        {
            var simulator = new EventSimulator();
            Focus();
            Thread.Sleep(1000);

        startcraft:
            if (crafting)
            {
                Console.WriteLine("Resetting store position");
                simulator.SimulateMouseMovement(334, 889);
                Thread.Sleep(50);
                simulator.SimulateMouseMovement(477, 897);
                simulator.SimulateMousePress(MouseButton.Button1);
                simulator.SimulateMouseRelease(MouseButton.Button1);
                Thread.Sleep(1200);

                int i = 1;
                for (; ; )
                {
                    simulator.SimulateMouseWheel(
                        rotation: 420,
                        direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                        type: MouseWheelScrollType.UnitScroll
                    ); // UnitScroll by default
                    Thread.Sleep(200);
                    i++;
                    if (i > 4)
                        break;
                }

                Thread.Sleep(2000);
                for (; ; )
                {
                    simulator.SimulateMouseWheel(
                        rotation: -420,
                        direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                        type: MouseWheelScrollType.UnitScroll
                    ); // UnitScroll by default
                    Thread.Sleep(200);
                    i++;
                    if (i > 8)
                        break;
                }

                i = 1;

                Console.WriteLine("Starting Gilded coin crafting...");
                for (; ; )
                {
                    simulator.SimulateMouseMovement(334, 889);
                    Thread.Sleep(50);
                    simulator.SimulateMouseMovement(477, 897);
                    Thread.Sleep(500);

                    simulator.SimulateMouseMovement(1200, 447);
                    Thread.Sleep(50);
                    simulator.SimulateMouseMovement(1247, 447);

                    simulator.SimulateMousePress(MouseButton.Button1);
                    simulator.SimulateMouseRelease(MouseButton.Button1);
                    Thread.Sleep(50);
                    simulator.SimulateMouseMovement(1148, 691);
                    Thread.Sleep(50);
                    simulator.SimulateMouseMovement(1037, 690);
                    Thread.Sleep(50);
                    simulator.SimulateMousePress(MouseButton.Button1);
                    simulator.SimulateMouseRelease(MouseButton.Button1);
                    Thread.Sleep(100);
                    Console.WriteLine("Crafted " + i);
                    i++;
                    if (i > 5)
                        break;
                }
                Console.WriteLine("Done crafting Gilded coins");
                Thread.Sleep(1000);
                Console.WriteLine("Closing store...");
                simulator.SimulateMouseMovement(338, 61);
                Thread.Sleep(50);
                simulator.SimulateMouseMovement(385, 69);
                Thread.Sleep(50);
                simulator.SimulateMousePress(MouseButton.Button1);
                simulator.SimulateMouseRelease(MouseButton.Button1);
                Console.WriteLine("Gilded coin crafting completed");
                Thread.Sleep(1000);
            }
            else
            {
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);

                Console.WriteLine("Resetting postion for crafting.");
                WebhookResetCharacter();
                ResetPos();
                Console.WriteLine("Done.");
                Thread.Sleep(500);
                WebhookJack();
                Console.WriteLine("Moving to Jake's Workshop.");

                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
                Thread.Sleep(2000);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
                Thread.Sleep(4000);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
                CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
                Thread.Sleep(4000);
                simulator.SimulateMouseMovement(570, 910);
                simulator.SimulateMouseMovement(571, 911);
                Thread.Sleep(1000);
                simulator.SimulateMousePress(MouseButton.Button1);
                simulator.SimulateMouseRelease(MouseButton.Button1);
                Console.WriteLine("Crafting...");

                crafting = true;
                goto startcraft;
            }
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
           
            for (; ; )
            {
                Focus();
                int i = 1;
                for (; ; )
                {
                    Movement.CollectAll();
                    Console.WriteLine("Loop Done");
                    RobloxRunning();
                    i++;
                    if (i > 30) // Collects 30 times and reconnects to roblox
                        break;
                }

                Process[] pArry = Process.GetProcesses();

                foreach (Process p in pArry)
                {
                    string s = p.ProcessName;
                    s = s.ToLower();
                    if (s.CompareTo("RobloxPlayerBeta") == 0)
                    {
                        p.Kill();
                        KillingProcessHook();
                    }
                }
                Console.WriteLine("Killed roblox for rejoining...");
                RobloxRunning();
            }
        }

        public static void Rotate()
        {

            for (; ; )
            {
                Focus();
                int i = 1;
                for (; ; )
                {
                    Movement.CollectAll();
                    Console.WriteLine("Loop Done");
                    RobloxRunning();
                    i++;
                    if (i > 10) // Collects 10 times, crafts and reconnects to roblox
                        break;
                }

                GildedCraft();

                Process[] pArry = Process.GetProcesses();

                foreach (Process p in pArry)
                {
                    string s = p.ProcessName;
                    s = s.ToLower();
                    if (s.CompareTo("RobloxPlayerBeta") == 0)
                    {
                        p.Kill();
                        KillingProcessHook();
                    }
                }
                Console.WriteLine("Killed roblox for rejoining...");
                RobloxRunning();
            }
        }

        public static void AutoCraft()
        {
            Focus();
            GildedCraft();
            RobloxRunning();

        }
        private static bool Heav = false;

        public static void AutoCraftHeavenly()
        {
            MenuCollection menus = MenuGenerator.CreateMenuCollection();

            if (Heav)
            {
                Heav = false;


            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Make sure you have (Divinus, Gilded, Exotic) on auto equip via game");

                Thread.Sleep(2000);
                Focus();
                Console.WriteLine("Starting auto collect...");
                Util.AutoCollect();
                Console.WriteLine("Moving to auto craft...");

                Heav = true;
            }
        }



























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

        public static void ResetKeys()
        {
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
        }
    }
}
