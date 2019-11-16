using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Xamarin.Forms.CollectionView), typeof(CVKeyboard.UWP.CustomCollectionViewRenderer))]
namespace CVKeyboard.UWP
{
	public class CustomCollectionViewRenderer : CollectionViewRenderer
	{
		public CustomCollectionViewRenderer() => KeyUp += HandleKeyUp;

		private void HandleKeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
		{
			if (e.Key != Windows.System.VirtualKey.Enter)
			{
				return;
			}

			e.Handled = true;

			var context = Element.BindingContext as ViewModel;

			var command = context.DisplayDetailCommand;
			var commandParameter = Element.SelectedItem;

			if (command.CanExecute(commandParameter))
			{
				command.Execute(commandParameter);
			}
		}
	}
}
