using FlightApps.Models;
using FlightApps.Services;
using FlightApps.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightApps.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }

        private ObservableCollection<Booking> bookings;
        public ObservableCollection<Booking> Bookings
        {
            get => bookings;
            set => SetProperty(ref bookings, value);
        }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }


        async void getBookings()
        {
            if (Application.Current.Properties.ContainsKey("email"))
            {
                LoginService service = new LoginService();
                var bookingList = await service.GetUserBooking(Application.Current.Properties["email"].ToString());

                for (int i = 0; i < bookingList.Count; i++)
                {
                    bookingList[i].text = "FlightScheduleID: " + bookingList[i].FlightScheduleID;
                    bookingList[i].description = "MYR " + bookingList[i].Amount;
                }
                Bookings = new ObservableCollection<Booking>(bookingList);
            }
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                getBookings();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}