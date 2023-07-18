using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    public class Register
    {
        [Required] //zorunlu alan
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen email giriniz")] //zorunlu alan. eğer girilmezse "Lütfen email giriniz" mesajı çıkacak.
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Email adresini kontrol ediniz")] //email doğrulama
        public string Email { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "6-8 karakter")] //parola uzunluğu max 8, min 6 
        [PasswordIsValid]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage ="parola tekrar alanı yanlış")] //girilen değeri password değeri ile karşılaştırıyor.
        public string RePassword { get; set; }
        
        [UIHint("Date")] //sadece date alanı alınıyor. saat alınmıyor.
        [Required(ErrorMessage = "Doğum tarihini giriniz")]
        public DateTime BirthDate { get; set; }
        
        //[Range(typeof(bool),"true","true", ErrorMessage = "Lütfen koşulları kabul ediniz")] //sadece true değeri aldığında hata vermeyecek.
        [MustBeTrue] //Custom property validation---kendi yazdığımız bir tane validation ile hata mesajı döndürüyoruz.
        public bool TermsAccepted { get; set; }
    }
}