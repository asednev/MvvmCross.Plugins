using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore.Droid.Platform;

namespace dESCO.MvvmCross.Plugins.TestFlight.Droid
{
    public class MvxTestFlight : MvxAndroidTask, IMvxTestFlight
    {

        public void PassCheckpoint(string checkpointName)
        {
            Com.TestFlightApp.Lib.TestFlight.PassCheckpoint(checkpointName);
        }

        public void Log(string logLine)
        {
            Com.TestFlightApp.Lib.TestFlight.Log(logLine);
        }

        public void SendCrash(Exception e)
        {
            Com.TestFlightApp.Lib.TestFlight.SendCrash(e);
        }

        public void SendCrash(string stackTrace)
        {
            Com.TestFlightApp.Lib.TestFlight.SendCrash(stackTrace);
        }

        public void SendCrash(string stackTrace, string threadName)
        {
            Com.TestFlightApp.Lib.TestFlight.SendCrash(stackTrace, threadName);
        }

        public void SendCrash(long currentTimeMillis, string stackTrace, string threadName)
        {
            Com.TestFlightApp.Lib.TestFlight.SendCrash(currentTimeMillis, stackTrace, threadName);
        }

    }
}