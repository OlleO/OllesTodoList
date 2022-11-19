using MediatR;
using OllesTodoList.Application.Interfaces;
using OllesTodoListApi.Domain;

namespace OllesTodoList.Application.Operations;

public static class GetAll
{
    public class Query : IRequest<Result> 
    {
    }

    public class Result
    {
        public Result(IEnumerable<TodoItem> todoItems) => TodoItems = todoItems;

        public IEnumerable<TodoItem> TodoItems { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ITodoListRepository _repository;

        public Handler(ITodoListRepository repository) => _repository = repository;

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken) => 
            new Result(await _repository.GetAllAsync(cancellationToken));
    }
}
