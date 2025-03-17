namespace LouisYogaApp;

public partial class RoundChoiceTenMinTimer : ContentPage
{
    public static int tal;
    public RoundChoiceTenMinTimer()
	{
		InitializeComponent();
	}

    private void Minus_Clicked(object sender, EventArgs e)
    {
        tal = Convert.ToInt32(counter.Text);
        if (tal > 1)
        {
            tal -= 1;
            counter.Text = tal.ToString();
        }
    }

    private void Plus_Clicked(object sender, EventArgs e)
    {
        tal = Convert.ToInt32(counter.Text);
        tal += 1;
        counter.Text = tal.ToString();
    }

    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

    private async void Forward_Clicked(object sender, EventArgs e)
    {
        if (tal == 0)
        {
            tal = 1;
        }

        await Shell.Current.GoToAsync($"//{nameof(TenMinTimer)}");
    }

    private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}