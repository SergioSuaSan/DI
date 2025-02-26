using MauiFlyout.Pages;

namespace MauiFlyout
{
    public partial class MainPage : FlyoutPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnOption1Clicked(object sender, EventArgs e)
        {
            var currentPage = NavPage.RootPage;

            if (currentPage is not Calculator)
            {
                //if (currentPage is not null)
                //    await NavPage.PopToRootAsync();

                // Si no estamos en Page1, navega a ella
                await NavPage.PushAsync(new Calculator());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en Page1.", "OK");
            }
        }


        private async void OnOption2Clicked(object sender, EventArgs e)
        {

            var currentPage = Navigation.NavigationStack.LastOrDefault();

            if (currentPage is not Page2)
            {
                await NavPage.PushAsync(new Page2());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en Page2.", "OK");
            }

        }

        private async void OnOption3Clicked(object sender, EventArgs e)
        {

            var currentPage = Navigation.NavigationStack.LastOrDefault();

            if (currentPage is not Page3)
            {
                // Si no estamos en Page1, navega a ella
                await NavPage.PushAsync(new Page3());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en Page3.", "OK");
            }

        }



    }

}
       