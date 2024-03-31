using System;
using System.IO;
using System.Net;
using System.Windows.Shapes;
using CSInputs;
using CSInputs.Enums;
using main;
using SharpHook;
using SharpHook.Native;

namespace MacroForSols
{
    internal class Util // This class handles almost everything from Movement to Webhooks
    {
        string Webhook1 = File.ReadAllText(@"./Config/Webhook.txt");

        public static void sendDiscordWebhook(string URL, string escapedjson)
        {
            var wr = WebRequest.Create(URL);
            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(escapedjson);
            wr.GetResponse();
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
        } //CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return,KeyFlags.Down);

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
            Thread.Sleep(2500);
            Console.WriteLine("Moving to lava to reset position");
            WebhookResetCharacter();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(4500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(500);
        } //CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return,KeyFlags.Down);

        public static void Collect12()
        {
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);

            ResetPos();
            Console.WriteLine("Moving to collection area");
            WebhookMovingToArea();
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(3900);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Console.WriteLine("Collecting items");
            WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(300);

            Console.WriteLine("Moving to next area");
            Thread.Sleep(300);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(4800);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(300);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
        }

        public static void Collect3()
        {
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);

            ResetPos();
            Console.WriteLine("Moving to collection area");
            WebhookMovingToArea();
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(2000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(3000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);

            Console.WriteLine("Collecting items");
            WebhookCollecting();
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting area...");
            Thread.Sleep(300);
            Console.WriteLine("Moving to next area");
            WebhookMovingToArea();

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(100);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(800);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);

            Console.WriteLine("Collecting items");
            WebhookCollecting();

            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting area...");

            Thread.Sleep(300);
            Console.WriteLine("Moving to next area");
            WebhookMovingToArea();

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
        }

        public static void Collect4()
        {
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
            ResetPos();
            Console.WriteLine("Moving to collection area");
            WebhookCollecting();
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(4000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(3000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(300);
            Console.WriteLine("Collecting items");
            WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);

            Console.WriteLine("Done collecting area...");
            Thread.Sleep(300);
            Console.WriteLine("Moving to next area");
            WebhookMovingToArea();

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(600);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(5500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(400);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            Thread.Sleep(300);
            Console.WriteLine("Collecting items");
            WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);

            Console.WriteLine("Done collecting area...");
            Thread.Sleep(300);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
        }

        public static void Collect5()
        {
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);

            ResetPos();
            Console.WriteLine("Moving to collection area");
            WebhookMovingToArea();
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(10000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(200);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(3000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            Console.WriteLine("Collecting items");
            WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(300);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Shift, KeyFlags.Up);
        }

        public static void GildedCraft()
        {
            var simulator = new EventSimulator();

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

        public static void Webhook()
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

        public static void Keybind()
        {
            Console.Write("Abort Keybind: (Currently Not Working) ");
            var KeybindKey = Console.ReadLine();
        }

        public static void AutoCollect()
        {
            for (; ; )
            {
                MacroForSols.Util.Collect12();
                MacroForSols.Util.Collect3();
                MacroForSols.Util.Collect4();
                MacroForSols.Util.Collect5();
                Console.WriteLine("Loop Done");
            }
        }

        public static void WebhookReset()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"C:\temp\sutesconfig.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Reset Character\", \"title\":\"\", \"color\":16723502}]  }"
            );
        }

        public static void WebhookCollecting()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"C:\temp\sutesconfig.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Collecting Items\", \"title\":\"\", \"color\":1184274}]  }"
            );
        }

        public static void WebhookResetCharacter()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"C:\temp\sutesconfig.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Resetting Character Position\", \"title\":\"\", \"color\":2039583}]  }"
            );
        }

        public static void WebhookMovingToArea()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"C:\temp\sutesconfig.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Moving to next area\", \"title\":\"\", \"color\":6284940}]  }"
            );
        }

        public static void WebhookJack()
        {
            sendDiscordWebhook(
                File.ReadAllText(@"C:\temp\sutesconfig.txt"),
                "{\"username\": \"Sute's Macro\",\"embeds\":[    {\"description\":\"Moving to Jake's Workshop\", \"title\":\"\", \"color\":16774912}]  }"
            );
        }
    }
}
