using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Behaviors
{
    public sealed class ValidationBehaviors<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse> where Trequest : class, IRequest<Tresponse>
    {

        private readonly IEnumerable<IValidator<Trequest>> _validators;
        public ValidationBehaviors(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }
        public async Task<Tresponse> Handle(Trequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<Trequest>(request);

            var errorDictionary = _validators
                .Select(s => s.Validate(context))
                .SelectMany(s => s.Errors)
                .Where(s => s != null)
                .GroupBy(s => s.PropertyName, s => s.ErrorMessage, 
                (propertyName, errorMessage) => new
            {
                Key = propertyName,
                value = errorMessage.Distinct().ToArray()
            }).ToDictionary(s => s.Key, s => s.value[0]);

            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });
                throw new ValidationException(errors);

            }

            return await next();
        }
    }
}
