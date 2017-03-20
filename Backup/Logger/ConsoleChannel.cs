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
    public override void HandleMessage(Message message)
    {
      Console.Out.WriteLine(message.Text);
    }
  }
}
