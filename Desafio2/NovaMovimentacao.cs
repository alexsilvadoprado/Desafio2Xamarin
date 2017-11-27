using System;

using Xamarin.Forms;

namespace Desafio2
{
    public class NovaMovimentacao : ContentPage
    {
        public NovaMovimentacao()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

