using System;
using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .Must(url =>
                {
                    var result = Uri.TryCreate(url, UriKind.Absolute, out Uri outUri);
                    result = result && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
                    return result;
                })
               .WithMessage("Invalid URL");
            return options;
        }
    }
}