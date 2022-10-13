using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNet6api.Models
{
    public class Item
    {
        
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Thing> Things { get; set; }
    }
}
