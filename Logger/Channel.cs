using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Log
{
    /// <summary>
    /// An abstract handler of log messages.
    /// </summary>
    public abstract class Channel
    {
        /// <summary>
        /// Logs the given message to the channel. Must be implemented by subclasses.
        /// </summary>
        /// <param name="message">the given message</param>
        public abstract void HandleMessage(Message message);
        /// <summary>
        /// Does whatever is necessary to close the channel. The default implementation does nothing.
        /// </summary>
        public void Close()
        {

        }
    }
}
