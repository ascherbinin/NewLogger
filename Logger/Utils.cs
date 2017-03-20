using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Log
{
    /// <summary>
    /// Static utils class, for helps methods
    /// </summary>
    public static class Utils
    {
        public static string FormatedMessage(Message msg, string format)
        {
            var tmpMsg = "";
            string[] formatParam = format.Split(new Char[] { ' ' });
            foreach (var item in formatParam)
            {
                switch (item)
                {
                    case "dt":
                        tmpMsg += msg.CreationTime;
                        break;
                    case "pID":
                        tmpMsg += msg.ProcessId;
                        break;
                    case "tn":
                        tmpMsg += msg.ThreadName;
                        break;
                    case "pri":
                        tmpMsg += msg.Priority;
                        break;
                    case "src":
                        tmpMsg += msg.Source;
                        break;
                    case "txt":
                        tmpMsg += msg.Text;
                        break;
                    default:
                        tmpMsg += msg.Text;
                        break;
                }
                tmpMsg += " ";
            }
            return tmpMsg;
        }
    }
}
