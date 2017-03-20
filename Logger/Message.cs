using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Uva.Log
{
  /// <summary>
  /// A log message that is sent though a chain of log channels.
  /// <p>
  /// A log message contains:<br>
  ///<li>A priority denoting the severity of message.</li>
  ///<li>A source describing its origin.</li>
  ///<li>A text describing its meaning.</li>
  ///<li>The time of its creation.</li>
  ///<li>An identifier of process and thread created this message.</li>
  /// </summary>
  public class Message
  {
    /// <summary>
    /// A priority denoting the serverity of a log message.
    /// </summary>
    public enum Severity
    {
      /// <summary>
      /// A critical error. The application might not be able to continue running successfully. This is the highest priority.
      /// </summary>
      CRITICAL_ERROR = 0x0,
      /// <summary>
      /// An error. An operation did not complete successfully, but the application as a whole is not affected.
      /// </summary>
      ERROR = 0x1,
      /// <summary>
      /// A warning. An operation completed with an unexpected result.
      /// </summary>
      WARNING = 0x2,
      /// <summary>
      /// An informational message, usually denoting the successful completion of an operation.
      /// </summary>
      INFORMATION = 0x3,
      /// <summary>
      /// A debugging message.
      /// </summary>
      DEBUG = 0x4,
      /// <summary>
      /// A tracing message.
      /// </summary>
      TRACE = 0x5
    }

    /// <summary>
    /// Creates a message with all required information set.
    /// </summary>
    /// <param name="source">the source of the message</param>
    /// <param name="text">the text of the message</param>
    /// <param name="severity">the priority of the message</param>
    public Message(String source, String text, Severity severity)
    {
      _source = source;
      _text = text;
      _severity = severity;
    }

    public DateTime CreationTime
    {
      get
      {
        return _creationTime;
      }
      set
      {
        _creationTime = value;
      }
    }

    public Severity Priority
    {
      get
      {
        return _severity;
      }
      set
      {
        _severity = value;
      }
    }

    public String Source
    {
      get
      {
        return _source;
      }
      set
      {
        _source = value;
      }
    }

    public String Text
    {
      get
      {
        return _text;
      }
      set
      {
        _text = value;
      }
    }

    public int ProcessId
    {
      get
      {
        return _processId;
      }
      set
      {
        _processId = value;
      }
    }

    public String ThreadName
    {
      get
      {
        return _threadName;
      }
      set
      {
        _threadName = value;
      }
    }

    private DateTime _creationTime = DateTime.Now;
    private String _threadName = Thread.CurrentThread.Name;
    private int _processId = Process.GetCurrentProcess().Id;

    private Severity _severity;
    private String _source;
    private String _text;
  }
}
