using System;
using System.Collections.Generic;
using System.Linq;
using Desafio2.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Desafio2
{
    public partial class Movimentacoes : ContentPage
    {
        private Mes _mes;

        public Movimentacoes(Mes mes)
        {
			InitializeComponent();

            _mes = mes;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            base.Title = _mes.MesAno;

            RefreshData();
        }

        /// <summary>
        /// Apresenta formulário para inserção de Movimentação
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnButtonNovoMovClicked(object sender, EventArgs e)
        {
            var page = new NovaMovimentacao(_mes.Id);

            page.Disappearing += OnPopupSalvarDisappearing;

            await PopupNavigation.PushAsync(page);
        }

        /// <summary>
        /// Executa operações após fechado o formulário
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnPopupSalvarDisappearing(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Remove o Highlight do ListView
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnItemSelected(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Atualiza as informações da Tela
        /// </summary>
        async void RefreshData()
        {
            var movimentacoes = await App.Database.ListarMovimentacoes(_mes.Id);

            ListaMovimentacoes.ItemsSource = movimentacoes;

            double receita = movimentacoes.Where(x => x.MovimentacaoTipo.Equals("Receita")).Sum(x => x.Valor);

            double despesa = movimentacoes.Where(x => x.MovimentacaoTipo.Equals("Despesa")).Sum(x => x.Valor);

            double saldo = receita - despesa;

            if (saldo < 0)
                lblSaldo.TextColor = Color.Red;
            else if (saldo > 0)
                lblSaldo.TextColor = Color.Lime;
            else
                lblSaldo.TextColor = Color.White;

            lblSaldo.Text = string.Format("{0:C}", saldo);
        }
    }
}
