using CSInputs.Enums;
using SharpHook.Native;
using SharpHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroForSols
{
    internal class Movement
    {
        public static void CollectAll()
        {
            var simulator = new EventSimulator(); // For mouse hooks
            Util.Focus(); // Focus on Roblox process
            Util.ResetKeys();

            Console.WriteLine("Resetting camera...");
            simulator.SimulateMouseMovement(962, 598);
            Thread.Sleep(500);

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

            for (; ; )
            {
                simulator.SimulateMouseWheel(
                    rotation: -420,
                    direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                    type: MouseWheelScrollType.UnitScroll
                ); // UnitScroll by default
                Thread.Sleep(10);
                i++;
                if (i > 33)
                    break;
            }
            Thread.Sleep(500);

            // Resetting character
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Escape);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.R);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return);
            Console.WriteLine("Reset character");
            Util.WebhookReset();
            Thread.Sleep(2500);

            // Resetting location
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(1300);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(50);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(5000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

            // Moving to corner
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(5300);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(300);

            // Resetting character
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Escape);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.R);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return);
            Console.WriteLine("Reset character");
            Util.WebhookReset();
            Thread.Sleep(2500);

            // Resetting location
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);

            // Moving to house's tree
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(600);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(600);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(1500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(300);

            // Moving into house
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(600);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(300);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.I, KeyFlags.Down);
            Thread.Sleep(50);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.I, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

            Util.ResetKeys();

            Console.WriteLine("Resetting camera...");
            simulator.SimulateMouseMovement(962, 598);
            Thread.Sleep(500);

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

            for (; ; )
            {
                simulator.SimulateMouseWheel(
                    rotation: -420,
                    direction: MouseWheelScrollDirection.Vertical, // Vertical by default
                    type: MouseWheelScrollType.UnitScroll
                ); // UnitScroll by default
                Thread.Sleep(10);
                i++;
                if (i > 33)
                    break;
            }
            Thread.Sleep(500);

            // Resetting character
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Escape);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.R);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return);
            Console.WriteLine("Reset character");
            Util.WebhookReset();
            Thread.Sleep(2500);

            // Resetting location
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(1000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(10);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);


            // Moving to tree
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(200);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(4000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

            // Moving to the other tree

            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(200);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(5500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(400);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

            // Moving to the mountain
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(4400);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Down);
            Thread.Sleep(4200);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Space, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(2000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);

            // Collecting items
            Thread.Sleep(100);
            Console.WriteLine("Collecting Items");
            Util.WebhookCollecting();
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Console.WriteLine("Done collecting items");
            Thread.Sleep(100);

        }
    }
}
