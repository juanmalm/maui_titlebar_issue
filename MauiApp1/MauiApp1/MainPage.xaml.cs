namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, EventArgs e)
	{
		App.Current.Quit();
	}
}

