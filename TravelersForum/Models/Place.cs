using System.ComponentModel.DataAnnotations;
namespace Homework1.Models{
    public class Place{
        public int Id{get; set;}

        [Required(ErrorMessage ="Please fill this field !!!!!")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "Place name could not be shorter than 3 characters")]
        public string? placeName{get; set;}

        [Required(ErrorMessage ="Please fill this field !!!!!")]
        [StringLength(1000,MinimumLength =30,ErrorMessage = "Information field must include at least 30 characters ")]
        public string? placeInfo{get; set;}

        [Required(ErrorMessage ="Please fill this field !!!!!")]
        [StringLength(30,MinimumLength =3,ErrorMessage = "Name could not be shorter than 3 characters")]
        public string? userName{get; set;}

        [Required(ErrorMessage = "Please provide an image link.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImageUrl { get; set; }

        public DateTime submissionDate{ get; set; }

        [Required(ErrorMessage ="Please fill this field !!!!!")]
        [StringLength(10,MinimumLength =3,ErrorMessage = "Location Name could not be shorter than 3 characters")]
        public string? locationName {get;set;}

    }
}