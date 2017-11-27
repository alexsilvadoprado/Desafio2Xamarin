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
        public NovaMovimentacao()
        {
            InitializeComponent();
        }

        async void OnButtonSalvarMovClicked(object sender, EventArgs e)
        {
            await App.Database.SalvarMovimentacaoAsync(new Movimentacao()
            {
                Descricao = inputDescricao.Text,
                Valor = Double.Parse(inputValor.Text),
                MovimentacaoTipo = rdbtnTipoMov.
            });

            await PopupNavigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        //protected override Task OnAppearingAnimationEnd()
        //{
        //    return Content.FadeTo(0.5);
        //}

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        //protected override Task OnDisappearingAnimationBegin()
        //{
        //    return Content.FadeTo(1);
        //}

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            return base.OnBackButtonPressed();
            //return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}
