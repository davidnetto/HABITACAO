using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.CreateSorteado
{
    public class CreateSorteadoCommandValidator :AbstractValidator<CreateSorteadoCommand>
    {
        public CreateSorteadoCommandValidator() 
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("Nome é obrigatorio")
                .MaximumLength(200).WithMessage("Nome muito grande, excede 200 caracteres");
        }
    }
}
