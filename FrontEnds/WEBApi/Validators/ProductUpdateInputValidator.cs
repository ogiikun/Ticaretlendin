using FluentValidation;
using WEBApi.Models.Catalogs;

namespace WEBApi.Validators
{
    public class ProductUpdateInputValidator: AbstractValidator<ProductUpdateInput>
    {
        public ProductUpdateInputValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("isim alanı boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("açıklama alanı boş olamaz");
            

            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat alanı boş olamaz").ScalePrecision(2, 8).WithMessage("hatalı para formatı");

        }
    }
}
