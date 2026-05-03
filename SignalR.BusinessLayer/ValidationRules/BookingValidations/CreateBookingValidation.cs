using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation: AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x=>x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x=>x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez! Lütfen tarih seçiniz.");

            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("İsim alanı en az 2 karakter olmalıdır.").MaximumLength(50).WithMessage("İsim alanı en fazla 50 karakter olmalıdır.");

            RuleFor(x=>x.Description).MaximumLength(200).WithMessage("Açıklama alanı en fazla 200 karakter olmalıdır.");

            RuleFor(x=>x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz!");
        }
    }
}
