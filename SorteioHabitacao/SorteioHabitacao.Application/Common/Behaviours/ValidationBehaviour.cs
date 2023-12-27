using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Common.Behaviours
{
    public  class  ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<IRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;
        }
    

        public async Task<TResponse> Handle(IRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<IRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
