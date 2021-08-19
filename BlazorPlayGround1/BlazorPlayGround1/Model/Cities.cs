using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPlayGround1.Model
{
    [Table("Cities")]
    public class Cities
    {
        [Key]
        public int CitiesId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int StateId { get; set; }
    }
}