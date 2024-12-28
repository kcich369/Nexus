﻿using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface ICommandHandler<in TCommand, TResult> 
    where TCommand : ICommand<IResult<TResult>> where TResult : ICommandResult
{
    ValueTask<IResult<TResult>> Handle(TCommand command, CancellationToken token);
}

