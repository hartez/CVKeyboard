using System.ComponentModel;
using Xamarin.Forms;

namespace CVKeyboard
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new ViewModel();
		}
	}
}
