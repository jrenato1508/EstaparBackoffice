using EstaparGarage.Bussinees.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Models.Validations
{
    public class FormaPagamentoValidation : AbstractValidator<FormaPagamento>
    {
        public FormaPagamentoValidation()
        {
            RuleFor(f => f.Codigo)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(3, 50)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Descricao)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(3, 50)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
