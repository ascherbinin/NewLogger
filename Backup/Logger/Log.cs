using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Log
{
  /// <summary>
  /// API for sending log output.
  /// <p>
  /// Generally, use the Info(), Debug(), Trace(), Warning(), Error(), Critical() methods.
  /// <b>Tip:</b> A good convention is to declare a FACILITY constant in your class:<br>
  /// <code>
  /// private static final String TAG = "MyClass";
  /// </code><br>
  /// and use that in subsequent calls to the log methods.
  /// <p>
  /// <b>Advanced:</b> An application uses static methods of the Log class to generate its
  /// log messages and send them on their way to their final destination,
  /// their final destination is a channel, to which Log passes on its messages.
  /// Furthermore, it has a log level, which is used for filtering messages based on their priority.
  /// Only messages with a priority equal to or higher than the specified level are passed on.<br>
  /// For example, if the level of a logger is set to WARNING, only messages with priority WARNING, ERROR, and CRITICAL will propagate.
  /// <p>
  /// <b>Configuration:</b><p>
  /// Use the setChannel() and getChannel() methods to set and access the destination channel.<br>
  /// Use the setLogLevel() and getLogLevel() methods to set and access the log level.<br>
  /// <p>
  /// <b><i>Default log configuration:</i></b><p>
  /// <li>Log level: Message.Severity.TRACE.</li>
  /// <li>Channel: new ConsoleChannel().</li>
  /// </summary>
  public class Log
  {
    public static Message.Severity LogLevel
    {
      get
      {
        lock (s_mutex)
        {
          return s_logLevel;
        }
      }
      set
      {
        lock (s_mutex)
        {
          s_logLevel = value;
        }
      }
    }

    public static Channel Channel
    {
      get
      {
        lock (s_mutex)
        {
          return s_channel;
        }
      }
      set
      {
        lock (s_mutex)
        {
          s_channel = value;
        }
      }
    }

    public static void Info(String source, String text)
    {
      SendMessage(source, text, Message.Severity.INFORMATION);
    }

    public static void Warning(String source, String text)
    {
      SendMessage(source, text, Message.Severity.WARNING);
    }

    public static void Error(String source, String text)
    {
      SendMessage(source, text, Message.Severity.ERROR);
    }

    public static void Critical(String source, String text)
    {
      SendMessage(source, text, Message.Severity.CRITICAL_ERROR);
    }

    public static void Debug(String source, String text)
    {
      SendMessage(source, text, Message.Severity.DEBUG);
    }

    public static void Trace(String source, String text)
    {
      SendMessage(source, text, Message.Severity.TRACE);
    }

    private static void SendMessage(String source, String text, Message.Severity priority)
    {
      if (priority > LogLevel)
      {
        return;
      }

      Message message = new Message(source, text, priority);

      Channel.HandleMessage(message);
    }

    private static Channel s_channel = new ConsoleChannel();
    private static Message.Severity s_logLevel = Message.Severity.TRACE;
    private static readonly Object s_mutex = new Object();
  }
}
