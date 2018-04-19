using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._11_12.Models
{
    public class Clock
    {
        private Thread _timerThread;

        public event EventHandler TimeOut;

        /// <summary>
        /// Start the timer.
        /// </summary>
        /// <param name="seconds"> Duration of timer.</param>
        public void Start(int seconds)
        {
            this._timerThread = new Thread(() =>
            {
                Thread.Sleep(seconds);
                TimeOut(this, null);
            });
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        public void Stop()
        {
            this._timerThread?.Suspend();
        }
    }
}