using Plugin.Maui.Audio;

namespace LouisYogaApp
{
    public partial class MainPage : ContentPage
    {
        public static IAudioPlayer player, player1;
        private readonly IAudioManager audioManager;

        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }
        private async void etMinTimer(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RoundChoiceOneMinTimer)}");
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("singingbellhit.mp3"));
            player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("deepbell.mp3"));
        }

        private async void femMinTimer_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RoundChoiceFiveMinTimer)}");
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("singingbellhit.mp3"));
            player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("deepbell.mp3"));
        }

        private async void tiMinTimer_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RoundChoiceTenMinTimer)}");
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("singingbellhit.mp3"));
            player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("deepbell.mp3"));
        }
    }

}
