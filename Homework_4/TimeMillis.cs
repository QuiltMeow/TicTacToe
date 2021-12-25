using System;
using System.Threading;
using System.Windows.Forms;

namespace Homework_4
{
    internal class TimeMillis
    {
        public static long currentTimeMillis()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static void wait(int ms, bool sleep = true)
        {
            long last = currentTimeMillis();
            while (last + ms > currentTimeMillis())
            {
                Application.DoEvents();
                if (sleep)
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}