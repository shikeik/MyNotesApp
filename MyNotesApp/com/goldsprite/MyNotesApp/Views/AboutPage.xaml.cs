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

/* ��Ŀ��MyNotesApp (net6.0-android33.0)����δ�ϲ��ĸ���
�ڴ�֮ǰ:
        if (BindingContext is Models.About about)
�ڴ�֮��:
        if (BindingContext is About about)
*/
        if (BindingContext is Models.About about)
			// Navigate to the specified URL in the system browser.
			await Launcher.Default.OpenAsync(about.MoreInforUrl);
    }
}