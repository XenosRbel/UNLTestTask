﻿using UNLTestTask.Core.Presentation.ViewModels;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.EditContact
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditContactPage
	{
		public EditContactPage(IEditContactViewModel viewModel) : base(viewModel)
		{
			InitializeComponent();
		}
	}
}