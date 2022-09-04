using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WEBApi.Models.Catalogs
{
    public class ProductUpdateInput
    {
        public string Id { get; set; }

        [Display(Name = "Ürün İsmi")]
        public string Name { get; set; }

        [Display(Name = "Ürün Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }


        [Display(Name = "Ürün Kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Ürün Resmi")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
