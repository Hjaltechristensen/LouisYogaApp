namespace LouisYogaApp;

public partial class RoundChoiceFiveMinTimer : ContentPage
{
    public static int tal;
    public RoundChoiceFiveMinTimer()
	{
		InitializeComponent();
	}

    private void minus_Clicked(object sender, EventArgs e)
    {
        tal = Convert.ToInt32(counter.Text);
        if (tal == 1)
        {

        }
        else
        {
            tal -= 1;
            counter.Text = tal.ToString();
        }
    }

    private void plus_Clicked(object sender, EventArgs e)
    {
        tal = Convert.ToInt32(counter.Text);
        tal += 1;
        counter.Text = tal.ToString();
    }

    private async void backBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    private async void forward_Clicked(object sender, EventArgs e)
    {
        if (tal == 0)
        {
            tal = 1;
        }
        await Shell.Current.GoToAsync($"//{nameof(FiveMinTimer)}");
    }
}