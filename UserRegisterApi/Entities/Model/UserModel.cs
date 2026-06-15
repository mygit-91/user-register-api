using System.ComponentModel.DataAnnotations;
using UserRegisterApi.Constants;

namespace UserRegisterApi.Entities.Model
{
    public class UserModel
    {
        [Required(ErrorMessage = UserMessage.INVALID_FIRST_NAME)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_LAST_NAME)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_EMAIL)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_PHONE)]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_PROFILE_IMAGE)]
        public string Profile { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_BIRTH_DAY)]
        public string BirthDay { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_OCCUPATION)]
        public string Occupation { get; set; } = string.Empty;

        [Required(ErrorMessage = UserMessage.INVALID_SEX)]
        public string Sex { get; set; } = string.Empty;
    }
}
