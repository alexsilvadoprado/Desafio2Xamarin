using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using System.Threading.Tasks;
using Desafio2.Models;
using Rg.Plugins.Popup.Services;

namespace Desafio2
{
    public partial class NovaMovimentacao : PopupPage
    {
        private int _mesId;

        public NovaMovimentacao(int mesId)
        {
            InitializeComponent();

            _mesId = mesId;
        }

        /// <summary>
        /// Salva a movimentação no SQLite e fecha o Popup
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnButtonSalvarMovClicked(object sender, EventArgs e)
        {
            await App.Database.SalvarMovimentacaoAsync(new Movimentacao()
            {
                Descricao = inputDescricao.Text,
                Valor = Double.Parse(inputValor.Text),
                MovimentacaoTipo = pickerTipoMov.SelectedIndex == 0 ? "Receita" : "Despesa",
                MovimentacaoCor = pickerTipoMov.SelectedIndex == 0 ? "Lime" : "Red",
                MesId = _mesId
            });

            await PopupNavigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            pickerTipoMov.ItemsSource = new List<string>() { "Receita", "Despesa" };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        // Invocado quando o background é clicado
        protected override bool OnBackgroundClicked()
        {
            // Retorna valor padrão - Fecha quando o background é clicado
            return base.OnBackgroundClicked();
        }
    }
}
