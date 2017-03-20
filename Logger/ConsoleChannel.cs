using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Log
{
    /// <summary>
    /// A log channel that prints text of a log messages into Console.Out.
    /// </summary>
    public class ConsoleChannel : Channel
    {
        private string _format = "txt";

        public override void HandleMessage(Message message)
        {
            Console.Out.WriteLine("CONSOLE: " + Utils.FormatedMessage(message, _format));
        }
        /// <summary>
        /// Constructor with format for output, allowed params dt - DateTime, pid - process id, tn - thread name, pri - priority, src - source, txt - message text
        /// </summary>
        public ConsoleChannel(string format)
        {
            _format = format;
        }

        public ConsoleChannel() { }
 
    }
}
