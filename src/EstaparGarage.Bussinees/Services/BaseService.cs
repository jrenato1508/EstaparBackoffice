using EstaparGarage.business.Interfaces;
using EstaparGarage.business.Notificacoes;
using EstaparGarage.Bussinees.Models;
using FluentValidation;
using FluentValidation.Results;

namespace EstaparGarage.business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

           
            Notificar(validator);

            return false;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {               
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {         
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
