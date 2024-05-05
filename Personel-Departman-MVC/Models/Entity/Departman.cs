using System.ComponentModel.DataAnnotations;

namespace Personel_Departman_MVC.Models.Entity
{
    public class Departman
    {
        public int Id { get; set; }

        [Required]
        public string? DepartmanName { get; set; }

        [Required]
        public string? DepartmanDescription { get; set; }

        //Navigation Property!
        public List<Personel>? _personels { get; set; }
    }
}
