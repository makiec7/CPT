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
using SQLite;

namespace CPT_Mobile
{
    class User
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int index_number { get; set; }
        [MaxLength(25)]
        public string username { get; set; }
        [MaxLength(15)]
        public string password { get; set; }
    }
}