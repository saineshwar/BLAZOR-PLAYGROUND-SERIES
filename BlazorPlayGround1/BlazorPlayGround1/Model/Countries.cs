using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPlayGround1.Model
{
    [Table("Countries")]
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
    }
}