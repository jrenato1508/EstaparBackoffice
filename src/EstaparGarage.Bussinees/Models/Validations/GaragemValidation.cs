using EstaparGarage.Bussinees.Models;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Models.Validations
{
    public class GaragemValidation : AbstractValidator<Garagem>
    {
        public GaragemValidation() {

            RuleFor(g => g.Codigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(g => g.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3,50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(g => g.Preco_1aHora)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(g => g.Preco_1aHora)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(g => g.Preco_1aHora)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
                

        }
    }
}
