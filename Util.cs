using CSInputs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroForSols
{
    internal class Util
    {

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
            Thread.Sleep(5000);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            Thread.Sleep(4500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Down);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.D, KeyFlags.Up);
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            Thread.Sleep(3000);
        } //CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return,KeyFlags.Down);


        public static void Collect1()
        {
            Thread.Sleep(250);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Down);
            Thread.Sleep(3900);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.A, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Down);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(700);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.W, KeyFlags.Up);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);

        } //CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return,KeyFlags.Down);

        public static void Collect2()
        {
            Thread.Sleep(500);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Down);
            Thread.Sleep(4800);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.S, KeyFlags.Up);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);
            Thread.Sleep(100);
            CSInputs.SendInput.Keyboard.Send(KeyboardKeys.F);

        } //CSInputs.SendInput.Keyboard.Send(KeyboardKeys.Return,KeyFlags.Down);
    }
}
