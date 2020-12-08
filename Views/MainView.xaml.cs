using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CinemaAppDemo.Models;
using Xamarin.Forms;

namespace CinemaAppDemo.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            Tickets = GetTickets();
            BindingContext = this;

        }

        public ObservableCollection<Ticket> Tickets { get; set; }
        public Ticket SelectedTicket { get; set; }

        private ObservableCollection<Ticket> GetTickets()
        {
            return new ObservableCollection<Ticket>
            {
                new Ticket { MovieTitle = "Bad Boys For LIfe", Image = "BadBoys.jpg", ShowingDate = DateTime.Now.AddDays(15), Seats = new int[] { 61, 62, 63 } },
                new Ticket { MovieTitle = "The Old Guard", Image = "OldGuard.jpg", ShowingDate = DateTime.Now.AddDays(22), Seats = new int[] { 111, 112 } },
                new Ticket { MovieTitle = "Tenet", Image = "Tenet.jpg", ShowingDate = DateTime.Now.AddDays(25), Seats = new int[] { 12, 25, 35 } },
                new Ticket { MovieTitle = "No Time To Die", Image = "TimeToDie.jpg", ShowingDate = DateTime.Now.AddDays(20), Seats = new int[] { 99 } }
            };
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
                await Navigation.PushAsync(new SeatsView(SelectedTicket));
        }
    }
}
