using SharpHook.Logging;
using SharpHook.Reactive;
using SharpHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using SharpHook.Native;

namespace MacroForSols
{
    internal class GlobalHook
    {
        public static void Global()
        {
            var hook = new SimpleReactiveGlobalHook(TaskPoolScheduler.Default);

            hook.KeyReleased.Subscribe(e => OnKeyReleased(e, hook));

            hook.Run();

            static void OnKeyReleased(KeyboardHookEventArgs e, IReactiveGlobalHook hook)
            {
                if (e.Data.KeyCode == KeyCode.VcF1)
                {
                    hook.Dispose();
                    Console.Write("Detected");
                    return;
                }
            }
        }
    }
}
