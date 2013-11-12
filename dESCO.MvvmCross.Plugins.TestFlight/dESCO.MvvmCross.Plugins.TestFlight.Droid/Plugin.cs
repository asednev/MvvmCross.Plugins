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
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace dESCO.MvvmCross.Plugins.TestFlight.Droid
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterType<IMvxTestFlight, MvxTestFlight>();
        }
    }
}