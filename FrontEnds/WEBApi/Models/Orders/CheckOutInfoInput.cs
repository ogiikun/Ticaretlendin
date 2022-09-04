using System.ComponentModel.DataAnnotations;

namespace WEBApi.Models.Orders
{
    public class CheckOutInfoInput
    {
        //adres bilgileri
        [Display(Name = "İl")]
        public string Province { get; set; }
        [Display(Name = "İlçe")]
        public string District { get; set; }
        [Display(Name = "Cadde")]
        public string Street { get; set; }
        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }
        [Display(Name = "Adres")]
        public string Line { get; set; }

        //kart bilgileri
        [Display(Name = "Kart isim ve soyisim")]
        public string CardName { get; set; }
        [Display(Name = "Kart Numaraso")]
        public string CardNumber { get; set; }
        [Display(Name = "Son kullanım tarihi")]
        public string Expiration { get; set; }
        [Display(Name = "CVV/CVC2")]
        public string CVV { get; set; }

    }
}
