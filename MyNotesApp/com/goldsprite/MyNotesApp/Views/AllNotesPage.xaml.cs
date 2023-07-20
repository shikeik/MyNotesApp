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

/* ��Ŀ��MyNotesApp (net6.0-android33.0)����δ�ϲ��ĸ���
�ڴ�֮ǰ:
        ((Models.AllNotes)BindingContext).LoadNotes();
�ڴ�֮��:
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

/* ��Ŀ��MyNotesApp (net6.0-android33.0)����δ�ϲ��ĸ���
�ڴ�֮ǰ:
            var note = (Models.Note)e.CurrentSelection[0];
�ڴ�֮��:
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