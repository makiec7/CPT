using Android.App;
using Android.Widget;
using Android.OS;
using LoginScreen;
using SQLite;
using System;
using System.IO;

namespace CPT_Mobile
{
    [Activity(Label = "CPT_Mobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView test;
        EditText login;
        EditText password;
        Button btnlogin;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.log_screen);
            test = FindViewById<TextView>(Resource.Id.testView);
            btnlogin = FindViewById<Button>(Resource.Id.logButton);
            login = FindViewById<EditText>(Resource.Id.loginEdit);
            password = FindViewById<EditText>(Resource.Id.passwordEdit);
            btnlogin.Click += btnlogin_Click;
            CreateDB();
            Btncreate_Click();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<User>(); //Call Table  
                var data1 = data.Where(x => x.username == login.Text && x.password == password.Text).FirstOrDefault(); //Linq Query  
                if (data1 != null)
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                    StartActivity(typeof(LoginActivity));
                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        public string CreateDB()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }

        private void Btncreate_Click()
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<User>();
                User tbl = new User();
                tbl.username = "180122";
                tbl.password = "180122";
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
    }


