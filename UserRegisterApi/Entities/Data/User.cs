using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegisterApi.Entities.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string BirthDay { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
    }
}
