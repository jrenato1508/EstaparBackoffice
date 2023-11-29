using EstaparGarage.Bussinees.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Models.Validations
{
    public class PassagemValidation : AbstractValidator<Passagem>
    {
        public PassagemValidation()
        { 
            RuleFor(p => p.NomeGaragem)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.CarroPlaca)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.CarroMarca)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.CarroModelo)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.DataHoraEntrada)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            

            
        }
    }
}
