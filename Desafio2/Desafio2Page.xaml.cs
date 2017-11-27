using System;
using Desafio2.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Desafio2
{
    public partial class Desafio2Page : ContentPage
    {
        public Desafio2Page()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Meses.ItemsSource = await App.Database.ListarMeses();
        }

        async void OnItemSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Mes;

            await Navigation.PushAsync(new Movimentacoes(item));
        }

        async void OnButtonNovoMesClicked(object sender, EventArgs e)
        {
            var page = new NovoMes();

            page.Disappearing += OnPopupSalvarDisappearing;

            await PopupNavigation.PushAsync(page);
        }

        async void OnPopupSalvarDisappearing(object sender, EventArgs e)
        {
            Meses.ItemsSource = await App.Database.ListarMeses();
        }
    }
}
