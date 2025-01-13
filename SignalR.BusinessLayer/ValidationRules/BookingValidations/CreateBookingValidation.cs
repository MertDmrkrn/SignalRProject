using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Numarası Alanı Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez Lütfen Tarih Seçimi Yapınız!");


            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen İsim Alanına En Az 5 Karakter Doldurunuz ").MaximumLength(50).WithMessage("Lütfen İsim Alanına En Fazla 50 Karakter Doldurunuz");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Lütfen Açıklama Alanına En Az 5 Karakter Doldurunuz ").MaximumLength(250).WithMessage("Lütfen Açıklama Alanına En Fazla 250 Karakter Doldurunuz");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir E-Mail Adresi Giriniz.");
            

        }
    }
}
