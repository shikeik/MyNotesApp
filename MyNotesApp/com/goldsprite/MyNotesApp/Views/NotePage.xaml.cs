using Models = com.goldsprite.MyNotesApp.Models;

namespace com.goldsprite.MyNotesApp.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    private string _fileName = Path.Combine(FileSystem.AppDataDirectory, "note.txt");

    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
        if (BindingContext is Models.Note note)
在此之后:
        if (BindingContext is Note note)
*/
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.FileName, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
        if (BindingContext is Models.Note note)
在此之后:
        if (BindingContext is Note note)
*/
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.FileName))
                File.Delete(note.FileName);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
        Models.Note noteModel = new Models.Note();
在此之后:
        Note noteModel = new Models.Note();
*/
        Models.Note noteModel = new Models.Note();
        noteModel.FileName = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}