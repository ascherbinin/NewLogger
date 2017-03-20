using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Uva.Log;

namespace DummyTest
{
    class Program
    {
        static readonly String TAG = "Program";
        static private int counter = 0;

        static void Main(string[] args)
        {

            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            myTimer.Interval = 1000; // 1000 ms is one second
            myTimer.Start();

            Console.ReadLine();
        }

        public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber > 0 && randomNumber < 10)
            {
                Log.Critical(TAG, "Critical error message:" + counter);
            }
            else if (randomNumber > 10 && randomNumber < 20)
            {
                Log.Error(TAG, "Error message:" + counter);
            }
            else if (randomNumber > 20 && randomNumber < 40)
            {
                Log.Warning(TAG, "Warning message:" + counter);
            }
            else if (randomNumber > 40 && randomNumber < 65)
            {
                Log.Info(TAG, "Information message:" + counter);
            }
            else
            {
                Log.Trace(TAG, "Trace message:" + counter);
            }
            counter++;
        }
    }
}
