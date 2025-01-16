﻿using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface ICommandValidator<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult
{
    ValueTask<IResult<IValidationContext<TCommand>>> Validate(TCommand command, CancellationToken token);
}