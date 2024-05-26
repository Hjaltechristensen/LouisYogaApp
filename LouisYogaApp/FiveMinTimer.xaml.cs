using Plugin.Maui.Audio;
namespace LouisYogaApp;

public partial class FiveMinTimer : ContentPage
{
    bool startStop = true;
    bool loopBool = true;
    bool checkNewRound = true;
    bool startToGange = true;
    int runde;
    int genstartMin = 05;
    int genstartSek = 00;
    int minTal = 05;
    int sekTal = 00;
    int i;

    public FiveMinTimer()
    {
        InitializeComponent();
        runde = 1;
        rounds.Text = $"Round {runde}/{RoundChoiceFiveMinTimer.tal}";
    }

    private async void backBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(RoundChoiceFiveMinTimer)}");
    }

    private async void Start_Clicked(object sender, EventArgs e)
    {
        if (startToGange)
        {
            startToGange = false;
            IAudioPlayer player = MainPage.player1;
            player.Play();
            startStop = true;
            loopBool = true;
            await Task.Delay(1000);
            UpdateArc();
        }
    }
    private async void UpdateArc()
    {
        while (loopBool)
        {
            for (i = 0; i < RoundChoiceFiveMinTimer.tal; i++)
            {
                if (loopBool && i != 0 && i < RoundChoiceFiveMinTimer.tal && checkNewRound)
                {
                    runde++;
                }
                rounds.Text = $"Round {runde}/{RoundChoiceFiveMinTimer.tal}";
                while (startStop)
                {
                    if (genstartSek == 0)
                    {
                        genstartMin--;
                        genstartSek = 59;
                        timer.Text = $"0{genstartMin}:{genstartSek}";
                        await Task.Delay(1000);
                    }
                    genstartSek--;
                    if (genstartMin < 10 && genstartSek < 10)
                    {
                        timer.Text = $"0{genstartMin}:0{genstartSek}";
                        await Task.Delay(1000);
                    }
                    else if (genstartSek < 10)
                    {
                        timer.Text = $"{genstartMin}:0{genstartSek}";
                        await Task.Delay(1000);
                    }
                    else if (genstartMin < 10)
                    {
                        timer.Text = $"0{genstartMin}:{genstartSek}";
                        await Task.Delay(1000);
                    }

                    if (runde == RoundChoiceFiveMinTimer.tal)
                    {                        
                        if (genstartMin == 0 && genstartSek == 0)
                        {
                            IAudioPlayer player = MainPage.player1;
                            player.Play();
                            genstartMin = minTal;
                            timer.Text = $"0{genstartMin}:0{genstartSek}";
                            await Task.Delay(200);
                            break;
                        }
                    }
                    else
                    {
                        if (genstartMin == 0 && genstartSek == 0)
                        {
                            IAudioPlayer player = MainPage.player;
                            player.Play();
                            genstartMin = minTal;
                            timer.Text = $"0{genstartMin}:0{genstartSek}";
                            await Task.Delay(200);
                            break;
                        }
                    }
                    checkNewRound = true;
                }
                if (runde >= RoundChoiceFiveMinTimer.tal)
                {
                    startStop = false;
                }
            }
            loopBool = false;
        }
        startStop = false;
        startToGange = true;
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
        startStop = false;
        loopBool = false;
        startToGange = true;
        genstartMin = minTal;
        genstartSek = sekTal;
        timer.Text = $"0{genstartMin}:0{genstartSek}";
        rounds.Text = $"Round {1}/{RoundChoiceFiveMinTimer.tal}";
        runde = 1;
        i = 0;
    }

    private void Pause_Clicked(object sender, EventArgs e)
    {
        startStop = false;
        loopBool = false;
        checkNewRound = false;
        startToGange = true;
    }
}