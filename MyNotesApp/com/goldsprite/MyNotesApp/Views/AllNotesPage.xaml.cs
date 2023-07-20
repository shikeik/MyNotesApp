using System.Reflection;
using Models = com.goldsprite.MyNotesApp.Models;

namespace com.goldsprite.MyNotesApp.Views;


public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllNotes();
    }

    protected override void OnAppearing()
    {

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
        ((Models.AllNotes)BindingContext).LoadNotes();
在此之后:
        ((AllNotes)BindingContext).LoadNotes();
*/
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
            var note = (Models.Note)e.CurrentSelection[0];
在此之后:
            var note = (Note)e.CurrentSelection[0];
*/
            var note = (Models.Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}