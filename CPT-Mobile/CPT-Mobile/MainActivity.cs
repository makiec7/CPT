using Android.App;
using Android.Widget;
using Android.OS;

namespace CPT_Mobile
{
    [Activity(Label = "CPT_Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView testView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Button logButton = FindViewById<Button>(Resource.Id.logButton);
            testView = FindViewById<TextView>(Resource.Id.testView);

            logButton.Click += delegate
            {
                OnButtonClicked();
            };
            
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

       void OnButtonClicked()
        {
            testView.Text = "logged";
        }
    }
}

