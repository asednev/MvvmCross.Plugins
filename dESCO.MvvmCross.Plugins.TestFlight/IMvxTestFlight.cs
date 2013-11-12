using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dESCO.MvvmCross.Plugins.TestFlight
{
    public interface IMvxTestFlight
    {
        void PassCheckpoint(string checkpointName);

        void Log(string logLine);

        void SendCrash(Exception e);
        void SendCrash(string stackTrace);
        void SendCrash(string stackTrace, string threadName);
        void SendCrash(long currentTimeMillis, string stackTrace, string threadName); 
    }
}
