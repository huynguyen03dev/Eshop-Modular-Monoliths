using MediatR;

namespace Shared.CQRS;
public interface IQueryHandler<in TQuery, TRespond>
    : IRequestHandler<TQuery, TRespond>
    where TQuery : IQuery<TRespond>
    where TRespond : notnull {

}
