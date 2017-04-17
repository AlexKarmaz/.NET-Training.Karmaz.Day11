using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.CUI
{
    class Watch
    {
        public void Register(Clock time)
        {
            if (time == null)
                throw new ArgumentNullException(nameof(time));
            time.FinishCountdown += WatchCall;
        }

        public void UnRegister(Clock time)
        {
            if (time == null)
                throw new ArgumentNullException(nameof(time));
            time.FinishCountdown -= WatchCall;
        }

        void WatchCall(object sender, EventArgs e)
        {
            Console.WriteLine("Watch call");
        }
    }

    class AlarmClock
    {

        public void Register(Clock watch)
        {
            if (watch == null)
                throw new ArgumentNullException(nameof(watch));
            watch.FinishCountdown += AlarmCall;
        }

        public void UnRegister(Clock watch)
        {
            if (watch == null)
                throw new ArgumentNullException(nameof(watch));
            watch.FinishCountdown -= AlarmCall;
        }

        void AlarmCall(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm call");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Watch watch = new Watch();
            AlarmClock alarm = new AlarmClock();

            Console.WriteLine("First call");
            clock.StartCount(5);
            Thread.Sleep(6);
            watch.Register(clock);

            Console.WriteLine("\nSecond call");
            clock.StartCount(5);
            Thread.Sleep(6);
            alarm.Register(clock);

            Console.WriteLine("\nThird call");
            clock.StartCount(5);
            Thread.Sleep(6);
            watch.UnRegister(clock);

            Console.WriteLine("\nFourth call");
            clock.StartCount(5);
            Thread.Sleep(6);
            alarm.UnRegister(clock);

            Console.WriteLine("\nFifth call");
            clock.StartCount(5);
            Thread.Sleep(6);
            watch.UnRegister(clock);
            alarm.Register(clock);

            Console.WriteLine("\nSixth call");
            clock.StartCount(5);
            Thread.Sleep(6);
            alarm.UnRegister(clock);
            Console.ReadLine();
        }
    }
}
