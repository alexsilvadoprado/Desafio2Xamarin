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

        /// <summary>
        /// Salva o Mes/Ano no SQLite e fecha o Popup
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
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

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        // Invocado quando o background é clicado
        protected override bool OnBackgroundClicked()
        {
            // Retorna o valor padrão - Fecha quando o background é clicado
            return base.OnBackgroundClicked();
        }
    }
}
