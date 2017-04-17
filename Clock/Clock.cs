using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains a mechanism that provides an event for subscriber classes
    /// </summary>
    public class Clock
    {
        /// <summary>
        /// Delegate that is called when the time ends
        /// </summary>
        public event EventHandler FinishCountdown = delegate { };

        /// <summary>
        /// Called after timeout
        /// </summary>
        protected virtual void OnFinishCountdown()
        {
            var finishCountdown = FinishCountdown;
            finishCountdown?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Starts the clock with a countdown
        /// </summary>
        /// <param name="milliseconds">Time entered by the user</param>
        public void StartCount(int milliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed.Milliseconds < milliseconds) ;
            OnFinishCountdown();
        }
    }
}
