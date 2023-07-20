using Models = com.goldsprite.MyNotesApp.Models;

namespace com.goldsprite.MyNotesApp.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	private async void LearnMore_Clicked(object sender, EventArgs e)
    {

/* 项目“MyNotesApp (net6.0-android33.0)”的未合并的更改
在此之前:
        if (BindingContext is Models.About about)
在此之后:
        if (BindingContext is About about)
*/
        if (BindingContext is Models.About about)
			// Navigate to the specified URL in the system browser.
			await Launcher.Default.OpenAsync(about.MoreInforUrl);
    }
}