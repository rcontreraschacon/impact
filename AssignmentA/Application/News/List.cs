using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Validators;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.News
{
    public class List
    {
        public class Query : IRequest<string>
        {
            public string Url { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Url).Url();
            }
        }

        public class Handler : IRequestHandler<Query, string>
        {
            private readonly IFeedAccessor _feedAccessor;

            public Handler(IFeedAccessor feedAccessor)
            {
                _feedAccessor = feedAccessor;
            }
            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                string result = string.Empty;
                var validator = new QueryValidator();
                ValidationResult results = validator.Validate(request);
                if (!results.IsValid)
                {
                    return result;
                }

                result = await _feedAccessor.GetFeeds(request.Url);
                return result;
            }
        }

    }
}