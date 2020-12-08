using System;
namespace CinemaAppDemo.Models
{
    public class Ticket
    {
        public string MovieTitle { get; set; }
        public DateTime ShowingDate { get; set; }
        public string Image { get; set; }
        public int[] Seats { get; set; }
    }
}
