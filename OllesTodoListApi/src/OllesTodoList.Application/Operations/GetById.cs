using MediatR;
using OllesTodoList.Application.Interfaces;
using OllesTodoListApi.Domain;

namespace OllesTodoList.Application.Operations;

public static class GetById
{
    public class Query : IRequest<Result>
    {
        public Query(long id) => Id = id;

        public long Id { get; set; }

    }

    public class Result
    {
        public Result(TodoItem? todoItem) => TodoItem = todoItem;

        public TodoItem? TodoItem { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ITodoListRepository _repository;

        public Handler(ITodoListRepository repository) => _repository = repository;

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken) => 
            new Result(await _repository.GetByIdAsync(request.Id, cancellationToken));
    }
}
