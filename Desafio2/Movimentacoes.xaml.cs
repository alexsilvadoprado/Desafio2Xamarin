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

        async void OnButtonSalvarMovClicked(object sender, EventArgs e)
        {
            await App.Database.SalvarMovimentacaoAsync(new Movimentacao(){});

            await PopupNavigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            base.Title = _mes.MesAno;

            var movimentacoes = await App.Database.ListarMovimentacoes(_mes.Id);

            ListaMovimentacoes.ItemsSource = movimentacoes;

            double saldo = movimentacoes.Sum(x => x.Valor);

            if (saldo < 0)
                lblSaldo.TextColor = Color.Red;
            else if (saldo > 0)
                lblSaldo.TextColor = Color.Green;
            else
                lblSaldo.TextColor = Color.White;

            lblSaldo.Text = string.Format("{0:C}", saldo);
        }

        async void OnButtonNovoMovClicked(object sender, EventArgs e)
        {
            var page = new NovaMovimentacao();

            page.Disappearing += OnPopupSalvarDisappearing;

            await PopupNavigation.PushAsync(page);
        }

        async void OnPopupSalvarDisappearing(object sender, EventArgs e)
        {
            ListaMovimentacoes.ItemsSource = await App.Database.ListarMovimentacoes();
        }
    }
}
