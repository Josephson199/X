﻿using System;
using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
            InitializeComponent();
            BindingContext = new MainViewModel();
            BtnNavigateToQuotes.Clicked += NavigateToQoutes;
            BtnNavigateToJokes.Clicked += NavigateToJokes;
            BtnNavigateToLibrary.Clicked += NavigateToLibrary;

        }

        private async void NavigateToLibrary(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LibraryPage());
        }

        private async void NavigateToJokes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JokePage());
        }

        private async void NavigateToQoutes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuotePage());
        }
    }
}