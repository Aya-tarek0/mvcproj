using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvcproj.Models
{
    public class Staff
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("Hotel")]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
<<<<<<< HEAD
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
=======

        //[StringLength(15)]
        public string? Phone { get; set; }

        public string? Email { get; set; }
        public DateTime HireDate { get; set; }

        public Hotel ?Hotel { get; set; }
>>>>>>> 18080f0654016f6905387b98e3c5128a8721a004
    }

}
