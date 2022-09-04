using System.ComponentModel.DataAnnotations;

namespace WEBApi.Models
{
    public class SıgnUpInput
    {
        [Display(Name = "Kullanıcı Adınız ")]
        public string UserName { get; set; }
        [Display(Name = "Email Adresiniz")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifreniz ")]
        public string Password { get; set; }
        [Display(Name = " Adresiniz")]
        public string City { get; set; }


    }
}

