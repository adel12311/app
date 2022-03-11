using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App2.Views
{
    [QueryProperty(nameof(ItemID),nameof(ItemID))]
    public partial class NoteAddingPage : ContentPage
    {
        
        public string ItemID
        {
            set
            {
                LoadNote(value);
            }
        }

        

        public NoteAddingPage()
        {
            InitializeComponent();
            BindingContext = new Note();
        }

        private async   void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Note note = await App.NotesDB.GetApp2Async(id);

                BindingContext = note;
            }
            catch { }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)// вывод и сохранение на экран из БД
        {
            Note note = (Note)BindingContext;

            note.Date = DateTime.Now;


        
            

            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.SaveNoteAsyns(note);
            }


            await Shell.Current.GoToAsync("..");

            

        }

        private async   void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;

            await App.NotesDB.DeleteNoteAsyns(note);

            await Shell.Current.GoToAsync("..");
        }
    }
}