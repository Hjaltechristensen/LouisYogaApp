using Plugin.Maui.Audio;

namespace LouisYogaApp
{
	public partial class MainPage : ContentPage
	{
		public static IAudioPlayer? player, player1;
		private readonly IAudioManager audioManager;

		public MainPage(IAudioManager audioManager)
		{
			InitializeComponent();
			this.audioManager = audioManager;
		}

		private async void NavigateAndCreatePlayers(string timerName)
		{
			await Shell.Current.GoToAsync($"//{timerName}");
			player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("singingbellhit.mp3"));
			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("deepbell.mp3"));
		}

		private void OneMinuteTimer_Clicked(object sender, EventArgs e)
		{
			NavigateAndCreatePlayers(nameof(RoundChoiceOneMinTimer));
		}

		private void FiveMinuteTimer_Clicked(object sender, EventArgs e)
		{
			NavigateAndCreatePlayers(nameof(RoundChoiceFiveMinTimer));
		}

		private void TenMinuteTimer_Clicked(object sender, EventArgs e)
		{
			NavigateAndCreatePlayers(nameof(RoundChoiceTenMinTimer));
		}
	}
}
