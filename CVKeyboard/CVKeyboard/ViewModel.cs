using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CVKeyboard
{
	public class ViewModel : INotifyPropertyChanged
	{
		private List<ItemModel> _items;
		private ItemModel _selectedItem;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ViewModel()
		{
			Items = new List<ItemModel>
			{
				new ItemModel("One"),
				new ItemModel("Two"),
				new ItemModel("Three"),
				new ItemModel("Four"),
				new ItemModel("Five"),
			};

			DisplayDetailCommand = new Command(Navigate, (p) => true);
		}

		void Navigate(object parameter) 
		{
			var itemModel = parameter as ItemModel;

			if (SelectedItem != itemModel)
			{
				SelectedItem = itemModel;
			}

			Application.Current.MainPage.DisplayAlert("Navigation", $"This is where you might navigate to the detail page for item {itemModel.Text}", "OK");
		}

		public List<ItemModel> Items
		{
			get
			{
				return _items;
			}
			set
			{
				_items = value;
				OnPropertyChanged(nameof(Items));
			}
		}

		public ItemModel SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				OnPropertyChanged(nameof(SelectedItem));
			}
		}

		public ICommand DisplayDetailCommand { get; set; }
	}
}
