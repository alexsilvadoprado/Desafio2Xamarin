using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using System.Threading.Tasks;
using Desafio2.Models;
using Rg.Plugins.Popup.Services;

namespace Desafio2
{
    public partial class NovoMes : PopupPage
    {
        public NovoMes()
        {
            InitializeComponent();
        }

        async void OnButtonSalvarMesClicked(object sender, EventArgs e)
        {
            string mesAno = inputMes.Text + "/" + inputAno.Text;

            if(await App.Database.BuscarMes(mesAno) != null)
            {
                await DisplayAlert("Alerta", "O mês informado já existe", "OK");
            }
            else
            {
				await App.Database.SalvarMesAsync(new Mes(){ MesAno = mesAno });
				
				await PopupNavigation.PopAsync();
            }
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
        protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

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
