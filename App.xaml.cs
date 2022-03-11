using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Data;
using System.IO;
//using Com.OneSignal;

namespace App2
{
    public partial class App : Application
    {
        static NotesDB notesDB;

        public static NotesDB NotesDB

        {
            get 
            { 
                if(notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "NotesDataBase.db3"));
                        
                }
                return notesDB;
            }
        }




        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

//OneSignal.Current.StartInit("Не забудь сделать зарядку")
        //        .EndInit();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
