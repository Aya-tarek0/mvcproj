using System.ComponentModel.DataAnnotations;

namespace mvcproj.Models
{
    public class Guest
    {

        //[Key]
        public int GuestID { get; set; }

        public string? FirstName { get; set; }
        public string?LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }

        //[StringLength(15)]
        public string? Phone { get; set; }

        public string? Email { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}
