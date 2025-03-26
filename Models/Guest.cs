using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproj.Models
{
    public class Guest
    {

        //[Key]
        [Key]  
        public string UserId { get; set; }

<<<<<<< HEAD
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
     
=======
        public string? FirstName { get; set; }
        public string?LastName { get; set; }
>>>>>>> 18080f0654016f6905387b98e3c5128a8721a004
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }

<<<<<<< HEAD
        public string Phone { get; set; }
=======
        //[StringLength(15)]
        public string? Phone { get; set; }
>>>>>>> 18080f0654016f6905387b98e3c5128a8721a004

        public string? Email { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}
