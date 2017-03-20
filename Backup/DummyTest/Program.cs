using System;
using System.Collections.Generic;
using System.Text;
using Uva.Log;

namespace DummyTest
{
  class Program
  {
    static readonly String TAG = "Program";

    static void Main(string[] args)
    {
      Log.Critical(TAG, "Critical error message");
      Log.Error(TAG, "Error message");
      Log.Info(TAG, "Information message");
      Log.Warning(TAG, "Warning message");
      Log.Debug(TAG, "Debug message");
      Log.Trace(TAG, "Trace message");
    }
  }
}
