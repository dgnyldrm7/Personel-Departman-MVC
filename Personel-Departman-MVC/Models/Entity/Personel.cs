using System.ComponentModel.DataAnnotations;

namespace Personel_Departman_MVC.Models.Entity
{
    public class Personel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? lName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }


        //Foreign Key!
        [Required]
        public int DepartmanId { get; set; }

        //Navigtaion Property!
        public Departman? _departman { get; set; }
    }
}
