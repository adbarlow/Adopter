using System;
using System.Collections.Generic;
using Adopter.View;
using Xamarin.Forms;

namespace Adopter
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void SignInButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GalleryPage()));
            //DisplayAlert("Button", "This button should take you to a home page", "ok");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }

}
