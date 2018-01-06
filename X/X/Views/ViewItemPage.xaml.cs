﻿using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewItemPage : ContentPage
	{
		public ViewItemPage (DataDisplayModel dataDisplayModel)
		{
			InitializeComponent ();
            BindingContext = new ViewItemViewModel(dataDisplayModel); 
        }
	}
}