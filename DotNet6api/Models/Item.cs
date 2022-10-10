using System.ComponentModel.DataAnnotations;

namespace DotNet6api.Models
{
    public class Item
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
