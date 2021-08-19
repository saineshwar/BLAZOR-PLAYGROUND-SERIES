using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPlayGround1.Model
{
    [Table("States")]
    public class States
    {
        [Key]
        public int StateId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}