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

namespace CPT_Mobile
{
    [Activity(Label = "CPT_Mobile", MainLauncher = false, Icon = "@drawable/icon")]
    class LoginActivity: Activity
    {
        TextView test;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            test = FindViewById<TextView>(Resource.Id.testView);
            test.Text = "Gratulacje, jesteœ zalogowany!";
        }
    }
}