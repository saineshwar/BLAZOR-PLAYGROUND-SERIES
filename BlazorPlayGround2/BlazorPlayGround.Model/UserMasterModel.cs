using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPlayGround.Model
{
    [Table("UserMaster")]
    public class UserMasterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string EmailId { get; set; }
        [MaxLength(10)]
        public string MobileNo { get; set; }
        public int? GenderId { get; set; }
        public bool Status { get; set; }
    }
}
