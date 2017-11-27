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

            // Adiciona itens da base de dados local no ListView
            Meses.ItemsSource = await App.Database.ListarMeses();
        }

        /// <summary>
        /// Evento de chamado sempre que um item do ListView é Selecionado
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnItemSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Mes;

            await Navigation.PushAsync(new Movimentacoes(item));
        }

        /// <summary>
        /// Apresenta o formulário de insersão
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnButtonNovoMesClicked(object sender, EventArgs e)
        {
            var page = new NovoMes();

            page.Disappearing += OnPopupSalvarDisappearing;

            await PopupNavigation.PushAsync(page);
        }

        /// <summary>
        /// Atualiza os dados do ListView quando o formulário é fechado
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnPopupSalvarDisappearing(object sender, EventArgs e)
        {
            Meses.ItemsSource = await App.Database.ListarMeses();
        }

        /// <summary>
        /// Chama a tela "Sobre"
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnButtonSobreClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sobre());
        }
    }
}
