using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Klicker
{
    public partial class Klicker
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        System.Timers.Timer myTimer;
        int counter = 0;
        int n = 100;

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        public Klicker()
        {
            myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(this.clickMouse);
            myTimer.Interval = 50;
            myTimer.Enabled = true;
            
            Console.WriteLine("Any key cancels the klicking...");
            Console.WriteLine("Time " + DateTime.Now.ToString("o"));
            myTimer.Start();


            // Console.WriteLine("Time " + DateTime.Now.ToString("o"));
            // DateTime tick = DateTime.Now;
            // for (int i = 0; i < n; i++)
            // {
            //     mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            // }
            // DateTime tock = DateTime.Now;
            // Console.WriteLine("Time " + DateTime.Now.ToString("o"));
            // Console.WriteLine("CPS: " + (n / (tock - tick).TotalMilliseconds * 1000 ));

            Console.ReadKey();

        }

        public void clickMouse(Object source, ElapsedEventArgs e)
        {
            counter++;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            if (counter > n)
            {
                Console.WriteLine("Time " + DateTime.Now.ToString("o"));
                myTimer.Stop();
                Console.ReadKey();
                Environment.Exit(0);
            }
            // Console.WriteLine( "Counter: " + counter);
        }

    }
}
