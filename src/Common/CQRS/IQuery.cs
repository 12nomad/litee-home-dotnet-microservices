using MediatR;

namespace Common.CQRS;

public interface IQuery<out TResult> : IRequest<TResult> { }
