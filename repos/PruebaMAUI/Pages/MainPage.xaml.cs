using PruebaMAUI.Models;
using PruebaMAUI.PageModels;

namespace PruebaMAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}