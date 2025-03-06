using MauiFlyout.Pages;

namespace MauiFlyout
{
    public partial class MainPage : FlyoutPage
    {

        public MainPage()
        {
            InitializeComponent();
            iniciaCalculadora();

        }

        private async void iniciaCalculadora()
        {
            await NavPage.PushAsync(new Page1());
        }

        private async void OnOption1Clicked(object sender, EventArgs e)
        {
            var currentPage = NavPage.CurrentPage;

            if (currentPage is not Page1)
            {
                // Regresa a la raíz antes de navegar
               if (NavPage.Navigation.NavigationStack.Count > 1)
                {
                    await NavPage.PopToRootAsync();
                }
                // Si no estamos en Page1, navega a ella
                await NavPage.PushAsync(new Page1());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en La calculadora", "OK");
            }
        }


        private async void OnOption2Clicked(object sender, EventArgs e)
        {

            var currentPage = NavPage.CurrentPage;
      

            if (currentPage is not Page2)
            {
                // Regresa a la raíz antes de navegar
                if (NavPage.Navigation.NavigationStack.Count > 1)
                {
                    await NavPage.PopToRootAsync();
                }
                // Si no estamos en Page1, navega a ella
                await NavPage.PushAsync(new Page2());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en el Conversor", "OK");
            }

        }

        private async void OnOption3Clicked(object sender, EventArgs e)
        {

            var currentPage = NavPage.CurrentPage;


            if (currentPage is not Page3)
            {
                // Regresa a la raíz antes de navegar
                if (NavPage.Navigation.NavigationStack.Count > 1)
                {
                    await NavPage.PopToRootAsync();
                }
                // Si no estamos en Page1, navega a ella
                await NavPage.PushAsync(new Page3());
            }
            else
            {
                // Por ejemplo, podrías hacer un Scroll hasta el principio o refrescar datos
                await DisplayAlert("Información", "Ya estás en la Página 3", "OK");
            }

        }
    }

}
       