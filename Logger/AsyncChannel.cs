using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;

namespace Uva.Log
{
    /// <summary>
    /// A log channel that prints text from query by background thread
    /// </summary>
    class AsyncChannel : Channel
    {
        private BackgroundWorker bw = new BackgroundWorker();
        private Queue<Message> messages = new Queue<Message>();
        private object lockObj = new Object();
        private string _format = "txt";

        public override void HandleMessage(Message message)
        {
            lock(lockObj)
            {
                messages.Enqueue(message);
            }
        }

        public AsyncChannel()
        {
            InitializeWorker();
        }

        /// <summary>
        /// Constructor with format for output, allowed params dt - DateTime, pid - process id, tn - thread name, pri - priority, src - source, txt - message text
        /// </summary>
        public AsyncChannel(string format)
        {
            _format = format;
            InitializeWorker();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!bw.CancellationPending)
            {
                for (int i = 1; (i <= messages.Count); i++)
                {
                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        try
                        {
                            lock (lockObj)
                            {
                               Console.Out.WriteLine("BW: "+ Utils.FormatedMessage(messages.Dequeue(), _format));
                            }
                        }
                        catch (Exception)
                        {
                            Debug.WriteLine("empty");
                        }
                        
                    }
                }
                Thread.Sleep(5000);
            }
            
        }

        //Test methods
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                Console.WriteLine("Canceled!");
            }

            else if (!(e.Error == null))
            {
                Console.WriteLine("Error: " + e.Error.Message);
            }

            else
            {
                Console.WriteLine("Done!");
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage.ToString() + " % ");
        }

        private void InitializeWorker()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
    }
}
