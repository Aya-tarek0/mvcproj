using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproj.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        [ForeignKey("Guest")]
        public int GuestID { get; set; }

        [ForeignKey("Room")]
        public int RoomNumber { get; set; }

        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int TotalPrice { get; set; }

        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
